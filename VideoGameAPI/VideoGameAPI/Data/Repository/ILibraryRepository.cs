using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;

namespace VideoGameAPI.Data.Repository
{
    public interface ILibraryRepository
    {
        //companies
        Task<IEnumerable<CompanyEntity>> GetCompaniesAsync(string orderBy, bool showVideogames = false);
        Task<CompanyEntity> GetCompanyAsync(int companyId, bool showVideogames = false);
        void CreateCompany(CompanyEntity companyModel);
        Task<bool> DeleteCompanyAsync(int companyId);
        bool UpdateCompany(CompanyEntity companyModel);

        //videogames 
        void CreateVideogame(VideoGameEntity videoGame);
        Task<VideoGameEntity> GetVideogameAsync(int videogameId);
        Task<IEnumerable<VideoGameEntity>> GetVideoGamesAsync(int companyId);
        Task<bool> UpdateVideogameAsync(VideoGameEntity videoGame);
        bool DeleteVideogame(int videogameId);

        //save changes
        Task<bool> SaveChangesAsync();
    }
}
