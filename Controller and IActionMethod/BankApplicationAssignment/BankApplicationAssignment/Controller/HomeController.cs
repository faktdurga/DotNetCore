using BankApplicationAssignment.Model;
using Microsoft.AspNetCore.Mvc;

namespace BankApplicationAssignment.Controller
{
    public class HomeController : ControllerBase
    {
        [Route("Home")]
        public IActionResult Index()
        {
            Response.StatusCode = 200;
            return Content("Welcome to best bank");
        }

        [Route("account-details")]
        public IActionResult GetAccountDetails()
        {
            UserDetails UD = new UserDetails() { 
                AccountNumber= 1000,
                AccountHolderName = "Durgaprasad Mohite",
                Balance= 25000,
            };


            return Ok(UD);
        }

        [Route("account-statement")]
        public IActionResult GetBankStatement()
        {
            return new VirtualFileResult("/BankStatement.pdf", "application/pdf");
        }

        [Route("get-current-balance/{acountnumber:int}")]
        public IActionResult GetBankAccount(int acountnumber)
        {
            UserDetails UD = new UserDetails()
            {
                AccountNumber = 1000,
                AccountHolderName = "Durgaprasad Mohite",
                Balance = 25000,
            };


            if(acountnumber != 1000) 
            {
                return BadRequest("Accoutn number should be 1000");
            }


            return Ok(UD.Balance);
        }

        [Route("get-current-balance")]
        public IActionResult GetBankAccount()
        {
            
            return NotFound("Account number should be supplied");
            
        }
    }
}
