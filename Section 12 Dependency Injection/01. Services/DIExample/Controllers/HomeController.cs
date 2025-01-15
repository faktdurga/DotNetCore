using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DIExample.Controllers
{
  public class HomeController : Controller
  {
        
        private readonly ICitiesService _citiesService;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        //constructor injection
        public HomeController(ICitiesService citiesService, ICitiesService citiesService2, ICitiesService citiesService3, IServiceScopeFactory serviceScopeFactory)
        {     
            _citiesService = citiesService;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _serviceScopeFactory = serviceScopeFactory;

        }
        

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            ViewBag.InstanceID_citiservice1 = _citiesService.ServiceInstanceID;
            ViewBag.InstanceID_citiservice2 = _citiesService2.ServiceInstanceID;
            ViewBag.InstanceID_citiservice3 = _citiesService3.ServiceInstanceID;

            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                //Inject city service here
            }

                return View(cities);
        }
  }
}
