using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public interface IPlayersService
    {
        public Task<IEnumerable<PlayerModel>> GetPlayersAsync(long teamId);
        public Task<PlayerModel> GetPlayerAsync(long teamId, long playerId);
        public Task<PlayerModel> CreatePlayerAsync(long teamId, PlayerModel newPlayer);
        public Task<bool> DeletePlayerAsync(long teamId, long playerId);
        public Task<PlayerModel> UpdatePlayerAsync(long teamId, long playerId, PlayerModel updatedPlayer);
    }
}
