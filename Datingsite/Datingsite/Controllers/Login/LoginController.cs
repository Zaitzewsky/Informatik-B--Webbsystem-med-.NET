using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DAL.Repositories;
using Datingsite.Models.LoginModel;
using Datingsite.Resources.Views;

namespace Datingsite.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var usernameAndPassword = LoginRepository.ValidateLogin(model.Username, model.Password);

            if (usernameAndPassword == null)
            {
                ModelState.AddModelError("", LoginStrings.LoginAndPasswordError);
                return View();
            }

            FormsAuthentication.SetAuthCookie(model.Username, false);

            return RedirectToAction("ProfileStart", "UserProfile");
        }
        //gör det möjigt att byta språk på sidan
        public ActionResult ChangeLanguage(string lang)
        {
            var langCookie = new HttpCookie("lang", lang) { HttpOnly = true };
            Response.AppendCookie(langCookie);
            return RedirectToAction("Login", "Login", new { culture = lang });
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}