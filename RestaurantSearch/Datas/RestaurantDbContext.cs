using Microsoft.EntityFrameworkCore;

namespace RestaurantSearch.Datas
{
    public class RestaurantDbContext:DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Restaurant> Restaurants { get; set; } = null!;
    }
}
