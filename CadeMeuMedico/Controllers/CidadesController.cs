using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class CidadesController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        // GET: Cidades
        public ActionResult Index()
        {
            var cidades = db.Cidades;
            return View(cidades);
        }

        // GET: Cidades/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cidades cidades = db.Cidades.Find(id);
        //    if (cidades == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cidades);
        //}

        // GET: Cidades/Create

        public ActionResult Adicionar()
        {
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Adicionar(Cidades cidades)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidades);
        }

        // GET: Cidades/Edit/5
        public ActionResult Editar(long id)
        {
            Cidades cidades = db.Cidades.Find(id);
            return View(cidades);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Editar(Cidades cidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidades);
        }

        // GET: Cidades/Delete/5
        public string Excluir(long id)
        {
            try
            {
                Cidades cidades = db.Cidades.Find(id);
                db.Cidades.Remove(cidades);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {

                return Boolean.TrueString;
            }
        }

        //// POST: Cidades/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Cidades cidades = db.Cidades.Find(id);
        //    db.Cidades.Remove(cidades);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
