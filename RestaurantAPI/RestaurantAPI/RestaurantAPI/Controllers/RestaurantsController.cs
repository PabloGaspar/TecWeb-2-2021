using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurants")]
    public class RestaurantsController : Controller
    {
        private IRestaurantService _restaurantService;
        
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public IEnumerable<RestaurantModel> GetRestaurants()
        {
            var restaurants = _restaurantService.GetRestaurants();
            return restaurants;
        }

        [HttpGet("{id:int}")]
        public RestaurantModel GetRestaurant(int id)
        {
            var restaurant = _restaurantService.GetRestaurant(id);
            return restaurant;
        }

        [HttpPost]
        public RestaurantModel PostRestaurant([FromBody] RestaurantModel restaurant)
        {
            var newRestaurant = _restaurantService.CreateRestaurant(restaurant);
            return newRestaurant;
        }

        [HttpDelete("{restaurantId:int}")]
        public bool DeleteRestaurant(int restaurantId)
        {
            return _restaurantService.DeleteRestaurant(restaurantId);
        }

        [HttpPut("{restaurantId:int}")]
        public RestaurantModel PutRestant(int restaurantId, [FromBody] RestaurantModel restaurant)
        {
            var updatedRestaurant = _restaurantService.UpdateRestaurant(restaurantId, restaurant);
            return updatedRestaurant;
        }
    }
}
