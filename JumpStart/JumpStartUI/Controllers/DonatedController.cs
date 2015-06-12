using Core.Entities;
using JumpStart.APILogics;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            return Logics.GetDonatedCoursesRequestsDetails("5579f9fb0529214ae03e3701");            
        }

    }
}
