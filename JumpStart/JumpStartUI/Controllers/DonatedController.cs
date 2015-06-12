using Core.Entities;
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
            return new JObject{
                {"aaData", new JArray{
                    new JObject{
                        {"Name", "bla"},{"Date", "12-32-12"},{"Collected", 12},{"Goal", 56}
                     },
                    new JObject{
                        {"Name", "bla2"},{"Date", "12-32-12"},{"Collected", 78},{"Goal", 56}
                     },
                                         new JObject{
                        {"Name", "bla3"},{"Date", ""},{"Collected", 12},{"Goal", 56}
                     }
                }
                }                
            };
        }

    }
}
