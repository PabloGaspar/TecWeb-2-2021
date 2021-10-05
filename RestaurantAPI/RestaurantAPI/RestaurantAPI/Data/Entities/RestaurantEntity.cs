using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Entities
{
    public class RestaurantEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime? Founded { get; set; }

        public ICollection<DishEntity> Dishes { get; set; }
    }
}
