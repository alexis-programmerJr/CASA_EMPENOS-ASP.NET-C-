using CASA_DE_EMPEÑOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CASA_DE_EMPEÑOS.Controllers
{
    public class UsuarioController : Controller
    {
        usuario usuario_ = new usuario();
        // GET: ListaUsuario
        public ActionResult Index()
        {
            ViewBag.listaUsuarios =  usuario_.cargarlista();
            return View();
        }

        // GET: ListaUsuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListaUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaUsuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListaUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListaUsuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListaUsuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
