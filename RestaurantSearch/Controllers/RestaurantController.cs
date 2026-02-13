using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantSearch.Models;
using RestaurantSearch.Services;

namespace RestaurantSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService service;

        public RestaurantController(IRestaurantService service)
        {
            this.service = service;
        }

        // GET all
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
        {
            return Ok(await service.GetRestaurantsAsync());
        }

        // GET by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
        {
            var restaurant = await service.GetRestaurantByIdAsync(id);
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Restaurant>> AddRestaurant(Restaurant restaurant)
        {
            var result = await service.AddRestaurantAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = result.Id }, result);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<Restaurant>> UpdateRestaurant(int id, Restaurant restaurant)
        {
            var updated = await service.UpdateRestaurantAsync(id, restaurant);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            var deleted = await service.DeleteRestaurantAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
