using AutoMapper;
using FootballAPI.Data.Entities;
using FootballAPI.Data.Repositories;
using FootballAPI.Exceptions;
using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public class PlayersService : IPlayersService
    {
        private IFootballRepository _footballRepository;
        private IMapper _mapper;

        public PlayersService(IFootballRepository footballRepository, IMapper mapper)
        {
            _footballRepository = footballRepository;
            _mapper = mapper;
        }
        
        
        public async Task<PlayerModel> CreatePlayerAsync(long teamId, PlayerModel newPlayer)
        {
            await ValidateTeamAsync(teamId);
            newPlayer.TeamId = teamId;
            var playerEntity = _mapper.Map<PlayerEntity>(newPlayer);

            _footballRepository.CreatePlayer(teamId, playerEntity);

            var result = await _footballRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }

            return _mapper.Map<PlayerModel>(playerEntity);
        }

        public async Task<bool> DeletePlayerAsync(long teamId, long playerId)
        {
            await ValidateTeamAndPlaterAsync(teamId, playerId);
            await _footballRepository.DeletePlayerAsync(teamId, playerId);

            var result = await _footballRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }

            return true;
        }

        public async Task<PlayerModel> GetPlayerAsync(long teamId, long playerId)
        {
            await ValidateTeamAsync(teamId);
            var playerEntity = await _footballRepository.GetPlayerAsync(teamId, playerId);
            if (playerEntity == null)
            {
                throw new NotFoundItemException($"The player with id: {playerId} does not exist in team with id:{teamId}.");
            }
            
            var playerModel = _mapper.Map<PlayerModel>(playerEntity);

            playerModel.TeamId = teamId;
            return playerModel;
        }

        public async Task<IEnumerable<PlayerModel>> GetPlayersAsync(long teamId)
        {
            await ValidateTeamAsync(teamId);
            var players = await _footballRepository.GetPlayersAsync(teamId);
            return _mapper.Map<IEnumerable<PlayerModel>>(players);
        }

        public async Task<PlayerModel> UpdatePlayerAsync(long teamId, long playerId, PlayerModel updatedPlayer)
        {
            await ValidateTeamAndPlaterAsync(teamId, playerId);
            await _footballRepository.UpdatePlayerAsync(teamId, playerId, _mapper.Map<PlayerEntity>(updatedPlayer));
            var result = await _footballRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }

            return updatedPlayer;
        }

        private async Task ValidateTeamAsync(long teamId)
        {
            var team = await _footballRepository.GetTeamAsync(teamId);
            if (team == null)
            {
                throw new NotFoundItemException($"The team with id: {teamId} does not exists.");
            }
        }

        private async Task ValidateTeamAndPlaterAsync(long teamId, long playerId)
        {
            var player = await GetPlayerAsync(teamId, playerId);
        }
    }
}
