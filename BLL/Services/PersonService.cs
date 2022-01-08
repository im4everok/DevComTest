using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _unitOfWork = uow; 
        }
        public async Task AddAsync(PersonDto model)
        {
            Person pToAdd = _mapper.Map<PersonDto, Person>(model);
            if(pToAdd != null && !string.IsNullOrEmpty(pToAdd.Name))
            {
                await _unitOfWork.PeopleRepository.AddAsync(pToAdd);
                await _unitOfWork.SaveAsync();
            }
        }
        /// <summary>
        /// If i ever want to implement relationship of Pets to PetOwner via explicit loading (Adding pet to PetOwner's ICollection<Pet>)
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task AddPetToPersonAsync(int ownerId, PetDto model)
        {
            var pExists = await _unitOfWork.PeopleRepository.GetByIdAsync(ownerId);
            if(pExists != null)
            {
                if(pExists.Pets == null)
                {
                    pExists.Pets = new List<Pet>();
                }
                pExists.Pets.Add(_mapper.Map<PetDto, Pet>(model));
                _unitOfWork.PeopleRepository.Update(pExists);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var pToDelete = await _unitOfWork.PeopleRepository.GetByIdAsync(modelId);
            if(pToDelete != null)
            {
                await _unitOfWork.PeopleRepository.DeleteByIdAsync(modelId);
                await _unitOfWork.SaveAsync();
            }
        }

        public IQueryable<PersonDto> GetAll()
        {
            return _unitOfWork.PeopleRepository.FindAll()
                .Select(x => _mapper.Map<Person, PersonDto>(x));
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var pToGet = await _unitOfWork.PeopleRepository.GetByIdAsync(id);
            if (pToGet == null) return null;
            return _mapper.Map<Person, PersonDto>(pToGet);
        }

        public IQueryable<PersonDto> GetPeopleByName(string personName)
        {
            return _unitOfWork.PeopleRepository.FindAll()
                .Where(p => p.Name.ToLower() == personName.ToLower())
                .Select(x => _mapper.Map<Person, PersonDto>(x));
        }

        public async Task<int> GetPersonPetCountAsync(int personId)
        {
            var pToCount = await _unitOfWork.PeopleRepository.GetByIdAsync(personId);
            if (pToCount != null)
            {
                return _unitOfWork.PetRepository.FindAll()
                    .Where(x => x.PersonId == personId)
                    .ToList()
                    .Count;
            }
            return 0;
        }

        public async Task UpdateAsync(PersonDto model)
        {
            var pExists = await _unitOfWork.PeopleRepository.GetByIdAsync(model.Id);
            if(pExists != null)
            {
                _unitOfWork.PeopleRepository.Update(_mapper.Map<PersonDto, Person>(model));
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
