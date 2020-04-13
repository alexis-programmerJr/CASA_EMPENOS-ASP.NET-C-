using CASA_DE_EMPEÑOS.Models;
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
            conexion conexion_ = new conexion();
            conexion_.Prueba();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}