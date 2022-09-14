using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.CreateViewModels;
using Business.ViewModels.UpdateViewModels;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class CityServices : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<City>> GetAllAsync()
        {
            return await _unitOfWork.cityRepository.GetAllAsync(p => p.IsDeleted == false);
        }

        public async Task<City> Get(int id)
        {
            return await _unitOfWork.cityRepository.Get(pc => pc.Id == id && pc.IsDeleted == false);
        }

        public async Task Create(CityCreateViewModel cityCreateViewModel)
        {
            var newFilial = new City()
            {
                Name = cityCreateViewModel.Name
            };
            await _unitOfWork.cityRepository.CreateAsync(newFilial);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, CityUpdateViewModel cityUpdateViewModel)
        {
            City dbCategory = await _unitOfWork.cityRepository.Get(b => b.Id == id);
            dbCategory.Name = cityUpdateViewModel.Name;
            await _unitOfWork.SaveAsync();
        }

        public async Task Remove(int id)
        {
            City dbFilial = await _unitOfWork.cityRepository.Get(b => b.Id == id);
            dbFilial.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }
    }
}
