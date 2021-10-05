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
    public class DishService : IDishService
    {
        private IRestaurantRepository _restaurantRepository;
        private IMapper _mapper;

        public DishService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<DishModel> CreateDishAsync(int restaurantId, DishModel dish)
        {
            await ValidateRestaurantAsync(restaurantId);
            dish.RestaurantId = restaurantId;
            var entity = _mapper.Map<DishEntity>(dish);
            _restaurantRepository.CreateDish(restaurantId, entity);
            var result = await _restaurantRepository.SaveChangesAsync();
            if (result)
            {
                return _mapper.Map<DishModel>(entity);
            }

            throw new Exception("Database Error.");
        }

        public async Task DeleteDishAsync(int restaurantId, int dishId)
        {
            await GetdishAsync(restaurantId, dishId);
            await _restaurantRepository.DeleteDishAsync(restaurantId, dishId);
            var result = await _restaurantRepository.SaveChangesAsync();
            if (!result)
            {
                throw new Exception("Database Error.");

            }
        }

        public async Task<DishModel> GetdishAsync(int restaurantId, int dishId)
        {
            await ValidateRestaurantAsync(restaurantId);

            var dish = await _restaurantRepository.GetdishAsync(restaurantId, dishId);
            if (dish == null)
                throw new NotFoundElementException($"the dish with id:{dishId} does not exists for the given restaurant with id: {restaurantId}.");

            return _mapper.Map<DishModel>(dish);

        }

        public async Task<IEnumerable<DishModel>> GetdishesAsync(int restaurantId)
        {
            await ValidateRestaurantAsync(restaurantId);
            var dishes = await _restaurantRepository.GetdishesAsync(restaurantId);
            return _mapper.Map<IEnumerable<DishModel>>(dishes);
        }

        public async Task<DishModel> UpdateDishAsync(int restaurantId, int dishId, DishModel dish)
        {
            await GetdishAsync(restaurantId, dishId);
            var entity = _mapper.Map<DishEntity>(dish);
            await _restaurantRepository.UpdateDishAsync(restaurantId, dishId, entity);
            var result = await _restaurantRepository.SaveChangesAsync();
            if (result)
            {
                return _mapper.Map<DishModel>(entity);
            }

            throw new Exception("Database Error.");
        }


        private async Task ValidateRestaurantAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(restaurantId);
            if (restaurant == null)
                throw new NotFoundElementException($"the restaurant with id:{restaurantId} does not exists.");
        }
    }
}
