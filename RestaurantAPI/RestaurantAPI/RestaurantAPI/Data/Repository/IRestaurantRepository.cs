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
        IEnumerable<RestaurantEntity> GetRestaurants(string orderBy);
        RestaurantEntity GetRestaurant(int restaurantId);
        RestaurantEntity CreateRestaurant(RestaurantEntity restaurant);
        RestaurantEntity UpdateRestaurant(int restaurantId, RestaurantEntity restaurant);
        void DeleteRestaurant(int restaurantId);


        //Dishes
        IEnumerable<DishEntity> Getdishes(int restaurantId);
        DishEntity Getdish(int restaurantId, int dishId);
        DishEntity CreateDish(int restaurantId, DishEntity dish);
        void DeleteDish(int restaurantId, int dishId);
        DishEntity UpdateDish(int restaurantId, int dishId, DishEntity dish);
    }
}
