﻿using CASA_DE_EMPEÑOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CASA_DE_EMPEÑOS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (usuario.SessionStatus == false)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.EsAdmin = usuario.EsAdmin;
            ViewBag.NombreUsuario = usuario.datosUsuarioActivo.nombre;
            ViewBag.TipoUsuario = usuario.datosUsuarioActivo.tipo;
            if (usuario.datosUsuarioActivo.nombre == "juan carlos vazquez brindis")
            {
                ViewBag.Brindis = true;
            }
            else
            {
                ViewBag.Brindis = false;
            }
            return View();
        }

        public ActionResult About()
        {
            if (usuario.SessionStatus == false)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (usuario.SessionStatus == false)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult cerrarSecion()
        {
            usuario.SessionStatus = false;
            return RedirectToAction("Index");
        }
    }
}