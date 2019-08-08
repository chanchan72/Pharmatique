using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Libreria.EntidadesNegocio;
using System.Data.SqlClient;
using System.Data;

namespace MVC.Libreria.AccesoDatos
{
    public class daUnidadNegocio
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enlace con la base de datos y realiza un select a la tabla "PS_PAISES" para 
        ///          consultar los paises existentes
        /// Retorno: Variable "lstObePais" de tipo "List<bePais>"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public List<beUnidadNegocio> ListarUnidadNegocio(SqlConnection con)
        {
            List<beUnidadNegocio> lstObeUnidadNegocio = new List<beUnidadNegocio>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_UnidadNegocio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beUnidadNegocio obeUnidadNegocio;
                int posIdUnidadNegocio = drd.GetOrdinal("ID_UNIDAD_NEGOCIO");
                int posNombre = drd.GetOrdinal("UNIDAD_NEGOCIO");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeUnidadNegocio = new beUnidadNegocio();
                    obeUnidadNegocio.ID_UnidadNegocio = drd.GetInt32(posIdUnidadNegocio);
                    obeUnidadNegocio.NOMBRE_UnidadNegocio = drd.GetString(posNombre);
                    obeUnidadNegocio.ESTADO = drd.GetString(posEstado);
                    lstObeUnidadNegocio.Add(obeUnidadNegocio);
                }
            }
            drd.Close();
            return lstObeUnidadNegocio;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un insert a la tabla "PS_PAISES" para 
        ///          ingresar un pais nuevo
        /// Retorno: Variable "idElemento" de tipo "int"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public int AdicionarUnidadNegocio(SqlConnection con, beUnidadNegocio obeUnidadNegocio, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_UnidadNegocio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeUnidadNegocio.NOMBRE_UnidadNegocio);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un update a la tabla "PS_PAISES" para 
        ///          actualizar un pais que este en la tabla
        /// Retorno: Variable "exito" de tipo "bool"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public bool ActualizarUnidadNegocio(SqlConnection con, beUnidadNegocio obeUnidadNegocio, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_UnidadNegocio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_UnidadNegocio", obeUnidadNegocio.ID_UnidadNegocio);
            cmd.Parameters.AddWithValue("@NOMBRE", obeUnidadNegocio.NOMBRE_UnidadNegocio);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdUnidadNegocio, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_UnidadNegocio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_UNIDADNEGOCIO", IdUnidadNegocio);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
