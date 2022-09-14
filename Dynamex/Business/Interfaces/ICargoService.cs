using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels.CreateViewModels;
using Business.ViewModels.UpdateViewModels;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ICargoService
    {
        Task<List<Cargo>> GetAllAsync();
        Task<List<Cargo>> GetAllOrderCargo(string UserId);
        Task<Cargo> Get(int id);
        Task Create(CargoCreateViewModel model);
        Task Update(int id, CargoUpdateViewModel model);
        Task Remove(int id);
        Task Send(int id);
        Task SenderCustoms(int id);
        Task SenderFilial(int id);
        Task Delivered(int id);
        Task DollarPay(int id,ApplicationUser user);
        Task DollarBalance(ApplicationUser user,decimal dollar);
        Task TLPay(int id,ApplicationUser user);
        Task TLBalance(ApplicationUser user,decimal tl);
    }
}
