using clientWebApp.Models;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin = clientWebApp.Models.Admin;

namespace clientWebApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
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
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(ConsoleApp1.Admin admin)
        {
            if (ModelState.IsValid) // Checking if model state is valid
            {
                using (var db = new BlogDbContext())
                {
                    // Check if there's an admin with the provided email
                    var matchingAdmin = db.Admins.FirstOrDefault(e => e.Email_Id == admin.Email_Id);

                    if (matchingAdmin != null)
                    {
                        // Check if the password matches
                        if (matchingAdmin.Password == admin.Password)
                        {
                            // Successful login, redirect to desired action
                            return RedirectToAction("Index", "Employees");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid password.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Admin with provided email not found.");
                    }
                }
            }

            // If reached here, there were validation errors or login was unsuccessful
            return RedirectToAction("AdminFail", "Home");
        }
        public ActionResult AdminFail()
        {
            return View();
        }
        public ActionResult EmployeLogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeLogIn(clientWebApp.Models.Employee emp)
        {
            BlogDbEntities db = new BlogDbEntities();

            var l = db.Employees.Where(e => e.Email_Id == emp.Email_Id && e.PassCode ==emp.PassCode);
            if (l != null)
            {
                return RedirectToAction("Index", "BlogInfoes");
            }
            else
            {
                return RedirectToAction("EmployeeFail", "Home");
            }
        }
        public ActionResult EmployeeFail()
        {
            return View();
        }

    }
}