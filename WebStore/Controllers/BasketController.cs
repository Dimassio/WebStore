using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class BasketController : Controller
    {

        private List<BasketType> getBasketList()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Basket.ToList();
            }
        }

        // GET: Basket
        public ActionResult Index()
        {
            var itemList = getBasketList();
            return View(itemList);
        }

        [Route("basket/add/{id:int}")]
        public ActionResult Add(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var item = db.Items.Find(id);
                BasketType basketItem = new BasketType();
                basketItem.Name = item.Name;
                basketItem.Description = item.Description;
                basketItem.Price = item.Price;
                basketItem.Category = item.Category;
                db.Basket.Add(basketItem);
                db.SaveChanges();
                return Redirect("/Item/Index");
            }

        }

        [Route("basket/delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var basketItem = db.Basket.Find(id);
                if (basketItem == null)
                {
                    return new HttpStatusCodeResult(404, "No item in basket with such id: " + id);
                }
                db.Basket.Remove(basketItem);
                db.SaveChanges();
                return Redirect("/Basket/Index");
            }

        }
    }
}