using Microsoft.EntityFrameworkCore;
using RestaurantSearch.Datas;
using RestaurantSearch.Models;

namespace RestaurantSearch.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _context;

        public RestaurantService(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<Restaurant?> UpdateRestaurantAsync(int id, Restaurant restaurant)
        {
            var existing = await _context.Restaurants.FindAsync(id);
            if (existing == null) return null;

            existing.Name = restaurant.Name;
            existing.Address = restaurant.Address;
            existing.PhoneNumber = restaurant.PhoneNumber;
            existing.Cuisine = restaurant.Cuisine;
            existing.Rating = restaurant.Rating;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null) return false;

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Restaurant>> SearchRestaurantsAsync(string name, string cuisine)
        {
            return await _context.Restaurants
                .Where(r => r.Name.Contains(name) && r.Cuisine.Contains(cuisine))
                .ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantsByCuisineAsync(string cuisine)
        {
            return await _context.Restaurants
                .Where(r => r.Cuisine.Contains(cuisine))
                .ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantsByRatingAsync(double minRating)
        {
            return await _context.Restaurants
                .Where(r => r.Rating >= minRating)
                .ToListAsync();
        }
    }
}
