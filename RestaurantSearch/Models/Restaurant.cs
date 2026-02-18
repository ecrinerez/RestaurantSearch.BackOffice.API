using System.ComponentModel.DataAnnotations;

namespace RestaurantSearch.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        [Required]
        public string Cuisine { get; set; } = "";
        [Range(0, 5)]
        public double Rating { get; set; }
    }
}
