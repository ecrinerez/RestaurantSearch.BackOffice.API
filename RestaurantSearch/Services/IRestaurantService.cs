using RestaurantSearch.Models;

namespace RestaurantSearch.Services
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant?> GetRestaurantByIdAsync(int id);
        Task<List<Restaurant>> SearchRestaurantsAsync(string name, string cuisine);
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task<Restaurant?> UpdateRestaurantAsync(int id, Restaurant restaurant);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<List<Restaurant>> GetRestaurantsByCuisineAsync(string cuisine);
        Task<List<Restaurant>> GetRestaurantsByRatingAsync(double minRating);
    }
}
