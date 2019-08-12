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
    public class brLineaTerapeutica : brGeneral
    {
        
        public List<beLineaTerapeutica> ListarLineaTerapeutica()
        {
            List<beLineaTerapeutica> lstObeLineaTerapeutica = new List<beLineaTerapeutica>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLineaTerapeutica odaLineaTerapeutica = new daLineaTerapeutica();
                    lstObeLineaTerapeutica = odaLineaTerapeutica.ListarLineaTerapeutica(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeLineaTerapeutica;
        }

        
        public int AdicionarLineaTerapeutica(beLineaTerapeutica obeLineaTerapeutica, string usuario)
        {
            int idLineaTerapeutica = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLineaTerapeutica odaLineaTerapeutica = new daLineaTerapeutica();
                    idLineaTerapeutica = odaLineaTerapeutica.AdicionarLineaTerapeutica(con, obeLineaTerapeutica, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idLineaTerapeutica;
        }

        
        public bool ActualizarLineaTerapeutica(beLineaTerapeutica obeLineaTerapeutica, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLineaTerapeutica odaLineaTerapeutica = new daLineaTerapeutica();
                    exito = odaLineaTerapeutica.ActualizarLineaTerapeutica(con, obeLineaTerapeutica, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }


        public bool ActualizarEstado(int IdLineaTerapeutica, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daLineaTerapeutica odaLineaTerapeutica = new daLineaTerapeutica();
                    exito = odaLineaTerapeutica.ActualizarEstado(con, IdLineaTerapeutica, Estado, usuario);
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
