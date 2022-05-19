namespace east_india_trading_co.Models
{
    public class RouteResult
    {
        public RouteResult(double price, double time)
        {
            this.price = price;
            this.time = time;
        }

        public double price { get; set; }
        public double time { get; set; }
    }
}
