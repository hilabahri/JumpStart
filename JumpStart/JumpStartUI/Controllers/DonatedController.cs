using Core.Entities;
using JumpStart.APILogics;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpStartUI.Controllers
{
    public class DonatedController : Controller
    {
        //
        // GET: /Donated/

        public ActionResult Index()
        {
            return View();
        }

        public JObject AcquireData()
        {
            string donatedId = ConfigurationManager.AppSettings["donatedId"] ?? "5579f9fb0529214ae03e3701";
            return Logics.GetDonatedCoursesRequestsDetails(donatedId);            
        }

    }
}
