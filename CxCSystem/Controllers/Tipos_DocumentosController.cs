using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CxCSystem.Models;

namespace CxCSystem.Controllers
{
    public class Tipos_DocumentosController : Controller
    {
        private CxCEntities db = new CxCEntities();

        // GET: Tipos_Documentos
        public ActionResult Index()
        {
            return View(db.Tipos_Documentos.ToList());
        }

        // GET: Tipos_Documentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Documentos tipos_Documentos = db.Tipos_Documentos.Find(id);
            if (tipos_Documentos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Documentos);
        }

        // GET: Tipos_Documentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipos_Documentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Cuenta_contable,Estado")] Tipos_Documentos tipos_Documentos)
        {
            if (ModelState.IsValid)
            {
                db.Tipos_Documentos.Add(tipos_Documentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipos_Documentos);
        }

        // GET: Tipos_Documentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Documentos tipos_Documentos = db.Tipos_Documentos.Find(id);
            if (tipos_Documentos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Documentos);
        }

        // POST: Tipos_Documentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Cuenta_contable,Estado")] Tipos_Documentos tipos_Documentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos_Documentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos_Documentos);
        }

        // GET: Tipos_Documentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Documentos tipos_Documentos = db.Tipos_Documentos.Find(id);
            if (tipos_Documentos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Documentos);
        }

        // POST: Tipos_Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos_Documentos tipos_Documentos = db.Tipos_Documentos.Find(id);
            db.Tipos_Documentos.Remove(tipos_Documentos);
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
