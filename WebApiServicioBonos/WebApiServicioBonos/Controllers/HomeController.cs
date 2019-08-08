using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MVC.Librerias.EntidadesNegocio;
using MVC.Librerias.ReglasNegocio;
using Genaral.Librerias.CodigoUsuario;
using General.Librerias.EntidadesNegocio;
using System.Net.Mail;
using System.Net;

namespace WebApiServicioBonos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


       
    }
}
