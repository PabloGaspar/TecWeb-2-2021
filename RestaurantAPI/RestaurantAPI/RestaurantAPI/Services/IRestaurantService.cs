using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantModel>> GetRestaurantsAsync(string orderBy);
        Task<RestaurantModel> GetRestaurantAsync(int restaurantId, bool showRestaurant = false);
        Task<RestaurantModel> CreateRestaurantAsync(RestaurantModel restaurant);
        Task<RestaurantModel> UpdateRestaurantAsync(int restaurantId, RestaurantModel restaurant);
        Task DeleteRestaurantAsync(int restaurantId);

    }
}
