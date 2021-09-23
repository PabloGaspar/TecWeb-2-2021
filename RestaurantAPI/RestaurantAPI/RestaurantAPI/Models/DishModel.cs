
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class DishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool CanBeDelivered { get; set; }
        public int RestaurantId { get; set; }
    }
}
