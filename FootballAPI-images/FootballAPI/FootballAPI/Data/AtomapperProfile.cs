using AutoMapper;
using FootballAPI.Data.Entities;
using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data
{
    public class AtomapperProfile: Profile
    {
        public AtomapperProfile()
        {
            this.CreateMap<TeamModel, TeamEntity>()
                //.ForMember(tm => tm.Name, te => te.MapFrom(m => m.Name))
                .ReverseMap();

            this.CreateMap<PlayerModel, PlayerEntity>()
                .ForMember(ent => ent.Team, mod => mod.MapFrom(modSrc => new TeamEntity() { Id = modSrc.TeamId }))
                .ReverseMap()
                .ForMember(mod => mod.TeamId, ent => ent.MapFrom(entSrc => entSrc.Team.Id));

            this.CreateMap<TeamWithPlayerModel, TeamEntity>()
                .ReverseMap();
        }
    }
}
