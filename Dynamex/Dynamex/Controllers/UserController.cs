using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.CreateViewModels;
using Core.Entities;
using Data.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dynamex.Controllers
{
    public class UserController : Controller
    {
        private readonly ICargoService _cargoService;
        private readonly IAddressesService _addressesService;
        private readonly ICityService _cityService;
        private readonly IFilialService _filialService;
        private readonly IOrderService _orderService;
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(SignInManager<ApplicationUser> signInManager, IOrderService orderService,IFilialService filialService,ICityService cityService,IAddressesService addressesService,ICargoService cargoService, AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _cargoService = cargoService;
            _context = context;
            _userManager = userManager;
            _filialService = filialService;
            _cityService = cityService;
            _addressesService = addressesService;
            _signInManager = signInManager;
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
            var UserVM = new UserViewModel()
            {
                Email = AppUser.Email,
                UserName = AppUser.UserName,
                Surname = AppUser.Surname,
                Name = AppUser.Name,
                TL = AppUser.TLBalance,
                Dollar = AppUser.DollarBalance,
                Cargoes = await _cargoService.GetAllOrderCargo(AppUser.Id),
                Addresses = await _addressesService.GetAllAsync(),
                Filials = await _filialService.GetAllAsync(),
                Cities = await _cityService.GetAllAsync(),
            };
            return View(UserVM);
        } 
        public async Task<IActionResult> Closures(int id)
        {
            var users = await _userManager.Users.ToListAsync();
            ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
            var UserVM = new UserViewModel()
            {
                Email = AppUser.Email,
                UserName = AppUser.UserName,
                Surname = AppUser.Surname,
                Name = AppUser.Name,
                TL = AppUser.TLBalance,
                Dollar = AppUser.DollarBalance,
                Cargoes = await _cargoService.GetAllOrderCargo(AppUser.Id),
                Addresses = await _addressesService.GetAllAsync(),
                Filials = await _filialService.GetAllAsync(),
                Cities = await _cityService.GetAllAsync(),
            };
            return View(UserVM);
        }
        public async Task<IActionResult> OrderForMe1()
        {
            var users = await _userManager.Users.ToListAsync();
            ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
            var UserVM = new UserViewModel()
            {
                Email = AppUser.Email,
                UserName = AppUser.UserName,
                Surname = AppUser.Surname,
                Name = AppUser.Name,
                TL = AppUser.TLBalance,
                Dollar = AppUser.DollarBalance,
                Cargoes = await _cargoService.GetAllOrderCargo(AppUser.Id),
                Addresses = await _addressesService.GetAllAsync(),
                Filials = await _filialService.GetAllAsync(),
                Cities = await _cityService.GetAllAsync(),
                Orders = await _orderService.GetAllAsync(),
            };
            return View(UserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderForMe(OrderCreateViewModel model)
        {

            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                await _orderService.Create(model, user);
                return RedirectToAction(nameof(OrderForMe1));
            }
            return View(model);
        }
        public async Task<IActionResult> OrderForMe2()
        {
            var users = await _userManager.Users.ToListAsync();
            ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
            var UserVM = new OrderCreateViewModel()
            {
                Email = AppUser.Email,
                UserName = AppUser.UserName,
                Surname = AppUser.Surname,
                Name = AppUser.Name,
                TL = AppUser.TLBalance,
                Dollar = AppUser.DollarBalance,
            };
            return View(UserVM);
        }
        public async Task<IActionResult> Declaration()
        {
            var users = await _userManager.Users.ToListAsync();
            ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
            var UserVM = new UserViewModel()
            {
                Email = AppUser.Email,
                UserName = AppUser.UserName,
                Surname = AppUser.Surname,
                Name = AppUser.Name,
                TL = AppUser.TLBalance,
                Dollar = AppUser.DollarBalance,
                Cargoes = await _cargoService.GetAllOrderCargo(AppUser.Id),
                Addresses = await _addressesService.GetAllAsync(),
                Filials = await _filialService.GetAllAsync(),
                Cities = await _cityService.GetAllAsync(),
            };
            return View(UserVM);
        }
        public async Task<IActionResult> DollarBalance()
        {
            var users = await _userManager.Users.ToListAsync();
            ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
            var UserVM = new UserViewModel()
            {
                Email = AppUser.Email,
                UserName = AppUser.UserName,
                Surname = AppUser.Surname,
                Name = AppUser.Name,
                TL = AppUser.TLBalance,
                Dollar = AppUser.DollarBalance,
                Cargoes = await _cargoService.GetAllOrderCargo(AppUser.Id),
                Addresses = await _addressesService.GetAllAsync(),
                Filials = await _filialService.GetAllAsync(),
                Cities = await _cityService.GetAllAsync(),
            };
            return View(UserVM);
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DollarBalance(decimal dollar)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            await _cargoService.DollarBalance(user,dollar);
            return RedirectToAction("Index", "User");

        }
        public async Task<IActionResult> DollarPay(int id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            await _cargoService.DollarPay(id,user);
            return RedirectToAction(nameof(Closures));
        }
        public async Task<IActionResult> TLBalance()
        {
            var users = await _userManager.Users.ToListAsync();
            ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
            var UserVM = new UserViewModel()
            {
                Email = AppUser.Email,
                UserName = AppUser.UserName,
                Surname = AppUser.Surname,
                Name = AppUser.Name,
                TL = AppUser.TLBalance,
                Dollar = AppUser.DollarBalance,
                Cargoes = await _cargoService.GetAllOrderCargo(AppUser.Id),
                Addresses = await _addressesService.GetAllAsync(),
                Filials = await _filialService.GetAllAsync(),
                Cities = await _cityService.GetAllAsync(),
            };
            return View(UserVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TLBalance(decimal tl)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            await _cargoService.TLBalance(user, tl);
            return RedirectToAction("Index", "User");
        }
        public async Task<IActionResult> TLPay(int id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            var tl2 = _cargoService.DollarPay(id, user);
            return RedirectToAction(nameof(Closures));
        }
        public async Task<IActionResult> Profile()
        {

            ViewBag.city = await _cityService.GetAllAsync();
            ViewBag.filial = await _filialService.GetAllAsync();

            var users = await _userManager.Users.ToListAsync();
            ApplicationUser AppUser = await _userManager.GetUserAsync(HttpContext.User);
            var LogUser = AppUser;
            var UserProfileVM = new UserProfileViewModel()
            {
                Email = AppUser.Email,
                UserName = AppUser.UserName,
                Surname = AppUser.Surname,
                Name = AppUser.Name,
                TL = AppUser.TLBalance,
                Dollar = AppUser.DollarBalance,
                Birthday = AppUser.Birtday,
                PhoneNumber= AppUser.PhoneNumber,
                PassFIN = AppUser.PassportFIN,
                PassNo = AppUser.PassportNumber,
                Filials = await _filialService.GetAllAsync(),
                Cities = await _cityService.GetAllAsync(),
                CityId = AppUser.CityId,
                FilialId = AppUser.FilialId,
                LogUser = LogUser,
                Location = AppUser.Location,
            };
            return View(UserProfileVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserProfileViewModel userProfileVm)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);

                if (userProfileVm.NewPassword == null)
                {
                    var result = await _userManager.ChangePasswordAsync(user,
                        userProfileVm.Password, userProfileVm.Password);
                    user.CityId = userProfileVm.CityId;
                    user.FilialId = userProfileVm.FilialId;

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return RedirectToAction("Problem", "Error");
                    }

                    await _userManager.UpdateAsync(user);
                    await _signInManager.RefreshSignInAsync(user);
                    return View("ChangePasswordConfirmation");
                }
                else
                {
                    var result = await _userManager.ChangePasswordAsync(user,
                        userProfileVm.Password, userProfileVm.NewPassword);
                    user.CityId = userProfileVm.CityId;
                    user.FilialId = userProfileVm.FilialId;
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return RedirectToAction("Problem", "Error");
                    }

                    await _userManager.UpdateAsync(user);
                    await _signInManager.RefreshSignInAsync(user);
                    return View("ChangePasswordConfirmation");
                }
            }



            return RedirectToAction("Problem", "Error");
        }

        public IActionResult ChangePasswordConfirmation()
        {
            return View();
        }

    }
}
