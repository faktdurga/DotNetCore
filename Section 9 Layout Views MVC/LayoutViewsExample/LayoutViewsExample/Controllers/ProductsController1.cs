using Microsoft.AspNetCore.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class ProductsController1 : Controller
    {
        [Route("Product")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search-product/{productid?}")]

        public IActionResult Search(int? productid) 
        {
            ViewBag.productid = productid;
            return View();
        }

        [Route("order-product")]
        public IActionResult Order()
        {
            return View();
        }

    }
}
