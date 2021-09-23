using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private IList<RestaurantEntity> _restaurants;
        private IList<DishEntity> _dishes = new List<DishEntity>();

        public RestaurantRepository()
        {
            _restaurants = new List<RestaurantEntity>();
            _restaurants.Add(new RestaurantEntity()
            {
                Id = 1,
                Name = "Panchita",
                Address = "La Cancha",
                Phone = "6665555444",
                Founded = new DateTime(1991, 8, 12)
            });

            _restaurants.Add(new RestaurantEntity()
            {
                Id = 2,
                Name = "Overtime",
                Address = "Prado",
                Phone = "666555111",
                Founded = new DateTime(2001, 9, 10)
            });


            _dishes.Add(new DishEntity()
            {
                Id = 1, 
                Name = "Panchicono",
                Price = 25.50m,
                ToDeliver = false,
                RestaurantId = 1
            });

            _dishes.Add(new DishEntity()
            {
                Id = 2,
                Name = "Alitas",
                Price = 30.30m,
                ToDeliver = true,
                RestaurantId = 1
            });

            _dishes.Add(new DishEntity()
            {
                Id = 3,
                Name = "BBQ Pizza",
                Price = 28.30m,
                ToDeliver = true,
                RestaurantId = 2
            });

            _dishes.Add(new DishEntity()
            {
                Id = 4,
                Name = "Tropical Pizza",
                Price = 35.30m,
                ToDeliver = true,
                RestaurantId = 2
            });
        }


        public DishEntity CreateDish(int restaurantId, DishEntity dish)
        {
            throw new NotImplementedException();
        }

        public RestaurantEntity CreateRestaurant(RestaurantEntity restaurant)
        {
            var lastRestaurant = _restaurants.OrderByDescending(r => r.Id).FirstOrDefault();
            int nextId = lastRestaurant != null ? lastRestaurant.Id + 1 : 1;
            restaurant.Id = nextId;
            _restaurants.Add(restaurant);
            return lastRestaurant;
        }

        public void DeleteDish(int restaurantId, int dishId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public DishEntity Getdish(int restaurantId, int dishId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DishEntity> Getdishes(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public RestaurantEntity GetRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RestaurantEntity> GetRestaurants(string orderBy)
        {
            throw new NotImplementedException();
        }

        public DishEntity UpdateDish(int restaurantId, int dishId, DishEntity dish)
        {
            throw new NotImplementedException();
        }

        public RestaurantEntity UpdateRestaurant(int restaurantId, RestaurantEntity restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
