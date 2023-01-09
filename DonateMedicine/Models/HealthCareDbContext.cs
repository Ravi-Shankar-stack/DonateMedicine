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
    }
}
