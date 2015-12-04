using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class ItemController : Controller
    {
        private List<Item> formItemList()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Items.ToList();
            }

        }

        public ActionResult Index()
        {
            var itemList = formItemList();
            return View(itemList);
        }

        [Route("category/{id:int}")]
        public ActionResult Category(int id)
        {
            // todo: show id category
            return View();
        }

        [HttpPost]
        [Route("item/add")]
        [Authorize(Roles = "admin")]
        public ActionResult Add(AddEditItemModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new ApplicationDbContext())
            {
                var newItem = new Item(model.Name, model.Price, model.Category, model.Description, model.ForSale);
                db.Items.Add(newItem);
                db.SaveChanges();
                return View("/Item/Index");
            }

        }


        [HttpGet]
        [Route("item/add")]
        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            return View(new AddEditItemModel());
        }


        [HttpGet]
        [Route("item/edit/{id:int}")]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                bool idIsValid = (from r in db.Items
                                  select r.ItemId).Contains(id);
                if (!idIsValid)
                {
                    return new HttpStatusCodeResult(404, "No item with such id: " + id);
                }
                var model = new AddEditItemModel();
                var item = db.Items.Find(id);
                model.Name = item.Name;
                model.Description = item.Description;
                model.Category = item.Category;
                model.Price = item.Price;
                model.ForSale = item.ForSale;
                return View(model);
            }

        }

        [HttpPost]
        [Route("item/edit/{id:int}")]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, AddEditItemModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new ApplicationDbContext())
            {
                var item = db.Items.Find(id);
                item.Name = model.Name;
                item.Description = model.Description;
                item.Category = model.Category;
                item.ForSale = model.ForSale;
                item.Price = model.Price;
                db.SaveChanges();
                return Redirect("/Item/Index");
            }

        }
    }
}