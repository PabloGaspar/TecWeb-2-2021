using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Entities
{
    public class RestaurantEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime? Founded { get; set; }

        public IEnumerable<DishEntity> Dishes { get; set; }
    }
}
