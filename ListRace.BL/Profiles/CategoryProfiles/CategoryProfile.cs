using AutoMapper;
using ListRace.BL.DTOs;
using ListRace.Core.Models;

namespace ListRace.BL.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
        CreateMap<CategoryListItemDTO, Category>().ReverseMap();
        CreateMap<CategoryViewItemDTO, Category>()
            .ReverseMap()
            .ForMember(dest => dest.Listings, options => options.MapFrom(src => src.Places.Count));
    }
}
