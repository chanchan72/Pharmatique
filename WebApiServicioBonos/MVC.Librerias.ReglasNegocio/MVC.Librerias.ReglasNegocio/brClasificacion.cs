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
    public class brClasificacion : brGeneral
    {
        
        public List<beClasificacion> ListarClasificacion()
        {
            List<beClasificacion> lstObeClasificacion = new List<beClasificacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daClasificacion odaClasificacion = new daClasificacion();
                    lstObeClasificacion = odaClasificacion.ListarClasificacion(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeClasificacion;
        }

       
        public int AdicionarClasificacion(beClasificacion obeClasificacion, string usuario)
        {
            int idClasificacion = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daClasificacion odaClasificacion = new daClasificacion();
                    idClasificacion = odaClasificacion.AdicionarClasificacion(con, obeClasificacion, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idClasificacion;
        }

       
        public bool ActualizarClasificacion(beClasificacion obeClasificacion, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daClasificacion odaClasificacion = new daClasificacion();
                    exito = odaClasificacion.ActualizarClasificacion(con, obeClasificacion, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdClasificacion, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daClasificacion odaClasificacion = new daClasificacion();
                    exito = odaClasificacion.ActualizarEstado(con, IdClasificacion, Estado, usuario);
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
            int idPais = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daClasificacion odaClasificacion = new daClasificacion();
                    idPais = odaClasificacion.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idPais;
        }
    }
}
