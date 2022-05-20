using east_india_trading_co.Models;
using east_india_trading_co.Util;
using Microsoft.AspNetCore.Mvc;

namespace east_india_trading_co.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class CheapestRouteController : ControllerBase
    {

       
        

            public IActionResult GetCheapestRoute(RouteRequest routeRequest)
        {

            try
            {
                ShortestPathCalculator calculator = new ShortestPathCalculator(routeRequest);
                return Ok(calculator.Result);

            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}