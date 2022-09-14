using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dynamex.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            //ApplicationUser user = await _userManager.Users.ToListAsync();
            ViewBag.Users = await _userManager.Users.ToListAsync();
            var item = await _unitOfWork.orderRepository.GetAllAsync(o=>o.IsOrder==false);
            return View(item);
        }

        public async Task<IActionResult> GetOrdered(int id)
        {
            await _orderService.GetOrdered(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
