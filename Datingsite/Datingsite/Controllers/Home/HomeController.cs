using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using Datingsite.Models;

namespace Datingsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "OPartnerWhereArtThou.com";
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeIndexViewModel model)
        {
           if (ModelState.IsValid)
            {
                var newUsername = RegistrationRepository.ValidateUsername(model.LoginName);
                //validerar ifall användarnamet finns i databasen, om det är null finns den inte
                //och användarnamnet kan läggas till
                if (newUsername != null)
                {
                    ModelState.AddModelError("", "Användarnamnet måste vara unikt");
                    return View();
                }
                else
                {
                    RegistrationRepository.AddLogin(model.LoginName, model.Password);
                    RegistrationRepository.AddUser(model.FirstName, model.LastName,
                    model.Phone, model.Age, model.Gender, model.Email, model.ProfileStatus,
                    model.City, model.PreferedGender);
                    return RedirectToActionPermanent("Login", "Login");
                }
            }
            return View(model);
          }

       }

      

       
}