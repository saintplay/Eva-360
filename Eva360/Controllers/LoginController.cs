using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Eva360.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            return View("Login");
        }      
    }
}