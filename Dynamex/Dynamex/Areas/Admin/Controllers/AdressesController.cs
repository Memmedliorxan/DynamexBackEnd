using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.UpdateViewModels;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Dynamex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdressesController : Controller
    {
        private readonly IAddressesService _addressesService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdressesController(IUnitOfWork unitOfWork, IAddressesService addressesService, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _addressesService = addressesService;
        }
        public async Task<IActionResult> Turkey()
        {

            return View(await _addressesService.Get(1));
        }
        public async Task<IActionResult> America()
        {

            return View(await _addressesService.Get(1));
        }
        public async Task<IActionResult> UpdateTurkey(int id)
        {
            var adresses = await _addressesService.Get(1);
            AddressesUpdateViewModel adres = new AddressesUpdateViewModel()
            {
                AddressTR = adresses.AddressTR,
                AddressTitleTR = adresses.AddressTitleTR,
                ReceiverTR = adresses.ReceiverTR,
                CityTR = adresses.CityTR,
                CountryDistrictTR = adresses.CountryDistrictTR,
                NeighborhoodTR = adresses.NeighborhoodTR,
                PhoneNumberTR = adresses.PhoneNumberTR,
                PostalCodeTR = adresses.PostalCodeTR,
                TrID = adresses.TrID,
            };
            return View(adres);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTurkey(int id,AddressesUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _addressesService.UpdateTurkey(id, model);
                return RedirectToAction(nameof(Turkey));
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateUSA(int id)
        {
            var adresses = await _addressesService.Get(1);
            AddressesUpdateViewModel adres = new AddressesUpdateViewModel()
            {
                AddressFirstLineUSA = adresses.AddressFirstLineUSA,
                AddressSecondLineUSA = adresses.AddressSecondLineUSA,
                StateUSA = adresses.StateUSA,
                CityUSA = adresses.CityUSA,
                CountryDistrictUSA = adresses.CountryDistrictUSA,
                PhoneNumberUSA = adresses.PhoneNumberUSA,
                PostalCodeUSA = adresses.PostalCodeUSA,
            };
            return View(adres);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUSA(int id, AddressesUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _addressesService.UpdateUSA(id, model);
                return RedirectToAction(nameof(America));
            }
            return View(model);
        }
    }
}
