using Core.Entities;
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
            return View(new Donated{LastName = "hi"});
        }

    }
}
