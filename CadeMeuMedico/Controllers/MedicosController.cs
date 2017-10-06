using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
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
    }
}