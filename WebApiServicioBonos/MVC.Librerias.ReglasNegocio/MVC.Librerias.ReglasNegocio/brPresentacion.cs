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
    public class brPresentacion : brGeneral
    {
        
        public List<bePresentacion> ListarPresentacion()
        {
            List<bePresentacion> lstObePresentacion = new List<bePresentacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPresentacion odaPresentacion = new daPresentacion();
                    lstObePresentacion = odaPresentacion.ListarPresentacion(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObePresentacion;
        }

        
        public int AdicionarPresentacion(bePresentacion obePresentacion, string usuario)
        {
            int idPresentacion = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPresentacion odaPresentacion = new daPresentacion();
                    idPresentacion = odaPresentacion.AdicionarPresentacion(con, obePresentacion, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idPresentacion;
        }

        
        public bool ActualizarPresentacion(bePresentacion obePresentacion, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPresentacion odaPresentacion = new daPresentacion();
                    exito = odaPresentacion.ActualizarPresentacion(con, obePresentacion, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdPresentacion, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPresentacion odaPresentacion = new daPresentacion();
                    exito = odaPresentacion.ActualizarEstado(con, IdPresentacion, Estado, usuario);
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
            int idPresentacion = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPresentacion odaPresentacion = new daPresentacion();
                    idPresentacion = odaPresentacion.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idPresentacion;
        }

    }
}
