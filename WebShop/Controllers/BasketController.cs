using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class BasketController : Controller
    {

        // GET: Basket
        public ActionResult Index()
        {
            return View();
        }
    }
}