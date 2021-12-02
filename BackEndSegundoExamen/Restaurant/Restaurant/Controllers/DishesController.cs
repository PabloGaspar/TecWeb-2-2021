using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        private IDishesService _service;

        public DishesController(IDishesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDishes()
        {
            return Ok(_service.GetDishes());
        }

        [HttpPost]
        public IActionResult CreateDish([FromBody] Dish dish)
        {
            try
            {
                var newDish = _service.CreateDish(dish);
                return Created($"/api/dishes/{newDish.Id}", newDish);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpDelete("{dishId:long}")]
        public IActionResult DeleteDish(long dishId)
        {
            try
            {
                return Ok(_service.DeleteDish(dishId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
    }
}
