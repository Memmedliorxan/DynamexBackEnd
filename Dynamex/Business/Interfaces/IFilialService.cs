using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels.CreateViewModels;
using Business.ViewModels.UpdateViewModels;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IFilialService
    {
        Task<List<Filial>> GetAllAsync();
        Task<Filial> Get(int id);
        Task Create(FilialCreateViewModel filialCreateViewModel);
        Task Update(int id, FilialUpdateViewModel filialUpdateViewModel);
        Task Remove(int id);
    }
}
