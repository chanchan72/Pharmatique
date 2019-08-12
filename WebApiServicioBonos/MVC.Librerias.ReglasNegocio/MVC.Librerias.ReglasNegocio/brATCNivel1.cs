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
    public class brATCNivel1 : brGeneral
    {
        
        public List<beATCNivel1> ListarATCNivel1()
        {
            List<beATCNivel1> lstObeATCNivel1 = new List<beATCNivel1>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daATCNivel1 odaATCNivel1 = new daATCNivel1();
                    lstObeATCNivel1 = odaATCNivel1.ListarATCNivel1(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeATCNivel1;
        }

        
        public int AdicionarATCNivel1(beATCNivel1 obeATCNivel1, string usuario)
        {
            int idATCNivel1 = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daATCNivel1 odaATCNivel1 = new daATCNivel1();
                    idATCNivel1 = odaATCNivel1.AdicionarATCNivel1(con, obeATCNivel1, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idATCNivel1;
        }

        
        public bool ActualizarATCNivel1(beATCNivel1 obeATCNivel1, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daATCNivel1 odaATCNivel1 = new daATCNivel1();
                    exito = odaATCNivel1.ActualizarATCNivel1(con, obeATCNivel1, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdATCNivel1, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daATCNivel1 odaATCNivel1 = new daATCNivel1();
                    exito = odaATCNivel1.ActualizarEstado(con, IdATCNivel1, Estado, usuario);
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
