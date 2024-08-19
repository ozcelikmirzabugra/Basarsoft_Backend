using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basarsoft.Models;
using Microsoft.EntityFrameworkCore;

namespace basarsoft.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<Items> Items { get; set; }
    }
}
