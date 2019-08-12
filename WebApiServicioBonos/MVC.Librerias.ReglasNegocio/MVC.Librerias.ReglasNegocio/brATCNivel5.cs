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
    public class brATCNivel5 : brGeneral
    {
        
        public List<beATCNivel5> ListarATCNivel5()
        {
            List<beATCNivel5> lstObeATCNivel5 = new List<beATCNivel5>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daATCNivel5 odaATCNivel5 = new daATCNivel5();
                    lstObeATCNivel5 = odaATCNivel5.ListarATCNivel5(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeATCNivel5;
        }

        
        public int AdicionarATCNivel5(beATCNivel5 obeATCNivel5, string usuario)
        {
            int idATCNivel5 = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daATCNivel5 odaATCNivel5 = new daATCNivel5();
                    idATCNivel5 = odaATCNivel5.AdicionarATCNivel5(con, obeATCNivel5, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idATCNivel5;
        }

        
        public bool ActualizarATCNivel5(beATCNivel5 obeATCNivel5, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daATCNivel5 odaATCNivel5 = new daATCNivel5();
                    exito = odaATCNivel5.ActualizarATCNivel5(con, obeATCNivel5, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdATCNivel5, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daATCNivel5 odaATCNivel5 = new daATCNivel5();
                    exito = odaATCNivel5.ActualizarEstado(con, IdATCNivel5, Estado, usuario);
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
