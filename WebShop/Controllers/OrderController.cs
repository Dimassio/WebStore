using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        // todo: button Orders show only in admins mode
       /* private List<Order> getOrderList()
        {
            using (var db = new StoreContext())
            {
                return db.Orders.ToList();
            }
        }*/

        // GET: Order
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            /* var orderList = getOrderList();
             return View(orderList);*/
            return View();
        }

        [Route("order/edit/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            /*using (var db = new StoreContext())
            {
                return View(db.Orders.Find(id));
            }*/
            return View();
                
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(bool done, int id) // Admin can change only status of order
        {
            /*using (var db = new StoreContext())
            {
                db.Orders.Find(id).Status = done ? StatusEnum.DONE : StatusEnum.IN_PROGRESS;
                db.SaveChanges();
                return Redirect("/Item/Index");
            }*/
            return View();
        }

    }
}