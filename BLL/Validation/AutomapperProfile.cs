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

            CreateMap<Pet, PetModel>().ReverseMap();
        }
    }
}
