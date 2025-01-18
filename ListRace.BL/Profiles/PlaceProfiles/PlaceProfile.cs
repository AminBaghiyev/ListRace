using AutoMapper;
using ListRace.BL.DTOs;
using ListRace.Core.Models;

namespace ListRace.BL.Profiles;

public class PlaceProfile : Profile
{
    public PlaceProfile()
    {
        CreateMap<PlaceCreateDTO, Place>().ReverseMap();
        CreateMap<PlaceUpdateDTO, Place>().ReverseMap();
        CreateMap<PlaceListItemDTO, Place>()
            .ReverseMap()
            .ForMember(dest => dest.CategoryTitle, options => options.MapFrom(src => src.Category.Title));

        CreateMap<PlaceViewItemDTO, Place>()
            .ReverseMap()
            .ForMember(dest => dest.CategoryTitle, options => options.MapFrom(src => src.Category.Title));
    }
}
