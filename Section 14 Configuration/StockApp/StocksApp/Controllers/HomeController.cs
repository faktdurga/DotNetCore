using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyService _myService;

        private readonly IOptions<TradingOptions> _tradingOption;
        public HomeController(MyService myService, IOptions<TradingOptions> tradingOption)
        {
            _myService = myService;
            _tradingOption = tradingOption;
        }

        [Route("/")]
       public async Task<IActionResult> Index()
       {
            if(_tradingOption.Value.DefaultStockSymbol == null)
            {
                _tradingOption.Value.DefaultStockSymbol = "MSFT";               
            }

            Dictionary<string, object> StockPriceQuote =  await _myService.GetStockPriceQuote(_tradingOption.Value.DefaultStockSymbol);


            Stock stok = new Stock()
            {
                StockSymbol = _tradingOption.Value.DefaultStockSymbol,
                CurrentPrice = Convert.ToDouble(StockPriceQuote["c"].ToString()),
                HighestPrice = Convert.ToDouble(StockPriceQuote["h"].ToString()),
                LowestPrice = Convert.ToDouble(StockPriceQuote["l"].ToString()),
                OpenPrice = Convert.ToDouble(StockPriceQuote["o"].ToString())
            };

            return View(stok);
       }
    }
}

