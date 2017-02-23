using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SaleTracker.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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
            return Json(_db.Sales.Where(x => x.User.Id == currentUser.Id));
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

        public IActionResult UserSaleList()
        {
            var getUserOfSale = _db.Sales.Include(s => s.User);
            var userSaleList = getUserOfSale.Where(s => s.User.Id == _userManager.GetUserId(HttpContext.User));
            return Json(userSaleList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSaleTransaction(int StockId, int SaleQty, float SalePrice, string itemName, float TotalSale)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            Sale Transaction = new Sale(itemName, SalePrice, SaleQty, TotalSale, StockId, user);
            _db.Sales.Add(Transaction);
            _db.SaveChanges();
            return Json(Transaction);
        }
    }
}
//1 855 495 0907