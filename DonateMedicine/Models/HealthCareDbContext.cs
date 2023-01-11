using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Models
{
    public class HealthCareDbContext : DbContext
    {
        public HealthCareDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Register> Registers { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Request> Requests { get; set; }

    }
}
