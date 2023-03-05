using AutoMapper;
using MgDbDemo.Dtos;
using MgDbDemo.Entities;

namespace MgDbDemo.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDto, Book>().ReverseMap();
        CreateMap<UpdateBookDto, Book>()
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ReverseMap();
    }
}