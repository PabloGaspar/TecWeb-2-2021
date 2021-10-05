using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Entities
{
    public class DishEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public bool? CanBeDelivered { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual RestaurantEntity Restaurant { get; set; }
    }
}
