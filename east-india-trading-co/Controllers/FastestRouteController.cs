using east_india_trading_co.Models;
using Microsoft.AspNetCore.Mvc;

namespace east_india_trading_co.Controllers
{
    [Route("api/routeFast")]
    [ApiController]
    public class FastestRouteController : Controller
    {

        public RouteResult GetFastestRoute(RouteRequest routeRequest)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7289/api/routeTest");
            Console.WriteLine(routeRequest.to);
            return new RouteResult(100, 300);
        }
    }
}
