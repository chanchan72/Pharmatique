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
    public class brDistrito : brGeneral
    {
        
        public List<beDistrito> ListarDistrito()
        {
            List<beDistrito> lstObeDistrito = new List<beDistrito>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDistrito odaDistrito = new daDistrito();
                    lstObeDistrito = odaDistrito.ListarDistrito(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeDistrito;
        }

        
        public int AdicionarDistrito(beDistrito obeDistrito, string usuario)
        {
            int idDistrito = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDistrito odaDistrito = new daDistrito();
                    idDistrito = odaDistrito.AdicionarDistrito(con, obeDistrito, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idDistrito;
        }

       
        public bool ActualizarDistrito(beDistrito obeDistrito, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDistrito odaDistrito = new daDistrito();
                    exito = odaDistrito.ActualizarDistrito(con, obeDistrito, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdDistrito, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDistrito odaDistrito = new daDistrito();
                    exito = odaDistrito.ActualizarEstado(con, IdDistrito, Estado, usuario);
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
