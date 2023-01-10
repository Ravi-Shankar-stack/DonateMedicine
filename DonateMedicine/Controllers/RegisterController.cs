using DonateMedicine.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Controllers
{
    public class RegisterController : Controller
    {
        private HealthCareDbContext context;

        public RegisterController(HealthCareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("register/")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(Register register)
        {
            if(register == null || register.Username == null || register.Password == null || register.Gender== null ||register.Age == null || register.Address == null)
            {
                ViewBag.errorMessage = "Invalid Input";
                return View();
            }
            else
            {
                context.Registers.Add(register);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
        }
    }
}
