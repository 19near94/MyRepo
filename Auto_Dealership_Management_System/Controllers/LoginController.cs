
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auto_Dealership_Management_System.Controllers
{
    public class LoginController : Controller
    {
       
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usr,string pwd)
        {
            return View();
           
        }
    }
}