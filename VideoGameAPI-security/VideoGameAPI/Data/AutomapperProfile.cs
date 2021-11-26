using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;
using VideoGameAPI.Models;

namespace VideoGameAPI.Data
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<CompanyEntity, CompanyModel>()
                .ReverseMap();


            this.CreateMap<VideogameModel, VideoGameEntity>()
                .ForMember(des => des.Company, opt => opt.MapFrom(scr => new CompanyEntity { Id = scr.CompanyId }))  
                .ReverseMap()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(scr => scr.Company.Id));
            //this.CreateMap<Camp, CampModel>()
            //  .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName))
            //  .ReverseMap();

            //this.CreateMap<Talk, TalkModel>()
            //  .ReverseMap()
            //  .ForMember(t => t.Camp, opt => opt.Ignore())
            //  .ForMember(t => t.Speaker, opt => opt.Ignore());
        }
    }
}
