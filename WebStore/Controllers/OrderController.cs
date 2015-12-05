using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebStore.Models;

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
            return View(orderList); // todo: create view with orders + editing status of order(again, by ActionLink)
        }

        [Route("order/edit/{id:int}")]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(StatusEnum status)   // Change status of order
        {
            using (var db = new ApplicationDbContext())
            {
 
            }
        }


        public ActionResult Make()
        {
            using (var db = new ApplicationDbContext())
            {
                Order order = new Order();
                foreach(var b in db.Basket)
                {
                    order.Items.Add(new Item(b.Name, b.Price, b.Category, b.Description, false));
                }
                order.Status = StatusEnum.IN_PROGRESS;
                db.Orders.Add(order);
                db.SaveChanges();
                return Redirect("/Item/Index");
            }         
        }

    }
}