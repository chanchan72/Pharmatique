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
    /// Nombre de la clase: brCiudad
    /// Función: Capa intermedia que hace el enlace entre el controlador de Ciudad y el acceso a datos de departamentos
    ///          con el fin de poner validaciones especificas del negocio.
    /// Fecha Documentación: 8 de abril de 2019
    /// </summary>
    public class brCiudad : brGeneral
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarCiudad
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "lstObeCiudad" de tipo "beDatosGraficos"
        /// Fecha Documentación: 8 de abril de 2019
        /// </summary>
        public beDatosGeograficos ListarCiudad()
        {
            beDatosGeograficos lstObeCiudad = new beDatosGeograficos();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaDepartamento = new daCiudad();
                    lstObeCiudad = odaDepartamento.ListaCiudad(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeCiudad;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarCiudad
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "idCiudad" de tipo "int"
        /// Fecha Documentación: 8 de abril de 2019
        /// </summary>
        public int AdicionarCiudad(beCiudad obeCiudad, string usuario)
        {
            int idCiudad = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaDepartamento = new daCiudad();
                    idCiudad = odaDepartamento.AdicionarCiudad(con, obeCiudad, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idCiudad;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ActualizarCiudad
        /// Función: Enlace con el acceso a datos y establece la cadena de conexion con la base de datos 
        /// Retorno: Variable "exito" de tipo "bool"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public bool ActualizarCiudad(beCiudad obeCiudad, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaCiudad = new daCiudad();
                    exito = odaCiudad.ActualizarCiudad(con, obeCiudad,usuario);
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
            int idCiudad = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaCiudad = new daCiudad();
                    idCiudad = odaCiudad.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idCiudad;
        }

        public bool ActualizarEstado(int IdCiudad, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaCiudad = new daCiudad();
                    exito = odaCiudad.ActualizarEstado(con, IdCiudad, Estado, usuario);
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
