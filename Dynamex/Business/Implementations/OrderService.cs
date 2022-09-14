using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.CreateViewModels;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Business.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task Create(OrderCreateViewModel model,ApplicationUser user)
        {
            var newOrder = new Order()
            {
                Detall = model.Detall,
                Link = model.Link,
                Color = model.Color,
                Price = model.Price,
                CargoPrice = model.CargoPrice,
                Count = model.Count,
                Size = model.Size,
                ApplicationUserId = user.Id,

            };
            user.TLBalance = user.TLBalance - (model.Price + model.CargoPrice);
            newOrder.Date = DateTime.Now;
            await _unitOfWork.orderRepository.CreateAsync(newOrder);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Order> Get(int id)
        {
            return await _unitOfWork.orderRepository.Get(pc => pc.Id == id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _unitOfWork.orderRepository.GetAllAsync();

        }

        public async Task GetOrdered(int id)
        {
            var send = await _unitOfWork.orderRepository.Get(p => p.Id == id);
            send.IsOrder = true;
            send.Date = DateTime.Now;
            await _unitOfWork.SaveAsync();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
