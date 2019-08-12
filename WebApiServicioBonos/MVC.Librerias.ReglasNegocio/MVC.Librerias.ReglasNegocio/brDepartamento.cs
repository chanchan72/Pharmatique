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
    
    public class brDepartamento : brGeneral
    {
       
        public beDatosGeograficos ListarDepartamento()
        {
            beDatosGeograficos lstObeDepartamento = new beDatosGeograficos();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDepartamentos odaDepartamento = new daDepartamentos();
                    lstObeDepartamento = odaDepartamento.ListaDepartamento(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeDepartamento;
        }

        
        public int AdicionarDepartamento( string usuario)
        {
            int idDepartamento = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDepartamentos odaDepartamento = new daDepartamentos();
                    idDepartamento = odaDepartamento.AdicionarDepartamento(con,"");
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idDepartamento;
        }

        
        public bool ActualizarDepartamento( string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDepartamentos odaDepartamento = new daDepartamentos();
                    exito = odaDepartamento.ActualizarDepartamento(con, "");
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
            int idDepartamento = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDepartamentos odaDepartamentos = new daDepartamentos();
                    idDepartamento = odaDepartamentos.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idDepartamento;
        }

        public bool ActualizarEstado(int IdDepartamento, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDepartamentos odaDepartamentos = new daDepartamentos();
                    exito = odaDepartamentos.ActualizarEstado(con, IdDepartamento, Estado, usuario);
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
