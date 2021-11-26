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
    public class TeamsService : ITeamsService
    {

        private IFootballRepository _foootballRepository;
        private IMapper _mapper;

        private HashSet<string> _allowedOrderByValues = new HashSet<string>()
        {
            "id",
            "name",
            "city"
        };

        public TeamsService(IFootballRepository foootballRepository, IMapper mapper)
        {
            _foootballRepository = foootballRepository;
            _mapper = mapper;
        }

        public async Task<TeamModel> CreateTeamAsync(TeamModel newTeam)
        {
            var teamEntity = _mapper.Map<TeamEntity>(newTeam);
            _foootballRepository.CreateTeam(teamEntity);
            var result = await _foootballRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<TeamModel>(teamEntity);
            }

            throw new Exception("Database Error");
        }

        public async Task<bool> DeleteTeamAsync(long teamId)
        {
            await ValidateTeamAsync(teamId);
            await _foootballRepository.DeleteTeamAsync(teamId);
            var result = await _foootballRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }

        public async Task<TeamWithPlayerModel> GetTeamAsync(long teamId)
        {
            var team = await _foootballRepository.GetTeamAsync(teamId);

            if (team == null)
            {
                throw new NotFoundItemException($"The team with id: {teamId} does not exists.");
            }

            
            return _mapper.Map< TeamWithPlayerModel>(team);
        }

        public async Task<IEnumerable<TeamModel>> GetTeamsAsync(string orderBy = "Id")
        {
            if (!_allowedOrderByValues.Contains(orderBy.ToLower()))
                throw new InvalidOperationItemException($"The Orderby value: {orderBy} is invalid, please use one of {String.Join(',', _allowedOrderByValues.ToArray())}");
            var entityList = await _foootballRepository.GetTeamsAsync(orderBy.ToLower());
            var modelList = _mapper.Map<IEnumerable<TeamModel>>(entityList);
            return modelList;
        }

        public async Task<TeamModel> UpdateTeamAsync(long teamId, TeamModel updatedTeam)
        {
            await GetTeamAsync(teamId);
            updatedTeam.Id = teamId;
            await _foootballRepository.UpdateTeamAsync(teamId, _mapper.Map<TeamEntity>(updatedTeam));
            var result = await _foootballRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }

            return _mapper.Map<TeamModel>(updatedTeam);
        }

        private async Task ValidateTeamAsync(long teamId)
        {
             await GetTeamAsync(teamId);
        }
    }
}
