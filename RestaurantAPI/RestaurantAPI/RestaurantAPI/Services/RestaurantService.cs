using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private IList<RestaurantModel> _restaurants;


        private HashSet<string> _allowedSortValues = new HashSet<string> { "id", "name", "address" };
        public RestaurantService()
        {
            _restaurants = new List<RestaurantModel>();
            _restaurants.Add(new RestaurantModel()
            {
                Id = 1,
                Name = "Panchita",
                Address = "La Cancha",
                Phone = "6665555444",
                Founded = new DateTime(1991, 8, 12)
            });

            _restaurants.Add(new RestaurantModel()
            {
                Id = 2,
                Name = "Overtime",
                Address = "Prado",
                Phone = "666555111",
                Founded = new DateTime(2001, 9, 10)
            });
        }

        public RestaurantModel CreateRestaurant(RestaurantModel restaurant)
        {
            
            var lastRestaurant = _restaurants.OrderByDescending(r => r.Id).FirstOrDefault();
            int nextId = lastRestaurant != null? lastRestaurant.Id + 1 : 1;
            restaurant.Id = nextId;
            _restaurants.Add(restaurant);
            return restaurant;
        }

        public void DeleteRestaurant(int restaurantId)
        {
            var restaurantToDelete = _restaurants.SingleOrDefault(r => r.Id == restaurantId);
            if (restaurantToDelete == null)
                throw new NotFoundElementException($"the restaurant with id:{restaurantId} does not exists.");

            _restaurants.Remove(restaurantToDelete);
        }

        public ResponseModel<RestaurantModel> GetRestaurant(int restaurantId)
        {
            var restaurant = _restaurants.FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant == null)
                return new ResponseModel<RestaurantModel>() { isSuccess = false, Errors = new List<string>() { "somethin  happened", "id does not exist" }, ErrorType = ErrorResponseType.NotFound };
                //return restaurant;
            return new ResponseModel<RestaurantModel>() { isSuccess = true, Value = restaurant };
            //throw new NotFoundElementException($"the restaurant with id:{restaurantId} does not exists.");
        }

        public IEnumerable<RestaurantModel> GetRestaurants(string orderBy = "id")
        {
            if (!_allowedSortValues.Contains(orderBy.ToLower()))
                throw new InvalidElementOperationException($"invalid orderBy value : {orderBy}. The allowed values for param are: {string.Join(',', _allowedSortValues)}");

            switch (orderBy.ToLower())
            {
                case "id":
                    return _restaurants.OrderBy(r => r.Id);
                case "name":
                    return _restaurants.OrderBy(r => r.Name);
                case "address":
                    return _restaurants.OrderBy(r => r.Address);
                default:
                    return _restaurants.OrderBy(r => r.Id);
            }
        }

        public RestaurantModel UpdateRestaurant(int restaurantId, RestaurantModel restaurant)
        {
            var restaurantToUpdate = _restaurants.SingleOrDefault(r => r.Id == restaurantId);
            if (restaurantToUpdate == null)
                throw new NotFoundElementException($"the restaurant with id:{restaurantId} does not exists.");

            restaurantToUpdate.Name = restaurant.Name ?? restaurantToUpdate.Name;
            restaurantToUpdate.Address = restaurant.Address ?? restaurantToUpdate.Address;
            restaurantToUpdate.Founded = restaurant.Founded ?? restaurantToUpdate.Founded;
            restaurantToUpdate.Phone = restaurant.Phone ?? restaurantToUpdate.Phone;

            return restaurantToUpdate;
        }
    }
}
