using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SaleTracker.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace SaleTracker.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public SaleController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Sales.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sale sale)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            sale.User = currentUser;
            _db.Sales.Add(sale);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
