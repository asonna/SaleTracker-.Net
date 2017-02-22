using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleTracker.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
