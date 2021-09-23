using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public class DishService : IDishService
    {
        public DishModel CreateDish(int restaurantId, DishModel dish)
        {
            throw new NotImplementedException();
        }

        public void DeleteDish(int restaurantId, int dishId)
        {
            throw new NotImplementedException();
        }

        public DishModel Getdish(int restaurantId, int dishId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DishModel> Getdishes(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public DishModel UpdateDish(int restaurantId, int dishId, DishModel dish)
        {
            throw new NotImplementedException();
        }
    }
}
