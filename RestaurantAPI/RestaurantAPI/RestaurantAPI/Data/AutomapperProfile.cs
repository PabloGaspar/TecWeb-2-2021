using AutoMapper;
using RestaurantAPI.Data.Entities;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<RestaurantEntity, RestaurantModel>()
                //.ForMember( des => des.Phone, opt => opt.MapFrom(src => src.Phone + "#" + src.Name ))
                .ReverseMap();

            this.CreateMap<DishEntity, DishModel>()
                .ForMember(mod => mod.RestaurantId, ent => ent.MapFrom(entSrc => entSrc.Restaurant.Id))
                .ReverseMap()
                .ForMember(ent => ent.Restaurant, mod => mod.MapFrom(modSrc => new RestaurantEntity() { Id = modSrc.RestaurantId }));
            
        }
    }
}
