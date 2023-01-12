using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class UserRequestMedicineController : Controller
    {
        private readonly HealthCareDbContext context;

        public UserRequestMedicineController(HealthCareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/userRequestMedicine")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            ViewBag.MedicineList = context.Medicines.ToList();
            return View();
        }

        [HttpPost]
        [Route("/userRequestMedicine")]
        public IActionResult Index(Request r)
        {
            if(r.MedicineName == null || r.MedicineCategory == null || r.RequestedQuantity < 1)
            {
                ViewBag.errorMessage = "Invalid Input!";
                ViewBag.MedicineList = context.Medicines.ToList();
                return View();
            }
            else
            {
                Medicine searchMed = context.Medicines.FirstOrDefault(m => 
                m.Name == r.MedicineName);
                if(searchMed.Quantity < r.RequestedQuantity)
                {
                    ViewBag.errorMessage = "Invalid Input!";
                    ViewBag.MedicineList = context.Medicines.ToList();
                    return View();
                }
                else
                {
                    searchMed.Quantity -= r.RequestedQuantity;
                    int id = context.Requests.ToList().Count + 1;
                    r.Id = id;
                    r.RequesterName = TempData.Peek("loggedInUsername").ToString();
                    r.DeliveryAddress = TempData.Peek("loggedInAddress").ToString();
                    r.RequestedDate = DateTime.Today;
                    context.Requests.Add(r);
                    context.SaveChanges();
                    return RedirectToAction("Index", "UserHome");
                }
            }
        }
    }
}
