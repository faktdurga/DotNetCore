using StocksApp.Interface;
using System.Text.Json;

namespace StocksApp.Services
{
    public class MyService : IFinhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;

        public MyService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>> GetStockPriceQuote(string stockSymbol)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                string url = "https://finnhub.io/api/v1/quote?symbol=" + stockSymbol + "&token=" + _configuration["FinnhubbToken"]?.ToString();

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    //RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol=${stockSymbol}&token=cu6fllpr01qh2ki5ijegcu6fllpr01qh2ki5ijf0"),
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();

                StreamReader streamReader = new StreamReader(stream);

                StreamReader sr = new StreamReader(stream);

                string response = sr.ReadToEnd();

                Dictionary<string, object>? responseDic = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if(responseDic != null)
                {
                    return responseDic;
                }
                else
                {
                    throw new InvalidOperationException("No response from finhub API");
                }
                
            }


        }

    }
}
