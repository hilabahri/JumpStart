﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace M101DotNet.WebApp.Controllers
//{
//    [AllowAnonymous]
//    public class AccountController : Controller
//    {
//        [HttpGet]
//        public ActionResult Login(string returnUrl)
//        {
//            var model = new LoginModel
//            {
//                ReturnUrl = returnUrl
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<ActionResult> Login(LoginModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            // XXX WORK HERE
//            // fetch a user by the email in model.Email
//            dynamic user;
//            user.Name = "hi";
//            user.Email = "Shalom";
//            if (user == null)
//            {
//                ModelState.AddModelError("Email", "Email address has not been registered.");
//                return View(model);
//            }

//            var identity = new ClaimsIdentity(new[]
//                {
//                    new Claim(ClaimTypes.Name, user.Name),
//                    new Claim(ClaimTypes.Email, user.Email)
//                },
//                "ApplicationCookie");

//            var context = Request.GetOwinContext();
//            var authManager = context.Authentication;

//            authManager.SignIn(identity);

//            return Redirect(GetRedirectUrl(model.ReturnUrl));
//        }

//        [HttpPost]
//        public ActionResult Logout()
//        {
//            var context = Request.GetOwinContext();
//            var authManager = context.Authentication;

//            authManager.SignOut("ApplicationCookie");
//            return RedirectToAction("Index", "Home");
//        }

     
     

//        private string GetRedirectUrl(string returnUrl)
//        {
//            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
//            {
//                return Url.Action("index", "home");
//            }

//            return returnUrl;
//        }
//    }
//}