using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantModel> GetRestaurants();
        RestaurantModel GetRestaurant(int restaurantId);
        RestaurantModel CreateRestaurant(RestaurantModel restaurant);
        RestaurantModel UpdateRestaurant(int restaurantId, RestaurantModel restaurant);
        bool DeleteRestaurant(int restaurantId);

    }
}
