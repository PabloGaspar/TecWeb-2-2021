using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        Task<IEnumerable<DishModel>> GetdishesAsync(int restaurantId);
        Task<DishModel> GetdishAsync(int restaurantId, int dishId);
        Task<DishModel> CreateDishAsync(int restaurantId, DishModel dish);
        Task DeleteDishAsync(int restaurantId, int dishId);
        Task<DishModel> UpdateDishAsync(int restaurantId, int dishId, DishModel dish);
    }
}
