using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.CreateViewModels;
using Business.ViewModels.UpdateViewModels;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Business.Implementations
{
    public class CargoService:ICargoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CargoService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<List<Cargo>> GetAllAsync()
        {
            return await _unitOfWork.cargoRepository.GetAllAsync(p => p.IsDeleted == false,"ApplicationUser");
        }

        public async Task<Cargo> Get(int id)
        {
            return await _unitOfWork.cargoRepository.Get(pc => pc.Id == id);
        }

        public async Task Create(CargoCreateViewModel model)
        {
            var newCargo = new Cargo()
            {
                Name = model.Name,
                TrackId = model.TrackId,
                Weight = model.Weight,
                CargoPrice = model.CargoPrice,
                DeliveryPrice = model.DeliveryPrice,
                CargoCategory = model.CargoCategory,
                ShoppingName = model.ShoppingName,
                ApplicationUserId = model.ApplicationUserId,

            };
            newCargo.IsTurkey = true;
            newCargo.TurkeyDate = DateTime.Now;
            await _unitOfWork.cargoRepository.CreateAsync(newCargo);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(int id, CargoUpdateViewModel model)
        {
            Cargo dbCargo = await _unitOfWork.cargoRepository.Get(p => p.Id == id);

            dbCargo.Name = model.Name;
            dbCargo.TrackId = model.TrackId;
            dbCargo.Weight = model.Weight;
            dbCargo.CargoPrice = model.CargoPrice;
            dbCargo.DeliveryPrice = model.DeliveryPrice;
            dbCargo.CargoCategory = model.CargoCategory;
            dbCargo.ShoppingName = model.ShoppingName;
            dbCargo.ApplicationUserId = model.ApplicationUserId;
            await _unitOfWork.SaveAsync();

        }

        public async Task Remove(int id)
        {
            var deleted = await _unitOfWork.cargoRepository.Get(p => p.Id == id && p.IsDeleted == false);
            deleted.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }

        public async Task Send(int id)
        {
            var send = await _unitOfWork.cargoRepository.Get(p => p.Id == id && p.IsDeleted == false);
            send.IsTurkey = false;
            send.IsWay = true;
            send.WayDate = DateTime.Now;
            await _unitOfWork.SaveAsync();
        }

        public async Task SenderCustoms(int id)
        {
            var send = await _unitOfWork.cargoRepository.Get(p => p.Id == id && p.IsDeleted == false);
            send.IsCustoms = true;
            send.IsWay = false;
            send.CustomsDate = DateTime.Now;
            await _unitOfWork.SaveAsync();
        }

        public async Task SenderFilial(int id)
        {
            var send = await _unitOfWork.cargoRepository.Get(p => p.Id == id && p.IsDeleted == false);
            send.IsFilial = true;
            send.IsCustoms = false;
            send.FilialDate = DateTime.Now;
            await _unitOfWork.SaveAsync();
        }

        public async Task Delivered(int id)
        {
            var send = await _unitOfWork.cargoRepository.Get(p => p.Id == id && p.IsDeleted == false);
            send.IsDelivery = true;
            send.IsFilial = false;
            send.DeliveryDate = DateTime.Now;
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Cargo>> GetAllOrderCargo(string UserId)
        {
            return await _unitOfWork.cargoRepository.GetAllAsync(po => po.IsDeleted == false && po.ApplicationUserId == UserId);
        }

        public async Task DollarPay(int id,ApplicationUser user)
        {
            var cargo = await _unitOfWork.cargoRepository.Get(p => p.Id == id && p.IsDeleted == false);
            cargo.IsPay = true;
            var balance = user.DollarBalance - cargo.DeliveryPrice;
            user.DollarBalance = balance;
            await _unitOfWork.SaveAsync();
            await _userManager.UpdateAsync(user);
        }

        public async Task DollarBalance(ApplicationUser user,decimal dollar)
        {
            var balance = user.DollarBalance + dollar;
            user.DollarBalance = balance;
            await _unitOfWork.SaveAsync();
            //await _userManager.UpdateAsync(user);
        }
        public async Task TLPay(int id, ApplicationUser user)
        {
            var cargo = await _unitOfWork.orderRepository.Get(p => p.Id == id );
            var balance = user.DollarBalance - cargo.Price;
            user.DollarBalance = balance;
            await _unitOfWork.SaveAsync();
            await _userManager.UpdateAsync(user);
        }

        public async Task TLBalance(ApplicationUser user, decimal tl)
        {
            var balance = user.TLBalance + tl;
            user.TLBalance = balance;
            await _unitOfWork.SaveAsync();
            await _userManager.UpdateAsync(user);
        }
    }
}
