﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;
namespace DonateMedicine.Controllers
{
    public class UserDonateMedicineController : Controller
    {
        private readonly HealthCareDbContext context;

        public UserDonateMedicineController(HealthCareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/userDonateMedicine")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }

        [HttpPost]
        [Route("/userDonateMedicine")]
        public IActionResult Index(Donation d)
        {
            if(d == null || d.MedicineName == null || d.MedicineCategory == null || d.DonationQuantity <1
                || d.MedicineName.Length <4 || d.MedicineCategory.Length < 4)
            {
                ViewBag.errorMessage = "Invalid Input";
                return View();
            }
            else
            {
                Medicine searchMedicine = context.Medicines.FirstOrDefault(m => m.Name == d.MedicineName
                && m.Category == d.MedicineCategory);

                if(searchMedicine != null)
                {
                    searchMedicine.Quantity += d.DonationQuantity;
                }
                else
                {
                    int id = context.Medicines.ToList().Count + 1;
                    context.Medicines.Add(new Medicine {
                        Id = id,
                        Name = d.MedicineName,
                        Category = d.MedicineCategory,
                        Quantity = d.DonationQuantity,
                    }); ; ;
                }
                d.DonarName = TempData.Peek("loggedInUsername").ToString();
                d.PickupAddress = TempData.Peek("loggedInAddress").ToString();
                d.DonateDate = DateTime.Now;
                context.Donations.Add(d);
                context.SaveChanges();
                return RedirectToAction("Index", "UserHome");
            }
        }
    }
}
