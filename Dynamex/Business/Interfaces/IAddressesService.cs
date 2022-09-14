using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels.UpdateViewModels;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IAddressesService
    {
        Task<Addresses> GetAllAsync();
        Task<Addresses> Get(int id);
        Task UpdateTurkey(int id, AddressesUpdateViewModel model);
        Task UpdateUSA(int id, AddressesUpdateViewModel model);
        Task Remove(int id);
    }
}
