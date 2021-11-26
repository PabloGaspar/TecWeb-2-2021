using FootballAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data.Repositories
{
    public interface IFootballRepository
    {

        //teams
        public Task<IEnumerable<TeamEntity>> GetTeamsAsync(string orderBy = "Id");
        public Task<TeamEntity> GetTeamAsync(long teamId);
        public void CreateTeam(TeamEntity newTeam);
        public Task DeleteTeamAsync(long teamId);
        public Task UpdateTeamAsync(long teamId, TeamEntity updatedTeam);

        //players
        public Task<IEnumerable<PlayerEntity>> GetPlayersAsync(long teamId);
        public Task<PlayerEntity> GetPlayerAsync(long teamId, long playerId);
        public void CreatePlayer(long teamId, PlayerEntity newPlayer);
        public Task DeletePlayerAsync(long teamId, long playerId);
        public Task UpdatePlayerAsync(long teamId, long playerId, PlayerEntity updatedPlayer);

        Task<bool> SaveChangesAsync();
    }
}
