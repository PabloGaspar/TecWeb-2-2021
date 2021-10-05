using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private RestaurantDBContext _dbContext;

        public RestaurantRepository(RestaurantDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //https://docs.microsoft.com/en-us/ef/ef6/saving/change-tracking/entity-state

        public void CreateDish(int restaurantId, DishEntity dish)
        {
            _dbContext.Entry(dish.Restaurant).State = EntityState.Unchanged;
            _dbContext.Dishes.Add(dish);
        }

        public void CreateRestaurant(RestaurantEntity restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
        }

        public async Task DeleteDishAsync(int restaurantId, int dishId)
        {
            var dishToDelete =  await _dbContext.Dishes.FirstOrDefaultAsync(d => d.Restaurant.Id == restaurantId && d.Id == dishId);
            _dbContext.Dishes.Remove(dishToDelete);
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurantToDelete = await _dbContext.Restaurants.SingleOrDefaultAsync(r => r.Id == restaurantId);
            //_dbContext.Entry(restaurantToDelete).State = EntityState.Deleted;

            _dbContext.Restaurants.Remove(restaurantToDelete);
        }

        public async Task<DishEntity> GetdishAsync(int restaurantId, int dishId)
        {
            IQueryable<DishEntity> query = _dbContext.Dishes;
            //query = query.Include(d => d.Restaurant);
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(d => d.Id == dishId && d.Restaurant.Id == restaurantId);
        }

        public async Task<IEnumerable<DishEntity>> GetdishesAsync(int restaurantId)
        {
            IQueryable<DishEntity> query = _dbContext.Dishes;
            query = query.AsNoTracking();
            query =  query.Where(d => d.Restaurant.Id == restaurantId);
            return await query.ToListAsync();
        }

        public async Task<RestaurantEntity> GetRestaurantAsync(int restaurantId, bool showRestaurant = false)
        {
            IQueryable<RestaurantEntity> query = _dbContext.Restaurants;
            query = query.AsNoTracking();
            if (showRestaurant)
            {
                query = query.Include(r => r.Dishes);
            }

            return await query.FirstOrDefaultAsync(r => r.Id == restaurantId);
        }

        public async Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync(string orderBy)
        {

            IQueryable<RestaurantEntity> query = _dbContext.Restaurants;
            query = query.AsNoTracking();

            switch (orderBy.ToLower())
            {
                case "id":
                    query = query.OrderBy(r => r.Id);
                    break;
                case "name":
                    query = query.OrderBy(r => r.Name);
                    break;
                case "address":
                    query = query.OrderBy(r => r.Address);
                    break;
                default:
                    query = query.OrderBy(r => r.Id);
                    break;
            }

            //query = query.Where()

            var result = await query.ToListAsync();

            return result;
             
            //hit to database
            //tolist()
            //toArray()
            //foreach
            //firstOfDefaul
            //Single
            //Count
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                return result > 0? true: false;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateDishAsync(int restaurantId, int dishId, DishEntity dish)
        {
            var dishToUpdate = await _dbContext.Dishes.FirstOrDefaultAsync(d => d.Id == dishId && d.Restaurant.Id == restaurantId);
            dishToUpdate.Name = dish.Name ?? dishToUpdate.Name;
            dishToUpdate.Price = dish.Price ?? dishToUpdate.Price;
            dishToUpdate.CanBeDelivered = dish.CanBeDelivered ?? dishToUpdate.CanBeDelivered;
        }

        public async Task UpdateRestaurantAsync(int restaurantId, RestaurantEntity restaurant)
        {
            //_dbContext.Entry(restaurant).State = EntityState.Modified;

            var restaurantToUpdate = await _dbContext.Restaurants.FirstAsync(r => r.Id == restaurantId);

            restaurantToUpdate.Name = restaurant.Name ?? restaurantToUpdate.Name;
            restaurantToUpdate.Address = restaurant.Address ?? restaurantToUpdate.Address;
            restaurantToUpdate.Founded = restaurant.Founded ?? restaurantToUpdate.Founded;
            restaurantToUpdate.Phone = restaurant.Phone ?? restaurantToUpdate.Phone;
        }
    }
}
