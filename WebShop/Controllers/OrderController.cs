using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        // todo: button Orders show only in admins mode
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
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return View(db.Orders.Find(id));
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(bool done, int id) // Admin can change only status of order
        {
            using (var db = new ApplicationDbContext())
            {
                db.Orders.Find(id).Status = done ? StatusEnum.DONE : StatusEnum.IN_PROGRESS;
                db.SaveChanges();
                return Redirect("/Item/Index");
            }
        }

    }
}