using Auto_Dealership_Management_System.SQLHelper;
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
        SQLhelp sql = new SQLhelp();
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usr,string pwd)
        {

            DataSet ds = sql.GetUserData();
            string result = "Wrong Username and Password!";
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string username = dr["Username"].ToString();
                    string password = dr["Password"].ToString();

                    if (username == usr && password == pwd)
                    {
                        try
                        {
                            return RedirectToAction("MenuPage", "Menu");
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }

                }
            }

            return Json(result);
           
            
        }
    }
}