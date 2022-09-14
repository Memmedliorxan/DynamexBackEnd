using Business.Interfaces;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.ViewModels.CreateViewModels;
using Business.ViewModels.UpdateViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Dynamex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class FilialsController : Controller
    {
        private readonly IFilialService _filialService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public FilialsController(IFilialService filialService, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _filialService=filialService;
            _unitOfWork=unitOfWork;
            _userManager=userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _unitOfWork.filialRepository.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilialCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _filialService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _filialService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Update(int id)
        {
            Filial filial = await _filialService.Get(id);
            if (filial == null) return NotFound();
            var filialUpdateViewModel = new FilialUpdateViewModel()
            {
                Name = filial.Name
            };
            return View(filialUpdateViewModel);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, FilialUpdateViewModel model)
        {
            await _filialService.Update(id, model);
            return RedirectToAction(nameof(Index));
        }

    }
}
