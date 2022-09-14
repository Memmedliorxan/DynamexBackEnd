using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.ViewModels.CreateViewModels;
using Core.Entities;

namespace Business.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> Get(int id);
        Task Create(OrderCreateViewModel model,ApplicationUser user);
        Task Remove(int id);
        Task GetOrdered(int id);
    }
}
