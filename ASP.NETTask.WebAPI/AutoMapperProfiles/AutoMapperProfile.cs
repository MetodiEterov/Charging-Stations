namespace ASP.NETTask.WebAPI.AutoMapperProfiles
{
    using AutoMapper;

    using Entities.DTOs;
    using Entities.Models;

    /// <summary>
    /// AutoMapperProfile class
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// AutoMapperProfile constructor
        /// </summary>
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
