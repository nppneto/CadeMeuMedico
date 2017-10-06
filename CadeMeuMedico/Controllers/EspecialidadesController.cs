using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadesController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        // GET: Especialidades
        public ActionResult Index()
        {
            var especialidades = db.Especialidades;
            return View(especialidades);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidades especialidades)
        {
            if(ModelState.IsValid)
            {
                db.Especialidades.Add(especialidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Caso não passe na validação, retorna para a View de cadastro com os dados inseridos
            return View(especialidades);
        }

        public ActionResult Editar(long id)
        {
            Especialidades especialidades = db.Especialidades.Find(id);
            return View(especialidades);
        }

        [HttpPost]
        public ActionResult Editar(Especialidades especialidades)
        {
            if(ModelState.IsValid)
            {
                db.Entry(especialidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidades);
        }

        public string Excluir(long id)
        {
            try
            {
                Especialidades especialidades = db.Especialidades.Find(id);
                db.Especialidades.Remove(especialidades);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {

                return Boolean.FalseString;
            }
        }
    }
}