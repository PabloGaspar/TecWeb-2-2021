using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameAPI.Exceptions;
using VideoGameAPI.Models;
using VideoGameAPI.Services;

namespace VideoGameAPI.Controllers
{
    [Route("api/companies/{companyId:int}/[controller]")]
    public class VideogamesController : ControllerBase
    {
        private IVidegamesService _videogameService;

        public VideogamesController(IVidegamesService videogameService)
        {
            _videogameService = videogameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideogameModel>>> GetVideogames(int companyId)
        {
            try
            {
                return  Ok(await _videogameService.GetVidegamesAsync(companyId));
            }
            catch(NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpGet("{videogameId:int}",  Name="GetVideogame")]
        public async Task<ActionResult<VideogameModel>> GetVideogameAsync(int companyId, int videogameId)
        {
            try
            {
                return Ok(await _videogameService.GetVidegameAsync(companyId, videogameId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VideogameModel>> CreateVideogameAsync(int companyId, [FromBody] VideogameModel videogame)
        {
            try
            {
                var videogameCreated = await _videogameService.CreateVideogameAsync(companyId, videogame);
                return CreatedAtRoute("GetVideogame",  new { companyId = companyId , videogameId = videogameCreated.Id}, videogameCreated);
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpPut("{videogameId:int}")]
        public async Task<ActionResult<VideogameModel>> UpdateVideogameAsync(int companyId, int videogameId, [FromBody] VideogameModel videogame)
        {
            try
            {
                return Ok(await _videogameService.UpdateVideogameAsync(companyId, videogameId, videogame));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpDelete("{videogameId:int}")]
        public async Task<ActionResult<bool>> DeleteVideogameAsync(int companyId, int videogameId)
        {
            try
            {
                return Ok(await _videogameService.DeleteVideogameAsync(companyId, videogameId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
    }
}
