using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            }
        }

        public IEnumerable<PersonModel> GetAll()
        {
            return _unitOfWork.PeopleRepository.FindAll().Select(x => _mapper.Map<Person, PersonModel>(x)).ToList();
        }

        public async Task<PersonModel> GetByIdAsync(int id)
        {
            var pToGet = await _unitOfWork.PeopleRepository.GetByIdAsync(id);
            if (pToGet == null) return null;
            return _mapper.Map<Person, PersonModel>(pToGet);
        }

        public async Task<int> GetPersonPetCountAsync(int personId)
        {
            var pToCount = await _unitOfWork.PeopleRepository.GetByIdAsync(personId);
            if (pToCount != null && pToCount.Pets != null)
            {
                return pToCount.Pets.Count;
            }
            return 0;
        }

        public Task UpdateAsync(PersonModel model)
        {
            throw new NotImplementedException();
        }
    }
}
