using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public interface IDishesService
    {
        IEnumerable<Dish> GetDishes();
        bool DeleteDish(long id);
        public Dish CreateDish(Dish dish);
    }

    
}
