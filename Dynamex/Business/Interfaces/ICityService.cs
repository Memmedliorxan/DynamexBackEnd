using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels.CreateViewModels;
using Business.ViewModels.UpdateViewModels;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetAllAsync();
        Task<City> Get(int id);
        Task Create(CityCreateViewModel cityCreateViewModel);
        Task Update(int id, CityUpdateViewModel cityUpdateViewModel);
        Task Remove(int id);
    }
}
