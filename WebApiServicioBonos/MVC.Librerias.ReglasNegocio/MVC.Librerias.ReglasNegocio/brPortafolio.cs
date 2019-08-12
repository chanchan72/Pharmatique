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
    public class brPortafolio : brGeneral
    {
        
        public List<bePortafolio> ListarPortafolio()
        {
            List<bePortafolio> lstObePortafolio = new List<bePortafolio>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPortafolio odaPortafolio = new daPortafolio();
                    lstObePortafolio = odaPortafolio.ListarPortafolio(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObePortafolio;
        }

        
        public int AdicionarPortafolio(bePortafolio obePortafolio, string usuario)
        {
            int idPortafolio = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPortafolio odaPortafolio = new daPortafolio();
                    idPortafolio = odaPortafolio.AdicionarPortafolio(con, obePortafolio, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idPortafolio;
        }

        
        public bool ActualizarPortafolio(bePortafolio obePortafolio, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPortafolio odaPortafolio = new daPortafolio();
                    exito = odaPortafolio.ActualizarPortafolio(con, obePortafolio,usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdPortafolio, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPortafolio odaPortafolio = new daPortafolio();
                    exito = odaPortafolio.ActualizarEstado(con, IdPortafolio, Estado, usuario);
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
