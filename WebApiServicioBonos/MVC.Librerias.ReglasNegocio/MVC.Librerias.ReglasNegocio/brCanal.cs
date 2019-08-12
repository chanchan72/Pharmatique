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
    public class brCanal : brGeneral
    {
        
        public List<beCanal> ListarCanal()
        {
            List<beCanal> lstObeCanal = new List<beCanal>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCanal odaCanal = new daCanal();
                    lstObeCanal = odaCanal.ListarCanal(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeCanal;
        }

        
        public int AdicionarCanal(beCanal obeCanal, string usuario)
        {
            int idCanal = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCanal odaCanal = new daCanal();
                    idCanal = odaCanal.AdicionarCanal(con, obeCanal, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idCanal;
        }

        
        public bool ActualizarCanal(beCanal obeCanal, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCanal odaCanal = new daCanal();
                    exito = odaCanal.ActualizarCanal(con, obeCanal, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdCanal, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCanal odaCanal = new daCanal();
                    exito = odaCanal.ActualizarEstado(con, IdCanal, Estado, usuario);
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
