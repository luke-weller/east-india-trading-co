namespace east_india_trading_co.Models
{
    public class RouteResult
    {
        public RouteResult(int price, int time)
        {
            this.price = price;
            this.time = time;
        }

        public int price { get; set; }
        public int time { get; set; }
    }
}
