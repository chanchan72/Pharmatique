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
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "lstObePais" de tipo "List<bePais>"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
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

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "idPais" de tipo "int"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
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

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ActualizarPais
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "exito" de tipo "bool"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
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
