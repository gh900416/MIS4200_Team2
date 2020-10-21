using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200_Team2.DAL;
using MIS4200_Team2.Models;

namespace MIS4200_Team2.Controllers
{
    public class employeeDataController : Controller
    {
        private MIS4200_Team2Context db = new MIS4200_Team2Context();

        // GET: employeeData
        public ActionResult Index()
        {
            return View(db.employeeData.ToList());
        }

        // GET: employeeData/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeData employeeData = db.employeeData.Find(id);
            if (employeeData == null)
            {
                return HttpNotFound();
            }
            return View(employeeData);
        }

        // GET: employeeData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,emailAddress,firstName,lastName,phoneNumber,officeLocation,position,hireDate")] employeeData employeeData)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                employeeData.ID = memberID;
                // employeeData.ID = Guid.NewGuid();
                db.employeeData.Add(employeeData);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return View("duplicateEmployee");
                }
                return RedirectToAction("Index");
            }

            return View(employeeData);
        }

        // GET: employeeData/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeData employeeData = db.employeeData.Find(id);
            if (employeeData == null)
            {
                return HttpNotFound();
            }
            return View(employeeData);
        }

        // POST: employeeData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,emailAddress,firstName,lastName,phoneNumber,officeLocation,position,hireDate")] employeeData employeeData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeData);
        }

        // GET: employeeData/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeData employeeData = db.employeeData.Find(id);
            if (employeeData == null)
            {
                return HttpNotFound();
            }
            return View(employeeData);
        }

        // POST: employeeData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            employeeData employeeData = db.employeeData.Find(id);
            db.employeeData.Remove(employeeData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
