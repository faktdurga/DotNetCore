namespace StocksApp.Interface
{
    public interface IFinhubService
    {
        Task<Dictionary<string, object>> GetStockPriceQuote(string stockSymbol);
    }
}
