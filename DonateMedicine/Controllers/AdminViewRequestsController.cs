using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class AdminViewRequestsController : Controller
    {
        private readonly HealthCareDbContext context;
        public AdminViewRequestsController(HealthCareDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("/adminViewRequests")]
        public IActionResult Index()
        {
            var AllRequests = context.Requests.ToList();
            return View(AllRequests);
        }
    }
}
