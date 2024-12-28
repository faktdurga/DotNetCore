using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Register")]
        public IActionResult Index([Bind(nameof(Person.PersonName))] [FromQuery]Person person)
        {

            if(!ModelState.IsValid)
            {

                List<string> lstError = new List<string>();


                #region using loops
                /*
                foreach (var value in ModelState.Values)
                {
                    foreach(var error in value.Errors)
                    {
                        lstError.Add(error.ErrorMessage);
                    }
                }

                string erroroutput = string.Join("\n ", lstError);
                
                return BadRequest(erroroutput);
                */
                #endregion

                #region using linq

                lstError = 
                    ModelState.Values.SelectMany(value => 
                    value.Errors).Select(err => 
                    err.ErrorMessage).ToList();

                string erroroutput = string.Join("\n ", lstError);

                return BadRequest(erroroutput);
                #endregion

            }
            return Content($"{person}");
        }
    }
}
