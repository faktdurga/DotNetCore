using ECommerceApplication.CustomValidation;
using ECommerceApplication.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("/order")]
        public IActionResult Index([FromBody] Order order)
        {
            if(!ModelState.IsValid)
            {
                List<string> lstError = new List<string>();

                lstError = ModelState.Values.SelectMany(value =>
                value.Errors).Select(err => 
                err.ErrorMessage).ToList();

                string errorOutput = string.Join("\n", lstError);

                return BadRequest(errorOutput);
            }
            
            if(order.InvoicePrice.HasValue && order.Products != null) 
            {
                bool res = InvoiceValidator.IsValid(order.InvoicePrice.Value, order.Products);
                if(!res)
                {
                    return BadRequest("Invoice price should match with Product price total");
                }
            }

            Random random = new Random();
            order.OrderNo = random.Next(0, 9999);

            return Ok($"Order placed and order no is {order.OrderNo}");

        }
    }
}
