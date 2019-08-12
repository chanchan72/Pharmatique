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
    public class brMarca : brGeneral
    {
        
        public List<beMarca> ListarMarca()
        {
            List<beMarca> lstObeMarca = new List<beMarca>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMarca odaMarca = new daMarca();
                    lstObeMarca = odaMarca.ListarMarca(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeMarca;
        }

        
        public int AdicionarMarca(beMarca obeMarca, string usuario)
        {
            int idMarca = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMarca odaMarca = new daMarca();
                    idMarca = odaMarca.AdicionarMarca(con, obeMarca, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idMarca;
        }

       
        public bool ActualizarMarca(beMarca obeMarca, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMarca odaMarca = new daMarca();
                    exito = odaMarca.ActualizarMarca(con, obeMarca, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdMarca, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMarca odaMarca = new daMarca();
                    exito = odaMarca.ActualizarEstado(con, IdMarca, Estado, usuario);
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
            int idMarca = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMarca odaMarca = new daMarca();
                    idMarca = odaMarca.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idMarca;
        }
    }
}
