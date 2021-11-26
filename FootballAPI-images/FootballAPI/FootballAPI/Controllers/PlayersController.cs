using FootballAPI.Exceptions;
using FootballAPI.Models;
using FootballAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Controllers
{
    [Route("api/teams/{teamId:long}/[controller]")]
    public class PlayersController : ControllerBase
    {

        private IPlayersService _playerService;

        public PlayersController(IPlayersService playerService)
        {
            _playerService = playerService;
        }

        //localhost:3030/api/teams/{teamId:long}/players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerModel>>> GetPlayersAsync(long teamId)
        {
            try
            {
                var players = await _playerService.GetPlayersAsync(teamId);
                return Ok(players);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpGet("{playerId:long}")]
        public async Task<IActionResult> GetPlayerAsync(long teamId, long playerId)
        {
            try
            {
                var player = await _playerService.GetPlayerAsync(teamId, playerId);
                return Ok(player);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }

        }

        [HttpPost]
        public async Task<ActionResult<PlayerModel>> CreatePlayerAsync(long teamId, [FromBody] PlayerModel newPlayer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdPlayer = await _playerService.CreatePlayerAsync(teamId, newPlayer);
                return Created($"/api/teams/{teamId}/players/{createdPlayer.Id}", createdPlayer);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpDelete("{playerId:int}")]
        public async Task<ActionResult<bool>> DeletePlayerAsync(long teamId, long playerId)
        {
            try
            {
                var result = await _playerService.DeletePlayerAsync(teamId, playerId);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpPut("{playerId:long}")]
        public async Task<ActionResult<PlayerModel>> UpdatePlayerAsync(long teamId, long playerId, [FromBody] PlayerModel playerToUpdate)
        {
            try
            {
                var updatedPayer = await _playerService.UpdatePlayerAsync(teamId, playerId, playerToUpdate);
                return Ok(updatedPayer);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

    }
}
