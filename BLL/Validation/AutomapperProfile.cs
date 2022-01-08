using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Validation
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Person, PersonModel>().ReverseMap();

            CreateMap<Pet, PetModel>().
                ForMember(p => p.PersonName, p2 => p2.MapFrom(src => src.Person.Name))
                .ReverseMap();
        }
    }
}
