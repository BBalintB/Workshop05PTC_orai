using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Workshop05PTC_orai.Models;

namespace Workshop05PTC_orai.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AppUser> Users{ get; set; }
        public DbSet<Car>Cars{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
