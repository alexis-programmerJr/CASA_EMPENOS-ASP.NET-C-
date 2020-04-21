using CASA_DE_EMPEÑOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CASA_DE_EMPEÑOS.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
       prestamo prestamo_ = new prestamo();
        public ActionResult Index()
        {
            List<prestamo> ListaUsuarios = prestamo_.Cargarlista();
            return View(ListaUsuarios);
        }

        // GET: Prestamo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Prestamo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prestamo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                prestamo prestamo = new prestamo();
                prestamo.id_cliente = usuario.id;
                prestamo.folio = crearFolioAleatoio();
                prestamo.descripcion = collection.Get("descripcion");
                prestamo.tipo = collection.Get("tipo");
                if (prestamo.Registrar(prestamo))
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestamo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Prestamo/Edit/5
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

        // GET: Prestamo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prestamo/Delete/5
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
        string crearFolioAleatoio() 
        {
            Random rnd = new Random();
            return rnd.Next().ToString();
        }
    }
}
