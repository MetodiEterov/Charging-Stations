using AutoMapper;

using Entities.DTOs;
using Entities.Models;

namespace ASP.NETTask.WebAPI.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ChargePointDto, ChargePoint>()
                .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => src.LastUpdated));
            CreateMap<ChargePointRequestModelDto, ChargePointRequestModel>();
            CreateMap<PatchLocationRequestModelDto, PatchLocationRequestModel>();
            CreateMap<LocationRequestModelDto, LocationRequestModel>();
        }
    }
}
