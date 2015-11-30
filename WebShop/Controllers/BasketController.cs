using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Add(int id)
        {
            //Page: товар под номер ай ди в корзине
            // помещает в корзину ТЕКУЩЕГО юзера Итем под айдишником id
            return View();
        }
    }
}