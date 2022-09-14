using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dynamex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class DashboardController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFilialService _filialService;
        private readonly ICargoService _cargoService;
        private readonly IOrderService _orderService;
        public DashboardController(UserManager<ApplicationUser> userManager, ICargoService cargoService, IOrderService orderService, IFilialService filialService)
        {
            _userManager = userManager;
            _cargoService = cargoService;
            _orderService = orderService;
            _filialService = filialService;
        }

        public async Task<IActionResult> Index()
        {
            var userCount = (await _userManager.Users.ToListAsync()).Count;
            var cargoCount = (await _cargoService.GetAllAsync()).Count;
            var orderCount = (await _orderService.GetAllAsync()).Count;
            var filialCount = (await _filialService.GetAllAsync()).Count;
            var dashboard = new DashboardViewModel()
            {
                FilialCount = filialCount,
                UserCount = userCount,
                CargoCount = cargoCount,
                OrderCount = orderCount,
            };

            return View(dashboard);
        }
    }
}
