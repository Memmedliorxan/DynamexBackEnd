using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.UpdateViewModels;
using Core;
using Core.Entities;
using Data.Repositories.Implementations;

namespace Business.Implementations
{
    public class AddressesService : IAddressesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Addresses> Get(int id)
        {
            return await _unitOfWork.addressesRepository.Get(pc => pc.Id == id);
        }

        public async Task<Addresses> GetAllAsync()
        {
            return await _unitOfWork.addressesRepository.Get(pc => pc.Id == 1);

        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTurkey(int id, AddressesUpdateViewModel model)
        {
            Addresses addresses = await _unitOfWork.addressesRepository.Get(p => p.Id == id);

            addresses.AddressTR = model.AddressTR;
            addresses.AddressTitleTR = model.AddressTitleTR;
            addresses.ReceiverTR = model.ReceiverTR;
            addresses.CityTR = model.CityTR;
            addresses.CountryDistrictTR = model.CountryDistrictTR;
            addresses.NeighborhoodTR = model.NeighborhoodTR;
            addresses.PhoneNumberTR = model.PhoneNumberTR;
            addresses.PostalCodeTR = model.PostalCodeTR;
            addresses.TrID = model.TrID;
            await _unitOfWork.SaveAsync();
        }
        public async Task UpdateUSA(int id, AddressesUpdateViewModel model)
        {
            Addresses addresses = await _unitOfWork.addressesRepository.Get(p => p.Id == id);

            addresses.AddressFirstLineUSA = model.AddressFirstLineUSA;
            addresses.AddressSecondLineUSA = model.AddressSecondLineUSA;
            addresses.StateUSA = model.StateUSA;
            addresses.CityUSA = model.CityUSA;
            addresses.CountryDistrictUSA = model.CountryDistrictUSA;
            addresses.PhoneNumberUSA = model.PhoneNumberUSA;
            addresses.PostalCodeUSA = model.PostalCodeUSA;
            await _unitOfWork.SaveAsync();
        }
    }
}
