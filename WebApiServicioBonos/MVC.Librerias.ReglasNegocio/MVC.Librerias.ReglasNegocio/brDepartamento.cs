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
    /// <summary>
    /// Autor: Sebastian Mateus Villegas
    /// Nombre de la clase: brDepartamento
    /// Función: Capa intermedia que hace el enlace entre el controlador de Departamentos y el acceso a datos de departamentos
    ///          con el fin de poner validaciones especificas del negocio.
    /// Fecha Documentación: 8 de abril de 2019
    /// </summary>
    public class brDepartamento : brGeneral
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarDepartamento
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "lstObeDepartamento" de tipo "List<beDepartamento>"
        /// Fecha Documentación: 8 de abril de 2019
        /// </summary>
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

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarDepartamento
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "idDepartamento" de tipo "int"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
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

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ActualizarDepartamento
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "exito" de tipo "bool"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
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
