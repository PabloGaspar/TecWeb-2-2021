using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Exceptions;
using VideoGameAPI.Models;
using VideoGameAPI.Services;

namespace VideoGameAPI.Controllers
{
    //[Authorize()]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {

        private ICompaniesService _companyService;
        
        public CompaniesController(ICompaniesService companyService)
        {
            this._companyService = companyService; 
        }
        
        //api/companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyModel>>> GetCompaniesAsync(string orderBy = "Id", bool showVideogames = false) 
        {
            try
            {
                var user = User;
                return Ok(await _companyService.GetCompaniesAsync(orderBy, showVideogames));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        //api/companies/companiId
        [HttpGet("{companyId:int}", Name = "GetCompany")]
        public async Task<ActionResult<CompanyModel>> GetCompanyAync(int companyId, bool showVideogames = false)
        {
            try
            {
                return await _companyService.GetCompanyAsync(companyId, showVideogames);
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message); ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CompanyModel>> CreateCompanyAsync([FromBody] CompanyModel companyModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }   
                
                var url = HttpContext.Request.Host;
                var newCompany = await _companyService.CreateCompanyAsync(companyModel);
                return CreatedAtRoute("GetCompany", new { companyId = newCompany.Id }, newCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpDelete("{companyId:int}")]
        public async Task<ActionResult<DeleteModel>> DeletecompanyAsync(int companyId)
        {
            try
            {
                return Ok(await _companyService.DeleteCompanyAsync(companyId));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message);;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

        [HttpPut("{companyId:int}")]
        public async Task<IActionResult> UpdateCompanyAsync(int companyId, [FromBody] CompanyModel companyModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(companyModel.Country) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }

                return Ok(await _companyService.UpdateCompanyAsync(companyId, companyModel));
            }
            catch (NotFoundOperationException ex)
            {
                return NotFound(ex.Message); ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }


    }
}
