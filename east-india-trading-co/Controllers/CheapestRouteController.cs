using east_india_trading_co.Models;
using east_india_trading_co.Util;
using Microsoft.AspNetCore.Mvc;

namespace east_india_trading_co.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class CheapestRouteController : ControllerBase
    {

       
        ShortestPathCalculator calculator = new ShortestPathCalculator();


            public IActionResult GetCheapestRoute(RouteRequest routeRequest)
        {
            try
            {
                return Ok(calculator.TestCalc(routeRequest));

            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}