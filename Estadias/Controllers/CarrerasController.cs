using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estadias.Models;

namespace Estadias.Controllers
{
    public class CarrerasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carreras
        public ActionResult Index()
        {
            return View(db.carreras.ToList());
        }

        // GET: Carreras/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // GET: Carreras/Create
        public ActionResult Create()
        {
            //ViewBag.alumnoID = new SelectList(db.alumnos, "nombreAlumno");
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carreraID,nombreCarrera")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.carreras.Add(carrera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.alumnoID = new SelectList(db.alumno, "alumnoID", "nombreAlumno", carrera.alumnoID);
            return View(carrera);
        }

        // GET: Carreras/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            //ViewBag.alumnoID = new SelectList(db.alumno, "alumnoID", "nombreAlumno", carrera.alumnoID);
            return View(carrera);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carreraID,nombreCarrera")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.alumnoID = new SelectList(db.alumno, "alumnoID", "nombreAlumno", carrera.alumnoID);
            return View(carrera);
        }

        // GET: Carreras/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrera carrera = db.carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Carrera carrera = db.carreras.Find(id);
            db.carreras.Remove(carrera);
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
