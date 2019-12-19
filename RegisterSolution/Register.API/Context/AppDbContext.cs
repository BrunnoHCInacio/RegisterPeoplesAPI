using Microsoft.EntityFrameworkCore;
using Register.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
