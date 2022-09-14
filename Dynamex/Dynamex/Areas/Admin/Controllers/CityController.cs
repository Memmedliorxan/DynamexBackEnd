using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.CreateViewModels;
using Business.ViewModels.UpdateViewModels;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dynamex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public CityController(ICityService cityService, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _cityService = cityService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.cityRepository.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _cityService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _cityService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Update(int id)
        {
            City city = await _cityService.Get(id);
            if (city == null) return NotFound();
            var cityUpdateViewModel = new CityUpdateViewModel()
            {
                Name = city.Name
            };
            return View(cityUpdateViewModel);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, CityUpdateViewModel model)
        {
            await _cityService.Update(id, model);
            return RedirectToAction(nameof(Index));
        }

    }
}
