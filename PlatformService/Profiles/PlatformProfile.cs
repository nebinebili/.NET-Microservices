using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfile:Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<PlatformCreateDto,Platform>();
        }
    }
}
