﻿using CASA_DE_EMPEÑOS.Models;
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
            List<usuario> ListaUsuarios = usuario_.cargarlista();
            return View(ListaUsuarios);
        }

        // GET: ListaUsuario/Details/5
        [HttpGet]
        public ActionResult Details(usuario usuario)
        {
            
            return View(usuario);
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
        [HttpGet]
        public ActionResult Edit(usuario usuario)
        {
            return View(usuario);
        }

        // POST: ListaUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, usuario usuario)
        {
            try
            {
                // TODO: Add update logic here
                usuario usuario_ = new usuario();
                usuario_.Actualizar(usuario.id,usuario);
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
