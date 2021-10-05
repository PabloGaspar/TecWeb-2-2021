using AutoMapper;
using RestaurantAPI.Data.Entities;
using RestaurantAPI.Data.Repository;
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

        private IRestaurantRepository _restaurantRepository;
        private IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        private HashSet<string> _allowedSortValues = new HashSet<string> { "id", "name", "address" };
        

        public async Task<RestaurantModel> CreateRestaurantAsync(RestaurantModel restaurant)
        {
            var restaurantEntity = _mapper.Map<RestaurantEntity>(restaurant);
             _restaurantRepository.CreateRestaurant(restaurantEntity);
            var result = await _restaurantRepository.SaveChangesAsync();
            if (result)
            {
                return _mapper.Map<RestaurantModel>(restaurantEntity);
            }

            throw new Exception("Database Error.");
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            await GetRestaurantAsync(restaurantId);
            await _restaurantRepository.DeleteRestaurantAsync(restaurantId);
            var result = await _restaurantRepository.SaveChangesAsync();
            if (!result)
            {
                throw new Exception("Database Error.");
            }
        }

        public async Task<RestaurantModel> GetRestaurantAsync(int restaurantId, bool showRestaurant = false)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(restaurantId, showRestaurant);

            if (restaurant == null)
                throw new NotFoundElementException($"the restaurant with id:{restaurantId} does not exists.");
            
            return _mapper.Map<RestaurantModel> (restaurant);
        }

        public async Task<IEnumerable<RestaurantModel>> GetRestaurantsAsync(string orderBy = "id")
        {
            if (!_allowedSortValues.Contains(orderBy.ToLower()))
                throw new InvalidElementOperationException($"invalid orderBy value : {orderBy}. The allowed values for param are: {string.Join(',', _allowedSortValues)}");

            var restaurantEntityList =  await _restaurantRepository.GetRestaurantsAsync(orderBy);
            return _mapper.Map<IEnumerable<RestaurantModel>>(restaurantEntityList);
        }

        public async Task<RestaurantModel> UpdateRestaurantAsync(int restaurantId, RestaurantModel restaurant)
        {
            await GetRestaurantAsync(restaurantId);
            var restaurantEntity = _mapper.Map<RestaurantEntity>(restaurant);
            await _restaurantRepository.UpdateRestaurantAsync(restaurantId, restaurantEntity);
            var result = await _restaurantRepository.SaveChangesAsync();
            if (result)
            {
                return _mapper.Map<RestaurantModel>(restaurantEntity);
            }

            throw new Exception("Database Error.");
        }
    }
}
