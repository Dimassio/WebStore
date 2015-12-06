using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebStore.Controllers
{
    public class OrderController : Controller
    {
        // Button Orders show only in admins mode. It is ony for admin
        private List<Order> getOrderList()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Orders.ToList();
            }
        }

        // GET: Order
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var orderList = getOrderList();
            return View(orderList);
        }

        [Route("order/edit/{id:int}")]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, StatusEnum status)   // Change status of order
        {
            using (var db = new ApplicationDbContext())
            {
                var order = db.Orders.Find(id);
                order.Status = status;
                db.SaveChanges();
                return Redirect("/Order/Index");
            }
        }

        [Authorize]
        public ActionResult Make()
        {
            using (var db = new ApplicationDbContext())
            {
                Order order = new Order();
                order.Items = new List<int>();
                foreach (var b in db.Basket)
                {
                    order.Items.Add(b.BasketTypeId);
                    db.Basket.Remove(b);
                }
                order.Status = StatusEnum.IN_PROGRESS;
                order.Date = DateTime.Now;
                db.Orders.Add(order);
                ApplicationUser user = db.Users.Find(User.Identity.GetUserId()); 
                user.Orders.Add(order);
                db.SaveChanges();
                return Redirect("/Item/Index");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Show()
        {
            using (var db = new ApplicationDbContext())
            {
                ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
                return View(user.Orders);
            }
        }

    }
}