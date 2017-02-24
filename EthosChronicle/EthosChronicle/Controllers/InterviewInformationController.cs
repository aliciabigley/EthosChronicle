using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EthosChronicle.Models;

namespace EthosChronicle.Controllers
{
    public class InterviewInformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InterviewInformation
        public ActionResult Index()
        {
            return View(db.VideographerInfomation.ToList());
        }

        // GET: InterviewInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideographerInfo videographerInfo = db.VideographerInfomation.Find(id);
            if (videographerInfo == null)
            {
                return HttpNotFound();
            }
            return View(videographerInfo);
        }
        [Authorize]
        // GET: InterviewInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterviewInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IntervieweeName,Relationship,AgeRange,Location,Stories,Interviewer,date")] VideographerInfo videographerInfo)
        {
            if (ModelState.IsValid)
            {
                db.VideographerInfomation.Add(videographerInfo);
                db.SaveChanges();
                return RedirectToAction("PricingPackages", "User");
            }

            return View(videographerInfo);
        }

        // GET: InterviewInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideographerInfo videographerInfo = db.VideographerInfomation.Find(id);
            if (videographerInfo == null)
            {
                return HttpNotFound();
            }
            return View(videographerInfo);
        }

        // POST: InterviewInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IntervieweeName,Relationship,AgeRange,Location,Stories,Interviewer,date")] VideographerInfo videographerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videographerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videographerInfo);
        }

        // GET: InterviewInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideographerInfo videographerInfo = db.VideographerInfomation.Find(id);
            if (videographerInfo == null)
            {
                return HttpNotFound();
            }
            return View(videographerInfo);
        }

        // POST: InterviewInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideographerInfo videographerInfo = db.VideographerInfomation.Find(id);
            db.VideographerInfomation.Remove(videographerInfo);
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
