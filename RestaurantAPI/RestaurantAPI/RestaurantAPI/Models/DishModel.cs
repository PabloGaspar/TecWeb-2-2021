
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class DishModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }
        public bool? CanBeDelivered { get; set; }
        public int RestaurantId { get; set; }
    }
}
