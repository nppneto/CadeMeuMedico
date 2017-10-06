using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {

        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades")
                .Include("Especialidades").ToList();
            return View(medicos);
        }

        // Devolve a View com os campos para receber informações (Método GET implícito)
        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            return View();
        }

        // Envia os dados preenchidos nos campos para o banco
        [HttpPost]
        public ActionResult Adicionar(Medicos Medicos)
        {
            // Se a validação do model estiver OK...
            if(ModelState.IsValid)
            {
                // Insere no banco
                db.Medicos.Add(Medicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Retorna a view com os dados inseridos anteriormente
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            return View(Medicos);
        }

        public ActionResult Editar(long id)
        {
            Medicos medicos = db.Medicos.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medicos.IDCidade);

            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidades", "Nome", medicos.IDCidade);

            return View(medicos);
        }

        [HttpPost]
        public ActionResult Editar(Medicos Medicos)
        {
            if(ModelState.IsValid)
            {
                db.Entry(Medicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Retorna para a view com os dados inseridos anteriormente
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", Medicos.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidades", "Nome", Medicos.IDCidade);
            return View(Medicos);
        }
    }
}