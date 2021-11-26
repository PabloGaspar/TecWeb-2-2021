using FootballAPI.Exceptions;
using FootballAPI.Models;
using FootballAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace FootballAPI.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        
        private ITeamsService _teamsService;
        private IFileService _fileService;

        public TeamsController(ITeamsService teamsService, IFileService fileService)
        {
            _teamsService = teamsService;
            _fileService = fileService;
        }

        // api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamModel>>> GetTeamsAsync(string orderBy = "Id")
        {
            try
            {
                var teams = await _teamsService.GetTeamsAsync(orderBy);
                return Ok(teams);
            }
            catch(InvalidOperationItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        // api/teams/2
        [HttpGet("{teamId:long}")]
        public async Task<ActionResult<TeamWithPlayerModel>> GetTeamAsync(long teamId)
        {
            try
            {
                var team = await _teamsService.GetTeamAsync(teamId);
                return Ok(team);
            }
            catch(NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        // api/teams
        [HttpPost("Form")]
        public async Task<ActionResult<TeamModel>> CreateTeamFormAsync([FromForm] TeamFormModel newTeam)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var file = newTeam.Image;
                string imagePath = _fileService.UploadFile(file);

                newTeam.ImagePath = imagePath;

                var team = await _teamsService.CreateTeamAsync(newTeam);
                return Created($"/api/teams/{team.Id}", team);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> CreateTeamAsync([FromBody] TeamModel newTeam)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var team = await _teamsService.CreateTeamAsync(newTeam);
                return Created($"/api/teams/{team.Id}", team);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }

        [HttpDelete("{teamId:long}")]
        public async Task<ActionResult<bool>> DeleteTeamAsync(long teamId)
        {
            try
            {
                var result = await _teamsService.DeleteTeamAsync(teamId);
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

        [HttpPut("{teamId:long}")]
        public async Task<ActionResult<TeamModel>> UpdateTeamAsync(long teamId, [FromBody] TeamModel updatedTeam)
        {
            try
            {
                /*if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(updatedTeam.City) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }*/
                
                var team = await _teamsService.UpdateTeamAsync(teamId, updatedTeam);
                return Ok(team);
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
