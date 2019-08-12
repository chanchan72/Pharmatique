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
    public class brUnidadNegocio : brGeneral
    {
        
        public List<beUnidadNegocio> ListarUnidadNegocio()
        {
            List<beUnidadNegocio> lstObeUnidadNegocio = new List<beUnidadNegocio>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUnidadNegocio odaUnidadNegocio = new daUnidadNegocio();
                    lstObeUnidadNegocio = odaUnidadNegocio.ListarUnidadNegocio(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeUnidadNegocio;
        }

        
        public int AdicionarUnidadNegocio(beUnidadNegocio obeUnidadNegocio,string usuario)
        {
            int idUnidadNegocio = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUnidadNegocio odaUnidadNegocio = new daUnidadNegocio();
                    idUnidadNegocio = odaUnidadNegocio.AdicionarUnidadNegocio(con, obeUnidadNegocio,usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idUnidadNegocio;
        }

       
        public bool ActualizarUnidadNegocio(beUnidadNegocio obeUnidadNegocio, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUnidadNegocio odaUnidadNegocio = new daUnidadNegocio();
                    exito = odaUnidadNegocio.ActualizarUnidadNegocio(con, obeUnidadNegocio,usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }


        public bool ActualizarEstado(int IdUnidadNegocio, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUnidadNegocio odaUnidadNegocio = new daUnidadNegocio();
                    exito = odaUnidadNegocio.ActualizarEstado(con, IdUnidadNegocio, Estado, usuario);
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
