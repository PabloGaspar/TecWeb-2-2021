using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class DishesService : IDishesService
    {
        private List<Dish> _dishes;

        public DishesService()
        {
            _dishes = new List<Dish>();

            _dishes.Add(new Dish() 
            {
                Id = 1, 
                Name = "Pique",
                Price = 90,
                Restaurant = "Tunary"
            });

            _dishes.Add(new Dish()
            {
                Id = 2,
                Name = "Silpancho",
                Price = 45,
                Restaurant = "Tunary"
            });

            _dishes.Add(new Dish()
            {
                Id = 3,
                Name = "Panchicono",
                Price = 80,
                Restaurant = "Panchita"
            });

            _dishes.Add(new Dish()
            {
                Id = 4,
                Name = "Cabañitas",
                Price = 120,
                Restaurant = "Panchita"
            });
        }

        public Dish CreateDish(Dish dish)
        {
            long newId = _dishes.OrderByDescending(d => d.Id).FirstOrDefault().Id+1;
            dish.Id = newId;
            _dishes.Add(dish);
            return dish;
        }

        public bool DeleteDish(long id)
        {
            var dish = _dishes.FirstOrDefault(d => d.Id == id);
            _dishes.Remove(dish);
            return true;
        }

        public IEnumerable<Dish> GetDishes()
        {
            return _dishes;
        }
    }
}
