using Microsoft.AspNetCore.Mvc;
using ViewsExample.Model;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "ASP.Net Core App";
            ViewData["header"] = "Person";
            List<Person> people = new List<Person>()
            {
                new Person(){Name = "John", DOB = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
                new Person(){Name = "Radha", DOB = DateTime.Parse("2005-04-03"), PersonGender = Gender.Female},
                new Person(){Name = "Abdul", DOB = DateTime.Parse("2000-12-20"), PersonGender = Gender.Male},
                new Person(){Name = "Chaya", DOB = DateTime.Parse("1993-12-24"), PersonGender = Gender.Female}
            };        
            return View("Index", people);
        }


        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
                return Content("Person name cant be null");

            List<Person> people = new List<Person>()
            {
                new Person(){Name = "John", DOB = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
                new Person(){Name = "Radha", DOB = DateTime.Parse("2005-04-03"), PersonGender = Gender.Female},
                new Person(){Name = "Abdul", DOB = DateTime.Parse("2000-12-20"), PersonGender = Gender.Male},
                new Person(){Name = "Chaya", DOB = DateTime.Parse("1993-12-24"), PersonGender = Gender.Female}
            };

            Person? matchingPerson = people.FirstOrDefault(temp => temp.Name == name);

            return View(matchingPerson);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() { Name = "John", DOB = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male };
            
            Product product = new Product(){ ProductID = 1, ProductName = "Iphone 14"};

            PersonAndProductWrapper pnp = new PersonAndProductWrapper() { personData = person, productData = product};

            return View("PersonAndProduct", pnp);
        }

    }

}
