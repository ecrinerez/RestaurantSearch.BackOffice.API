using RestaurantSearch.Models;

namespace RestaurantSearch.Services
{
    public class RestaurantService : IRestaurantService
    {
        static List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant { Id = 1, Name = "Pizza Bulls", Address = "123 Main St", PhoneNumber = "555-1234", Cuisine = "Italian", Rating = 4.5 },
            new Restaurant { Id = 2, Name = "Sushi Inn", Address = "456 Elm St", PhoneNumber = "555-5678", Cuisine = "Japanese", Rating = 4.1 },
            new Restaurant { Id = 3, Name = "Mcdonalds", Address = "789 Oak St", PhoneNumber = "555-9012", Cuisine = "USA", Rating = 4.3 },
            new Restaurant { Id = 4, Name = "Kebap", Address = "321 Pine St", PhoneNumber = "555-3456", Cuisine = "Turkish", Rating = 4.6 }
        };

        public Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return Task.FromResult(restaurants);
        }

        public Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(restaurant);
        }

        public Task<List<Restaurant>> SearchRestaurantsAsync(string name, string cuisine)
        {
            var result = restaurants
                .Where(r => r.Name.Contains(name) && r.Cuisine.Contains(cuisine))
                .ToList();

            return Task.FromResult(result);
        }

        public Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            return Task.FromResult(restaurant);
        }

        public Task<Restaurant?> UpdateRestaurantAsync(int id, Restaurant restaurant)
        {
            var existing = restaurants.FirstOrDefault(r => r.Id == id);
            if (existing == null)
           return Task.FromResult<Restaurant?>(null);

            existing.Name = restaurant.Name;
            existing.Address = restaurant.Address;
            existing.PhoneNumber = restaurant.PhoneNumber;
            existing.Cuisine = restaurant.Cuisine;
            existing.Rating = restaurant.Rating;

            return Task.FromResult<Restaurant?>(existing);
        }

        public Task<bool> DeleteRestaurantAsync(int id)
        {
            var removed = restaurants.RemoveAll(r => r.Id == id) > 0;
            return Task.FromResult(removed);
        }

        public Task<List<Restaurant>> GetRestaurantsByCuisineAsync(string cuisine)
        {
            return Task.FromResult(restaurants.Where(r => r.Cuisine.Contains(cuisine)).ToList());
        }

        public Task<List<Restaurant>> GetRestaurantsByRatingAsync(double minRating)
        {
            return Task.FromResult(restaurants.Where(r => r.Rating >= minRating).ToList());
        }
    }
}
