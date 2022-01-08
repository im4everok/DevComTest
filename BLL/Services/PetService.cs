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
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(PetDto model)
        {
            var petToCheck = _unitOfWork.PetRepository
                .FindAll()
                .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());

            bool notDuplicate = petToCheck is null;
            if (notDuplicate)
            {
                await _unitOfWork.PetRepository.AddAsync(_mapper.Map<PetDto, Pet>(model));
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            bool petExists = await _unitOfWork.PetRepository.GetByIdAsync(modelId) != null;
            if (petExists)
            {
                await _unitOfWork.PetRepository.DeleteByIdAsync(modelId);
                await _unitOfWork.SaveAsync();
            }
        }

        public IQueryable<PetDto> GetAll()
        {
            return _unitOfWork.PetRepository.FindAll().Select(x => _mapper.Map<Pet, PetDto>(x));
        }

        public async Task<PetDto> GetByIdAsync(int id)
        {
            var toRet = await _unitOfWork.PetRepository.GetByIdAsync(id);
            return _mapper.Map<Pet, PetDto>(toRet);
        }

        public IQueryable<PetDto> GetUserPets(int userId)
        {
            IQueryable<Pet> userPets = _unitOfWork.PetRepository.FindAll()
                .Where(x => x.PersonId == userId);
            return userPets.Select(x => _mapper.Map<Pet, PetDto>(x));
        }

        public async Task UpdateAsync(PetDto model)
        {
            _unitOfWork.PetRepository.Update(_mapper.Map<PetDto, Pet>(model));
            await _unitOfWork.SaveAsync();
        }
    }
}
