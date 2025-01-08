using Microsoft.AspNetCore.Mvc;
using PartialViewExample.Models;

namespace PartialViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("programming-language")]
        public IActionResult ProgramingLanguages()
        {
            ListModel listModel = new ListModel();

            listModel.ListTitle = "Programing Language";
            listModel.ListItems = new List<string>() { "Java", "C#", "Python" };


            return PartialView("_ListPartialViews", listModel);
            //return new PartialViewResult() { ViewName ="_ListPartialView", Model =listModel }; 
        }
    }
}
