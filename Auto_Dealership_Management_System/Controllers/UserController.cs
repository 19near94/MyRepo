using Auto_Dealership_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.DataAccess;
using DataLibrary.Models;


namespace Auto_Dealership_Management_System.Controllers
{
    public class UserController : Controller 
    {
        UserDataAccess sqlusrDA = new UserDataAccess(new UserRepo());

        //ManageUser mngusr = new ManageUser();
        // GET: User
        public ActionResult UserDetail()
        {
            //List<UserDetails> lstusr = mngusr.GetUserDet();

            List<DataLibrary.Models.UserDetails> lstusr = sqlusrDA.GetUserDet();
            return View(lstusr);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {

            DataLibrary.Models.UserDetails usr = sqlusrDA.GetUserDetByID(id);
            return View(usr);
        }

        // GET: User/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult CreateUser(DataLibrary.Models.UserDetails collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    if (sqlusrDA.CreateUser(collection))
                    {
                        return RedirectToAction("UserDetail");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                return View("Error",ex);
            }
        }

        // GET: User/Edit/5
        public ActionResult EditUser(int id)
        {

            DataLibrary.Models.UserDetails usr =  sqlusrDA.GetUserDetByID(id);
            return View(usr);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult EditUser(int id, DataLibrary.Models.UserDetails collection)
        {
            try
            {
                // TODO: Add update logic here
                sqlusrDA.UpdateUser(collection);
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
