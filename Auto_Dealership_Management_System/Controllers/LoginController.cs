
using Auto_Dealership_Management_System.Models;
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

        ManageUser mngr = new ManageUser();
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPage(UserDetails usr)
        {

            List<UserDetails> usrdet = mngr.GetUserDet();

            foreach (var item in usrdet)
            {
                if (usr.Username == item.Username && usr.Password == item.Password)
                {
                    return RedirectToAction("UserDetail", "User");
                }
                else
                {
                    return View();
                }
            }
            return View();
        
           
        }
    }
}