using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Validation
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<Pet, PetDto>().
                ForMember(p => p.PersonName, p2 => p2.MapFrom(src => src.Person.Name))
                .ReverseMap();
        }
    }
}
