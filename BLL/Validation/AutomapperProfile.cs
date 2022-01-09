using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System.Linq;

namespace BLL.Validation
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(p => p.PetsIds, p2 => p2.MapFrom(src => src.Pets.Select(x => x.Id)))
                .ReverseMap();

            CreateMap<Pet, PetDto>().
                ForMember(p => p.PersonName, p2 => p2.MapFrom(src => src.Person.Name))
                .ReverseMap();
        }
    }
}
