using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpStartUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JObject GetFundingRequestsMetaData()
        {
            JObject metaData = JObject.Parse("{aaData : [{ \"purpose\" : \"liad\", \"age\" : \"something\", \"living_place\" : \"some office\", \"collected\" : \"103$\", \"goal\" : \"105$\" }]}");
            return metaData;
        }
    }
}
