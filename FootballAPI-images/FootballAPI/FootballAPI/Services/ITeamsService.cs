using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public interface ITeamsService
    {
        public Task<IEnumerable<TeamModel>> GetTeamsAsync(string orderBy = "Id");
        public Task<TeamWithPlayerModel> GetTeamAsync(long teamId);
        public Task<TeamModel> CreateTeamAsync(TeamModel newTeam);
        public Task<bool> DeleteTeamAsync(long teamId);
        public Task<TeamModel> UpdateTeamAsync(long teamId, TeamModel updatedTeam);
    }
}
