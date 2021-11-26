using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public interface ICompaniesService
    {
        Task<IEnumerable<CompanyModel>> GetCompaniesAsync(string orderBy, bool showVideogames);
        Task<CompanyModel> GetCompanyAsync(int companyId, bool showVideogames);
        Task<CompanyModel> CreateCompanyAsync(CompanyModel companyModel);
        Task<DeleteModel> DeleteCompanyAsync(int companyId);
        Task<CompanyModel> UpdateCompanyAsync(int companyId, CompanyModel companyModel);
    }
}

