using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApi.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {

        private List<Person> people = new List<Person> { new Person() { Age = 22, Name = "Pedro" }, new Person() { Age = 33, Name = "Ana" } };
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            try
            {
                //throw new Exception("backend died");
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            return Ok(new Person() { Age = 22, Name = "Pedro" });
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Person value)
        {
            try
            {
                people.Add(value);
                return Created("new", value);
                //throw new Exception("from backend");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
