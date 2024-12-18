using ControllerExample.Model;
using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ContentResult Index()
        {
            return Content("<h1>Hello from index</h1>", "text/html");
        }

        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("contactus")]
        public string Contact()
        {
            return "Hello from contact us";
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person p = new Person();

            p.Id = 1;
            p.FirstName = "Durga";
            p.LastName = "Mohite";
            p.Age = 35;

            return new JsonResult(p);
        }
        //C:\Users\DURGA\Downloads
        [Route("file")]
        public VirtualFileResult File()
        {
            return new VirtualFileResult("/Top-500-DotNet-Interview-Questions-2022-PDF (1).pdf", "application/pdf");
        }

        [Route("physcialfile")]
        public PhysicalFileResult PhysicalFile()
        {
            return new PhysicalFileResult(@"C:\Users\DURGA\Downloads\Table Invoice.pdf", "application/pdf");
        }

        [Route("filebyte")]
        public FileContentResult ByteFile()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\DURGA\Downloads\Table Invoice.pdf");
            return new FileContentResult(bytes, "application/pdf");
        }
    }
}
