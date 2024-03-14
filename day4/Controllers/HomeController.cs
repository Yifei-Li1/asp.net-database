using day4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace day4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register(Userinfo model)
        {
            if (ModelState.IsValid)
            {
                // Process form (e.g., save the user info into the database)

                // Redirect to the UserInfoDisplay action to show the submitted information
                TempData["UserInfo"] = model; // Pass the model data to be displayed on the success page
                return RedirectToAction("UserInfoDisplay");
            }

            // If the model state is not valid, return the same view with validation messages
            return View(model);
        }
        public ActionResult UserInfoDisplay()
        {
            var model = TempData["UserInfo"] as Userinfo;
            if (model == null)
            {
                // Handle the case where TempData is null, which means direct navigation to this action
                // Redirect to the registration page or display an error
                return RedirectToAction("Register");
            }

            return View(model);
        }
    }
}