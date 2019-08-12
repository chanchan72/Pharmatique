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
    public class brEntidad : brGeneral
    {
       
        public List<beEntidad> ListarEntidad()
        {
            List<beEntidad> lstObeEntidad = new List<beEntidad>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEntidad odaEntidad = new daEntidad();
                    lstObeEntidad = odaEntidad.ListarEntidad(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeEntidad;
        }

        
        public int AdicionarEntidad(beEntidad obeEntidad, string usuario)
        {
            int idEntidad = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEntidad odaEntidad = new daEntidad();
                    idEntidad = odaEntidad.AdicionarEntidad(con, obeEntidad, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idEntidad;
        }

       
        public bool ActualizarEntidad(beEntidad obeEntidad, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEntidad odaEntidad = new daEntidad();
                    exito = odaEntidad.ActualizarEntidad(con, obeEntidad, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdEntidad, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEntidad odaEntidad = new daEntidad();
                    exito = odaEntidad.ActualizarEstado(con, IdEntidad, Estado, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public int CargueMasivo(string Cadena)
        {
            int idEntidad = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEntidad odaEntidad = new daEntidad();
                    idEntidad = odaEntidad.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idEntidad;
        }
    }
}
