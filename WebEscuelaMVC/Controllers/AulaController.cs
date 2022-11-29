using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {
        private WebEscuelaDBContext context = new WebEscuelaDBContext();

        // GET: Aula
        [HttpGet]

        public ActionResult Index()
        {
            return View("Index", context.Aulas.ToList());
        }
        //GET: /aula/create
        [HttpGet]

        public ActionResult Create()
        {
            Aula newAula = new Aula();
            return View("Register", newAula);

        }

        [HttpPost]

        public ActionResult Create(Aula aula)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", aula);
            }
            else
            {
                context.Aulas.Add(aula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        //GET : /aula/id

        [HttpGet]
        [ActionName("Detalle")]
        public ActionResult Detalle (int id)
        {
            Aula aula = context.Aulas.Find(id);

            if (aula != null)
            {
                return View("Detalle", aula);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpGet]

        public ActionResult ModificarPorId(int id)
        {
            Aula aula = context.Aulas.Find(id);

            if (aula == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Modificar", aula);
            }
        }

        [HttpPost]

        public ActionResult ModificarPorId(Aula aula)
        {
            if (!ModelState.IsValid)
            {
                return View("Modificar", aula);
            }
            else
            {
                context.Entry(aula).State = EntityState.Modified;
                context.SaveChanges();
                return View("Index", aula);

            }
        }

        [HttpGet]
        
        public ActionResult ListarPorEstado (string estado)
        {
            List<Aula> aulas = (from a in context.Aulas
                                where a.Estado == estado
                                select a).ToList();

            return View("Index", aulas);
        }

        [HttpGet]

        public ActionResult TraerporNumero (int numero)
        {
            Aula aula = (from a in context.Aulas
                         where a.Numero == numero
                         select a).SingleOrDefault();

            return View("Detalle", aula);
        }

        // GET: /aula/Delete/id 
        [HttpGet]
        public ActionResult Delete(int id)
        {

            Aula aula = context.Aulas.Find(id);

            if (aula == null)
            {
                return HttpNotFound();

            }

            return View("Delete", aula);

        }



        [HttpPost]
        [ActionName("Delete")]

        //POST: /aula/Delete

        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = context.Aulas.Find(id);

            if (aula != null)
            {
                context.Aulas.Remove(aula);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}