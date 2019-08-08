using System;
using System.Collections.Generic;
using System.Data;

using MVC.Librerias.AccesoDatos;
using MVC.Librerias.EntidadesNegocio;


namespace MVC.Librerias.ReglasNegocio
{
    public class brRestablecer : brGeneral
    {
        public bool RestablecerContrasenia(beRestablecer obeRestablecer)
        {
            bool exito = false;
            //using (SAConnection con = new SAConnection(CadenaConexion))
            //{
            //    try
            //    {
            //        con.Open();
            //        daRestablecer odaRestablecer = new daRestablecer();
            //        exito = odaRestablecer.RestablecerContrasenia(con, obeRestablecer);
            //    }
            //    catch (Exception ex)
            //    {
            //        GrabarLog(ex.Message, ex.StackTrace);
            //    }
                return exito;
            //}
        }
    }
}
