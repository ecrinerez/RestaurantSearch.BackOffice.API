using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSearch.Models;
using RestaurantSearch.Services;

namespace RestaurantSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(IRestaurantService service) : ControllerBase
    {
       
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
        {
         return Ok(await service.GetRestaurantsAsync());
        }
    }
}
