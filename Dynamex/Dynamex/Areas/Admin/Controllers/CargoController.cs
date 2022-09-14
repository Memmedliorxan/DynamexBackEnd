using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.CreateViewModels;
using Business.ViewModels.UpdateViewModels;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dynamex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class CargoController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CargoController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, ICargoService cargoService)
        {
            _unitOfWork = unitOfWork;
            _cargoService = cargoService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AZ()
        {
            var filial = await _unitOfWork.filialRepository.GetAllAsync(f => f.IsDeleted == false);
            var item = await _unitOfWork.cargoRepository.GetAllAsync(c=>c.IsDeleted==false&&c.IsTurkey==false);
            var usess = await _userManager.Users.ToListAsync();
            //TRViewModel tr = new TRViewModel()
            //{
            //    Cargoes = item,
            //    ApplicationUser = usess,
            //};
            return View(item);
        }
        public async Task<IActionResult> TR()
        {
            var item = await _unitOfWork.cargoRepository.GetAllAsync(c => c.IsDeleted == false && c.IsTurkey == true);
            var usess = await _userManager.Users.ToListAsync();
            //TRViewModel tr = new TRViewModel()
            //{
            //    Cargoes = item,
            //    ApplicationUser = usess,
            //};
            return View(item);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Users = await _userManager.Users.ToListAsync();
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CargoCreateViewModel model)
        {
            ViewBag.Users = await _userManager.Users.ToListAsync();
            if (ModelState.IsValid)
            {
                await _cargoService.Create(model);
                return RedirectToAction(nameof(TR));
            }
            return View(model);
        }

        public async Task<ActionResult> Update(int id)
        {

            ViewBag.Users = await _userManager.Users.ToListAsync();
            Cargo cargo = await _cargoService.Get(id);
            if (cargo == null) return NotFound();
            var model = new CargoUpdateViewModel()
            {
                Name = cargo.Name,
                TrackId = cargo.TrackId,
                Weight = cargo.Weight,
                CargoPrice = cargo.CargoPrice,
                DeliveryPrice = cargo.DeliveryPrice,
                CargoCategory = cargo.CargoCategory,
                ShoppingName = cargo.ShoppingName,
                ApplicationUserId = cargo.ApplicationUserId,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, CargoUpdateViewModel model)
        {
            ViewBag.Users = await _userManager.Users.ToListAsync();
            if (ModelState.IsValid)
            {
                await _cargoService.Update(id, model);
                return RedirectToAction(nameof(TR));
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _cargoService.Remove(id);

            return RedirectToAction(nameof(TR));
        }

        public async Task<ActionResult> Sender(int id)
        {
            await _cargoService.Send(id);

            return RedirectToAction(nameof(TR));
        }
        public async Task<ActionResult> SenderCustoms(int id)
        {
            await _cargoService.SenderCustoms(id);

            return RedirectToAction(nameof(AZ));
        }
        public async Task<ActionResult> SenderFilial(int id)
        {
            await _cargoService.SenderFilial(id);

            return RedirectToAction(nameof(AZ));
        }
        public async Task<ActionResult> Delivered(int id)
        {
            await _cargoService.Delivered(id);

            return RedirectToAction(nameof(AZ));
        }
    }
}
