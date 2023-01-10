using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class AddMedicineController : Controller
    {
        private readonly HealthCareDbContext context;

        public AddMedicineController(HealthCareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
