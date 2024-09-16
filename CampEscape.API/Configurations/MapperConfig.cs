using AutoMapper;
using CampEscape.API.DTOs;
using System.Drawing;

namespace CampEscape.API.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Region, CreateRegionDTO>().ReverseMap();
        CreateMap<Region, GetRegionDTO>().ReverseMap();
    }
}
