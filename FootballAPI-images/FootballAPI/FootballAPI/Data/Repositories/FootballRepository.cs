using FootballAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data.Repositories
{
    public class FootballRepository : IFootballRepository
    {
        private FootballDbContext _dbContext;

        public FootballRepository(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public void CreatePlayer(long teamId, PlayerEntity newPlayer)
        {
            _dbContext.Entry(newPlayer.Team).State = EntityState.Unchanged;
            _dbContext.Players.Add(newPlayer);
            
        }

        public void CreateTeam(TeamEntity newTeam)
        {
            _dbContext.Teams.Add(newTeam);
        }

        public async Task DeletePlayerAsync(long teamId, long playerId)
        {
            var playerToDelete = await _dbContext.Players.FirstOrDefaultAsync(p => p.Id == playerId);
            _dbContext.Remove(playerToDelete);
        }

        public async Task DeleteTeamAsync(long teamId)
        {
            var teamToDelete = await _dbContext.Teams.FirstAsync(t => t.Id == teamId);
            _dbContext.Teams.Remove(teamToDelete);
            
        }

        public async Task<PlayerEntity> GetPlayerAsync(long teamId, long playerId)
        {
            IQueryable<PlayerEntity> query = _dbContext.Players;
            query = query.AsNoTracking();
            //query = query.Include(p => p.Team);
            return await query.FirstOrDefaultAsync(p => p.Team.Id == teamId && p.Id == playerId);
        }

        public async Task<IEnumerable<PlayerEntity>> GetPlayersAsync(long teamId)
        {
            IQueryable<PlayerEntity> query = _dbContext.Players;
            query = query.Where(p => p.Team.Id == teamId);
            query = query.Include(p => p.Team);
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<TeamEntity> GetTeamAsync(long teamId)
        {
            IQueryable<TeamEntity> query = _dbContext.Teams;
            query = query.AsNoTracking();
            query = query.Include(t => t.Players);
            return await query.FirstOrDefaultAsync(t => t.Id == teamId);

            //hit to database
            //tolist()
            //toArray()
            //foreach
            //firstOfDefaul
            //Single
            //Count
        }

        public async Task<IEnumerable<TeamEntity>> GetTeamsAsync(string orderBy = "Id")
        {
            IQueryable<TeamEntity> query = _dbContext.Teams;
            query = query.AsNoTracking();
            
            switch (orderBy.ToLower())
            {
                case "name":
                    query = query.OrderBy(t => t.Name);
                    break;
                case "city":
                    query = query.OrderBy(t => t.City);
                    break;
                default:
                    query = query.OrderBy(t => t.Id);
                    break;
            }

            return await query.ToListAsync();
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

        public async Task UpdatePlayerAsync(long teamId, long playerId, PlayerEntity updatedPlayer)
        {
            var playerToUpdate = await _dbContext.Players.FirstOrDefaultAsync(p =>  p.Id == playerId);
            playerToUpdate.LastName = updatedPlayer.LastName ?? playerToUpdate.LastName;
            playerToUpdate.Name = updatedPlayer.Name ?? playerToUpdate.Name;
            playerToUpdate.Number = updatedPlayer.Number ?? playerToUpdate.Number;
            playerToUpdate.Position = updatedPlayer.Position ?? playerToUpdate.Position;
            playerToUpdate.Salary = updatedPlayer.Salary ?? playerToUpdate.Salary;
        }

        public async Task UpdateTeamAsync(long teamId, TeamEntity updatedTeam)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.Id == teamId);

            team.Name = updatedTeam.Name ?? team.Name;
            team.City = updatedTeam.City ?? team.City;
            team.DTName = updatedTeam.DTName ?? team.DTName;
            team.FundationDate = updatedTeam.FundationDate ?? team.FundationDate;
        }
    }
}
