using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class UserViewDonateMedicineController : Controller
    {
        private readonly HealthCareDbContext context;

        public UserViewDonateMedicineController(HealthCareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/userViewDonateMedicine")]
        public IActionResult Index()
        {
            
            List<Donation> AllDonations = context.Donations.ToList<Donation>();
            List<Donation> UserDonation = new List<Donation>();

            string tempusername;
            tempusername = TempData.Peek("loggedInUsername").ToString();
            foreach(Donation d in AllDonations)
            {
                if(d.DonarName == tempusername)
                {
                    UserDonation.Add(d);
                }
            }
            var userDonation = UserDonation;
            return View(userDonation);
        }
    }
}
