using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoStoredProcedure.Models;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;

namespace DemoStoredProcedure.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private demoASPEntities db = new demoASPEntities();
        public ActionResult Index()
        {            
            var data = db.GetAll_User().ToList();
            return View(data);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var UserId = db.GetById_User(id).FirstOrDefault();
            return View(UserId);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(string Username,string Password,string FullName)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    ObjectParameter returnId = new ObjectParameter("lastIdInsert", typeof(int));
                    db.Insert_User(Username, Password, FullName, returnId);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var user = db.GetById_User(id).FirstOrDefault();
            return View(user);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int UserId , string Username)
        {
            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {                    
                    db.Update_User(UserId, Username).ToList();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
