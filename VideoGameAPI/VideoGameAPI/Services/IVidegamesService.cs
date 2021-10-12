using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Models;

namespace VideoGameAPI.Services
{
    public interface IVidegamesService
    {
        Task<VideogameModel> CreateVideogameAsync(int CompanyId, VideogameModel videogame);
        Task<VideogameModel> GetVidegameAsync(int CompanyId, int videogameId);
        Task<IEnumerable<VideogameModel>> GetVidegamesAsync(int CompanyId);
        Task<bool> UpdateVideogameAsync(int companyId, int videogameId, VideogameModel videogame);
        Task<bool> DeleteVideogameAsync(int CompanyId, int videogameId);
    }
}
