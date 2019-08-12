using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Librerias.EntidadesNegocio;
using Genaral.Librerias.CodigoUsuario;
using MVC.Libreria.AccesoDatos;
using MVC.Libreria.EntidadesNegocio;
using MVC.Libreria.ReglasNegocio;
using System.Data.SqlClient;
using MVC.Librerias.ReglasNegocio;

namespace MVC.Libreria.ReglasNegocio
{
    public class brRegionales : brGeneral
    {
       
        public List<beRegionales> ListarRegional()
        {
            List<beRegionales> lstObeRegionales = new List<beRegionales>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRegionales odaRegionales = new daRegionales();
                    lstObeRegionales = odaRegionales.ListarRegional(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeRegionales;
        }

       
        public int AdicionarRegional(beRegionales obeRegional, string usuario)
        {
            int idRegional = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRegionales odaRegionales = new daRegionales();
                    idRegional = odaRegionales.AdicionarRegional(con, obeRegional, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idRegional;
        }

       
        public bool ActualizarRegional(beRegionales obeRegional, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRegionales odaRegionales = new daRegionales();
                    exito = odaRegionales.ActualizarRegional(con, obeRegional, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdRegional, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRegionales odaRegionales = new daRegionales();
                    exito = odaRegionales.ActualizarEstado(con, IdRegional, Estado, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }
    }
}
