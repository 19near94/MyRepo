using Auto_Dealership_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auto_Dealership_Management_System.Controllers
{
    public class UserController : Controller
    {
        ManageUser mngusr = new ManageUser();
        // GET: User
        public ActionResult UserDetail()
        {
            List<UserDetails> lstusr = mngusr.GetUserDet();
            
            return View(lstusr);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {

            UserDetails usr = mngusr.GetUserDetByID(id);
            return View(usr);
        }

        // GET: User/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult CreateUser(UserDetails collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (mngusr.CreateUser(collection))
                {
                    return RedirectToAction("UserDetail");
                }
                else
                {
                    return View("Error");
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult EditUser(int id)
        {

            UserDetails usr =  mngusr.GetUserDetByID(id);
            return View(usr);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult EditUser(int id, UserDetails collection)
        {
            try
            {
                // TODO: Add update logic here
                mngusr.UpdateUser(collection);


                return RedirectToAction("UserDetail");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
