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
        public async Task AddAsync(PersonModel model)
        {
            Person pToAdd = _mapper.Map<PersonModel, Person>(model);
            if(pToAdd != null && !string.IsNullOrEmpty(pToAdd.Name))
            {
                await _unitOfWork.PeopleRepository.AddAsync(pToAdd);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var pToDelete = await _unitOfWork.PeopleRepository.GetByIdAsync(modelId);
            if(pToDelete != null)
            {
                await _unitOfWork.PeopleRepository.DeleteByIdAsync(modelId);
                var f = _unitOfWork.PeopleRepository.FindAll();
                await _unitOfWork.SaveAsync();
                var p = _unitOfWork.PeopleRepository.FindAll();
            }
        }

        public IQueryable<PersonModel> GetAll()
        {
            return _unitOfWork.PeopleRepository.FindAll()
                .Select(x => _mapper.Map<Person, PersonModel>(x));
        }

        public async Task<PersonModel> GetByIdAsync(int id)
        {
            var pToGet = await _unitOfWork.PeopleRepository.GetByIdAsync(id);
            if (pToGet == null) return null;
            return _mapper.Map<Person, PersonModel>(pToGet);
        }

        public IQueryable<PersonModel> GetPeopleByName(string personName)
        {
            return _unitOfWork.PeopleRepository.FindAll()
                .Where(p => p.Name.ToLower() == personName.ToLower())
                .Select(x => _mapper.Map<Person, PersonModel>(x));
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

        public async Task UpdateAsync(PersonModel model)
        {
            var pExists = await _unitOfWork.PeopleRepository.GetByIdAsync(model.Id);
            if(pExists != null)
            {
                _unitOfWork.PeopleRepository.Update(_mapper.Map<PersonModel, Person>(model));
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
