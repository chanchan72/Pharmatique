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
    public class brLinea : brGeneral
    {
        
        public List<beLinea> ListarLinea()
        {
            List<beLinea> lstObeLinea = new List<beLinea>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLinea odaLinea = new daLinea();
                    lstObeLinea = odaLinea.ListarLinea(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeLinea;
        }

        
        public int AdicionarLinea(beLinea obeLinea, string usuario)
        {
            int idLinea = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLinea odaLinea = new daLinea();
                    idLinea = odaLinea.AdicionarLinea(con, obeLinea, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idLinea;
        }

        
        public bool ActualizarLinea(beLinea obeLinea, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLinea odaLinea = new daLinea();
                    exito = odaLinea.ActualizarLinea(con, obeLinea, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdLinea, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLinea odaLinea = new daLinea();
                    exito = odaLinea.ActualizarEstado(con, IdLinea, Estado, usuario);
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
