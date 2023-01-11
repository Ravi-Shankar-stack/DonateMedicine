using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;
namespace DonateMedicine.Controllers
{
    public class AdminViewDonationsController : Controller
    {
        private readonly HealthCareDbContext context;

        public AdminViewDonationsController(HealthCareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/adminViewDonations")]
        public IActionResult Index()
        {
            ViewBag.AllDonations = context.Donations.ToList();
            return View();
        }
    }
}
