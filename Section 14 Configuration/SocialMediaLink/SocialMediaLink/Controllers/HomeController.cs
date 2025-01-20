using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SocialMediaLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly SocialMediaLinkOptions _socialMediaOption;

        public HomeController(IOptions<SocialMediaLinkOptions> socialMediaOption)
        {
            _socialMediaOption = socialMediaOption.Value;
        }


        [Route("/")]
        public IActionResult Index()
        {
            @ViewBag.Facebook = _socialMediaOption.Facebook;
            @ViewBag.Instagram = _socialMediaOption.Instagram;
            @ViewBag.Twitter = _socialMediaOption.Twitter;
            @ViewBag.Youtube = _socialMediaOption.Youtube;   

            return View();
        }
    }
}
