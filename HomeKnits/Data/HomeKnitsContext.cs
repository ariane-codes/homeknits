using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeKnits.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HomeKnits.Data
{
    public class HomeKnitsContext : IdentityDbContext
    {
        public HomeKnitsContext (DbContextOptions<HomeKnitsContext> options)
            : base(options)
        {
        }

        public DbSet<HomeKnits.Models.Product> Product { get; set; } = default!;
        public DbSet<HomeKnits.Models.Review> Review { get; set; } = default!;
    }
}
