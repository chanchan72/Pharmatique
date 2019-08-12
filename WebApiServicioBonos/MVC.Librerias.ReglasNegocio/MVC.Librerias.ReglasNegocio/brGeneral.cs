using System;
using System.Collections.Generic;
using System.Configuration;
using Genaral.Librerias.CodigoUsuario;
using General.Librerias.EntidadesNegocio;
using System.Web;


namespace MVC.Librerias.ReglasNegocio
{
    public class brGeneral
    {
        public string CadenaConexion { get; set; }
        public string aplicacion { get; set; }
        private string archivoLog { get; set; }
        public brGeneral()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["BonosCon"].ConnectionString;
            archivoLog = ConfigurationManager.AppSettings["archivoLog"];
            aplicacion = ConfigurationManager.AppSettings["aplicacion"];
        }

        public void GrabarLog(string MesanjeError, string DetalleError)
        {
            beLog obeLog = new beLog();
            obeLog.FechaHora = DateTime.Now;
            obeLog.Usuario = "Sebastian Mateus";
            //obeLog.Usuario = HttpContext.Current.Session[""].ToString();
            obeLog.MensageError = MesanjeError;
            obeLog.DetalleError = DetalleError;
            obeLog.Aplicacion = ConfigurationManager.AppSettings["aplicacion"];
            obeLog.IP_Cliente = HttpContext.Current.Request.UserHostAddress;
            Objeto.Grabar(obeLog, archivoLog);
        }
    }
}
