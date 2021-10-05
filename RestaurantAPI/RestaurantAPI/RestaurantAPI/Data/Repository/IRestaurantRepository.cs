using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Repository
{
    public interface IRestaurantRepository
    {
        //Restaurants
        Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync(string orderBy);
        Task<RestaurantEntity> GetRestaurantAsync (int restaurantId, bool showRestaurant = false);
        void CreateRestaurant(RestaurantEntity restaurant);
        Task UpdateRestaurantAsync(int restaurantId, RestaurantEntity restaurant);
        Task DeleteRestaurantAsync(int restaurantId);


        //Dishes
        Task<IEnumerable<DishEntity>> GetdishesAsync(int restaurantId);
        Task<DishEntity> GetdishAsync(int restaurantId, int dishId);
        void CreateDish(int restaurantId, DishEntity dish);
        Task DeleteDishAsync(int restaurantId, int dishId);
        Task UpdateDishAsync(int restaurantId, int dishId, DishEntity dish);

        Task<bool> SaveChangesAsync();
    }
}
