using FlowerShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository iProductRepository = new ProductRepository();
        public ActionResult Index()
        {
            ViewBag.LatestProducts = iProductRepository.LatestProducts(3);
            ViewBag.FeaturedProducts = iProductRepository.FeaturedProducts(2);
            return View();
        }
    }
}