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
    public class FilialService:IFilialService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FilialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Filial>> GetAllAsync()
        {
            return await _unitOfWork.filialRepository.GetAllAsync(p=>p.IsDeleted==false);
        }

        public async Task<Filial> Get(int id)
        {
            return await _unitOfWork.filialRepository.Get(pc => pc.Id == id&& pc.IsDeleted==false);
        }

        public async Task Create(FilialCreateViewModel filialCreateViewModel)
        {
            var newFilial = new Filial()
            {
                Name = filialCreateViewModel.Name
            };
            await _unitOfWork.filialRepository.CreateAsync(newFilial);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, FilialUpdateViewModel filialUpdateViewModel)
        {
            Filial dbCategory = await _unitOfWork.filialRepository.Get(b => b.Id == id);
            dbCategory.Name = filialUpdateViewModel.Name;
            await _unitOfWork.SaveAsync();
        }

        public async Task Remove(int id)
        {
            Filial dbFilial = await _unitOfWork.filialRepository.Get(b => b.Id == id);
            dbFilial.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }
    }
}
