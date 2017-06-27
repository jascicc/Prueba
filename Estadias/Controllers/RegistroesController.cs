﻿using System;
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
    public class RegistroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Registroes
        public ActionResult Index()
        {
            var registros = db.registros.Include(r => r.alumno).Include(r => r.empresa);
            return View(registros.ToList());
        }

        // GET: Registroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.registros.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registroes/Create
        public ActionResult Create()
        {
            ViewBag.alumnoID = new SelectList(db.alumnos, "alumnoID", "nombreCompleto");
            ViewBag.empresaID = new SelectList(db.empresas, "empresaID", "nombreEmpresa");
            return View();
        }

        // POST: Registroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "alumnoID,fecha,empresaID")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.registros.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.alumnoID = new SelectList(db.alumnos, "alumnoID", "nombreCompleto", registro.alumnoID);
            ViewBag.empresaID = new SelectList(db.empresas, "empresaID", "nombreEmpresa", registro.empresaID);
            return View(registro);
        }

        // GET: Registroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.registros.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.alumnoID = new SelectList(db.alumnos, "alumnoID", "nombreCompleto", registro.alumnoID);
            ViewBag.empresaID = new SelectList(db.empresas, "empresaID", "nombreEmpresa", registro.empresaID);
            return View(registro);
        }

        // POST: Registroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "registroID,alumnoID,fecha,empresaID")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.alumnoID = new SelectList(db.alumnos, "alumnoID", "nombreCompleto", registro.alumnoID);
            ViewBag.empresaID = new SelectList(db.empresas, "empresaID", "nombreEmpresa", registro.empresaID);
            return View(registro);
        }

        // GET: Registroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.registros.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.registros.Find(id);
            db.registros.Remove(registro);
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
