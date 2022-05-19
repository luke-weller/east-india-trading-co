using east_india_trading_co.Models;
using Microsoft.AspNetCore.Mvc;

namespace east_india_trading_co.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class CheapestRouteController : ControllerBase
    {
        public RouteResult GetCheapestRoute(RouteRequest routeRequest)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7289/api/routeTest");
            Console.WriteLine(routeRequest.to);
            return new RouteResult(100, 300);
        }
    }
}