using Microsoft.EntityFrameworkCore;
using RegisterPeoples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterPeoples.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<People> Peoples { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
