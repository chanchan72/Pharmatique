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
    public class brMolecula : brGeneral
    {
        
        public List<beMolecula> ListarMolecula()
        {
            List<beMolecula> lstObeMolecula = new List<beMolecula>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMolecula odaMolecula = new daMolecula();
                    lstObeMolecula = odaMolecula.ListarMolecula(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeMolecula;
        }

        
        public int AdicionarMolecula(beMolecula obeMolecula, string usuario)
        {
            int idMolecula = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMolecula odaMolecula = new daMolecula();
                    idMolecula = odaMolecula.AdicionarMolecula(con, obeMolecula, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idMolecula;
        }

       
        public bool ActualizarMolecula(beMolecula obeMolecula, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMolecula odaMolecula = new daMolecula();
                    exito = odaMolecula.ActualizarMolecula(con, obeMolecula, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdMolecula, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMolecula odaMolecula = new daMolecula();
                    exito = odaMolecula.ActualizarEstado(con, IdMolecula, Estado, usuario);
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
            int idMolecula = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daMolecula odaMolecula = new daMolecula();
                    idMolecula = odaMolecula.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idMolecula;
        }
    }
}
