using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/loadList")]
        public IActionResult LoadList()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Person",
                People = new List<Person>()
                {

                    new Person (){PersonName = "John", JobTitle = "Manager"},
                    new Person (){PersonName = "Diana", JobTitle = "Assitance Manager"},
                    new Person (){PersonName = "Prajakta", JobTitle = "Team Lead"},
                    new Person (){PersonName = "Abdul", JobTitle = "SSE"}
                }
            };

            return ViewComponent("Grid", new {grid = personGridModel});
        }
    }
}
