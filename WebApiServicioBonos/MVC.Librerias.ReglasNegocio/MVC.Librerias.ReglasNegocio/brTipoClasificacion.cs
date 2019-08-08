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
    public class brTipoClasificacion : brGeneral
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "lstObePais" de tipo "List<bePais>"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public List<beTipoClasificacion> ListarTipoClasificacion()
        {
            List<beTipoClasificacion> lstObeTipoClasificacion = new List<beTipoClasificacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoClasificacion odaTipoClasificacion = new daTipoClasificacion();
                    lstObeTipoClasificacion = odaTipoClasificacion.ListarTipoClasificacion(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeTipoClasificacion;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "idPais" de tipo "int"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public int AdicionarTipoClasificacion(beTipoClasificacion obeTipoClasificacion, string usuario)
        {
            int idTipoClasificacion = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoClasificacion odaTipoClasificacion = new daTipoClasificacion();
                    idTipoClasificacion = odaTipoClasificacion.AdicionarTipoClasificacion(con, obeTipoClasificacion, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idTipoClasificacion;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ActualizarPais
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "exito" de tipo "bool"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public bool ActualizarTipoClasificacion(beTipoClasificacion obeTipoClasificacion,string usuario )
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoClasificacion odaTipoClasificacion = new daTipoClasificacion();
                    exito = odaTipoClasificacion.ActualizarTipoClasificacion(con, obeTipoClasificacion, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdTipoClasificacion, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoClasificacion odaTipoClasificacion = new daTipoClasificacion();
                    exito = odaTipoClasificacion.ActualizarEstado(con, IdTipoClasificacion, Estado, usuario);
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
