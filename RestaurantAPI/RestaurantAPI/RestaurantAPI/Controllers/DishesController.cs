using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurants/{restaurantId}/[controller]")]
    public class DishesController : Controller
    {
        [HttpGet]
        public ActionResult<DishModel> GetDishes(int restaurantId)
        {

        }
    }
}
