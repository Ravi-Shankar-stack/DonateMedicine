﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly HealthCareDbContext context;

        public UserHomeController(HealthCareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/userhome")]
        public IActionResult Index()
        {
            var Allrequests = context.Requests.ToList();
            List<Request> UserRequests = new List<Request>();
            string UserName;
            if(TempData.Peek("loggedInUsername") == null)
            {
                UserName = "Karthik";
            }
            else
            {
                UserName = TempData.Peek("loggedInUsername").ToString();
            }

            foreach(Request r in Allrequests)
            {
                if(r.RequesterName == UserName)
                {
                    UserRequests.Add(r);
                }
            }
            return View(UserRequests);
        }
    }
}
