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
    [Route("api/[controller]")]
    public class RestaurantsController : Controller
    {
        private IRestaurantService _restaurantService;
        
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantModel>>> GetRestaurantsAsync(string direction, string orderBy = "Id")
        {
            try
            {
                var restaurants = await _restaurantService.GetRestaurantsAsync(orderBy);
                return Ok(restaurants);
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch(InvalidElementOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Simething happend.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RestaurantModel>> GetRestaurantAsync(int id, string showDishes)
        {
            try
            {
                bool showDishesBool;
                if (!Boolean.TryParse(showDishes, out showDishesBool))
                    showDishesBool = false;

                var restaurant = await _restaurantService.GetRestaurantAsync(id, showDishesBool);
                return Ok(restaurant);
            }
            catch (NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happend.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantModel>> PostRestaurantAsync([FromBody] RestaurantModel restaurant)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newRestaurant = await _restaurantService.CreateRestaurantAsync(restaurant);
                return Created($"/api/restaurants/{newRestaurant.Id}", newRestaurant);
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

        [HttpDelete("{restaurantId:int}")]
        public async Task<ActionResult> DeleteRestaurantAsync(int restaurantId)
        {
            try
            {
                await _restaurantService.DeleteRestaurantAsync(restaurantId);
                return Ok();
            }
            catch(NotFoundElementException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Simething happend.");
            } 
        }

        [HttpPut("{restaurantId:int}")]
        public async Task<ActionResult<RestaurantModel>> PutRestantAsync(int restaurantId, [FromBody] RestaurantModel restaurant)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (restaurant.Address != null && ModelState.ContainsKey("address") &&  ModelState["address"].Errors.Count > 0)
                    {
                        return BadRequest(ModelState["address"].Errors);
                    }
                }
                 

                var updatedRestaurant = await _restaurantService.UpdateRestaurantAsync(restaurantId, restaurant);
                return Ok(updatedRestaurant);
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
