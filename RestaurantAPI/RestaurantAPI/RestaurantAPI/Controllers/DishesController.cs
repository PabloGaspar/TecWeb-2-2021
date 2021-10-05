using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurants/{restaurantId:int}/[controller]")]
    public class DishesController : Controller
    {
        private IDishService _dishService;

        public DishesController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishModel>>> GetDishesAsync(int restaurantId)
        {
            try
            {
                return Ok(await _dishService.GetdishesAsync(restaurantId));
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Simething happend.");
            }
        }


        [HttpGet("{dishId:int}")]
        public async Task<ActionResult<DishModel>> GetDishAsync(int restaurantId, int dishId)
        {
            try
            {
                var dish = await _dishService.GetdishAsync(restaurantId, dishId);
                return Ok(dish);
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Simething happend.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DishModel>> PostDishAsync(int restaurantId, [FromBody] DishModel newDish)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var dish = await _dishService.CreateDishAsync(restaurantId, newDish);
                return Created($"/api/restaurants/{dish.RestaurantId}/dishes/{dish.Id}", dish);

            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Simething happend.");
            }
        }

        [HttpDelete("{dishId}")]
        public async Task<ActionResult> DeleteDishAsync(int restaurantId, int dishId)
        {
            try
            {
                await _dishService.DeleteDishAsync(restaurantId, dishId);
                return Ok();
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Simething happend.");
            }
        }

        [HttpPut("{dishId}")]
        public async Task<ActionResult<DishModel>> UpdateDishAsync(int restaurantId, int dishId, [FromBody] DishModel dish)
        {
            try
            {
                var updatedDish = await _dishService.UpdateDishAsync(restaurantId, dishId, dish);
                return Ok(updatedDish);
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Simething happend.");
            }
        }
    }
}
