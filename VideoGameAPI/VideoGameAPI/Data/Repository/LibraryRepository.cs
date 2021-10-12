using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;

namespace VideoGameAPI.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private LibraryDbContext _dbContext;

        public LibraryRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // companies
        public void CreateCompany(CompanyEntity company)
        {
            _dbContext.Companies.Add(company);
        }

        public async Task<bool> DeleteCompanyAsync(int companyId)
        {

            var companyToDelete = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
            _dbContext.Companies.Remove(companyToDelete);
         
            /*var companyToDelete = new CompanyEntity() { Id = companyId };
            _dbContext.Companies.Attach(companyToDelete);
            _dbContext.Entry(companyToDelete).State = EntityState.Deleted;*/

            return true;
        }

        public async Task<IEnumerable<CompanyEntity>> GetCompaniesAsync(string orderBy, bool showVideogames = false)
        {
            IQueryable<CompanyEntity> query = _dbContext.Companies;
            query = query.AsNoTracking();

            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(c => c.Id);
                    break;
                case "name":
                    query = query.OrderBy(c => c.Name);
                    break;
                case "fundation-date":
                    query = query.OrderBy(c => c.FundationDate);
                    break;
                case "country":
                    query = query.OrderBy(c => c.Country);
                    break;
                default:
                    query = query.OrderBy(c => c.Id); ;
                    break;
            }
            return await query.ToListAsync();
        }

        public async Task<CompanyEntity> GetCompanyAsync(int companyId, bool showVideogames = false)
        {
            IQueryable<CompanyEntity> query = _dbContext.Companies;
            query = query.AsNoTracking();

            if (showVideogames)
            {
                query = query.Include(c => c.Videogames);
            }

            //tolist()
            //toArray()
            //foreach
            //firstOfDefaul
            //Single
            //Count

            return await query.FirstOrDefaultAsync(c => c.Id == companyId);
        }

        public bool UpdateCompany(CompanyEntity companyModel)
        {
            var companyToUpdate = _dbContext.Companies.FirstOrDefault(c => c.Id == companyModel.Id);

            _dbContext.Entry(companyToUpdate).CurrentValues.SetValues(companyModel);

            /*if (companyModel.Name != null)
            {
                _dbContext.Entry(companyModel).Property(p => p.Name).IsModified = true;
            }*/

            /*companyToUpdate.CEO = companyModel.CEO ?? companyToUpdate.CEO;
            companyToUpdate.Country = companyModel.Country ?? companyToUpdate.Country;
            companyToUpdate.FundationDate = companyModel.FundationDate ?? companyToUpdate.FundationDate;
            companyToUpdate.Name = companyModel.Name ?? companyToUpdate.Name;*/
            return true;
        }

        public void CreateVideogame(VideoGameEntity videoGame)
        {
            if (videoGame.Company != null)
            {
                _dbContext.Entry(videoGame.Company).State = EntityState.Unchanged;
            }
            _dbContext.Videogames.Add(videoGame);
        }

        public async Task<VideoGameEntity> GetVideogameAsync(int videogameId)
        {
            IQueryable<VideoGameEntity> query = _dbContext.Videogames;
            query = query.Include(v => v.Company);
            query = query.AsNoTracking();
            var videogame = await query.SingleOrDefaultAsync(v => v.Id == videogameId);
            return videogame;
        }

        public async Task<IEnumerable<VideoGameEntity>> GetVideoGamesAsync(int companyId)
        {
            IQueryable<VideoGameEntity> query = _dbContext.Videogames;
            query = query.Where(v => v.Company.Id == companyId);
            query = query.Include(v => v.Company);
            query = query.AsNoTracking();

            return await query.ToArrayAsync(); ;
        }

        public async Task<bool> UpdateVideogameAsync(VideoGameEntity videoGame)
        {
            var videogameToUpdate = await _dbContext.Videogames.FirstOrDefaultAsync(v => v.Id == videoGame.Id);
            videogameToUpdate.Name = videoGame.Name ?? videogameToUpdate.Name;
            videogameToUpdate.Price = videoGame.Price?? videogameToUpdate.Price;
            videogameToUpdate.ReleaseDate = videoGame.ReleaseDate ?? videogameToUpdate.ReleaseDate;
            videogameToUpdate.Genre = videoGame.Genre ?? videogameToUpdate.Genre;
            videogameToUpdate.ESRB = videoGame.ESRB ?? videogameToUpdate.ESRB;
            return true;
        }

        public bool DeleteVideogame(int videogameId)
        {
            var videogameToDelete = new VideoGameEntity() { Id = videogameId };
            _dbContext.Entry(videogameToDelete).State = EntityState.Deleted;
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
