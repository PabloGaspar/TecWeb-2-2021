using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantModel> GetRestaurants(string orderBy);
        ResponseModel<RestaurantModel> GetRestaurant(int restaurantId);
        RestaurantModel CreateRestaurant(RestaurantModel restaurant);
        RestaurantModel UpdateRestaurant(int restaurantId, RestaurantModel restaurant);
        void DeleteRestaurant(int restaurantId);

    }
}
