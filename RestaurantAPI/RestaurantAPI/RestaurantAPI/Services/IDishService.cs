using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        IEnumerable<DishModel> Getdishes(int restaurantId);
        DishModel Getdish(int restaurantId, int dishId);
        DishModel CreateDish(int restaurantId, DishModel dish);
        void DeleteDish(int restaurantId, int dishId);
        DishModel UpdateDish(int restaurantId, int dishId, DishModel dish);
    }
}
