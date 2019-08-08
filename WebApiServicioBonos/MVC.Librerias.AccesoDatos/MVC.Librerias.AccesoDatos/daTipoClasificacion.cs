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
    public class daTipoClasificacion
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enlace con la base de datos y realiza un select a la tabla "PS_PAISES" para 
        ///          consultar los paises existentes
        /// Retorno: Variable "lstObePais" de tipo "List<bePais>"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public List<beTipoClasificacion> ListarTipoClasificacion(SqlConnection con)
        {
            List<beTipoClasificacion> lstObeTipoClasificacion = new List<beTipoClasificacion>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_TipoClasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beTipoClasificacion obeTipoClasificacion;
        int posIdTipoClasificacion = drd.GetOrdinal("ID_TIPO_CLASIFICACION_PUNTO_VENTA");
                int posNombre = drd.GetOrdinal("CLASIFICACION_PUNTO_VENTA");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeTipoClasificacion = new beTipoClasificacion();
                    obeTipoClasificacion.ID_TipoClasificacion = drd.GetInt32(posIdTipoClasificacion);
                    obeTipoClasificacion.NOMBRE_TipoClasificacion = drd.GetString(posNombre);
                    obeTipoClasificacion.ESTADO = drd.GetString(posEstado);
                    lstObeTipoClasificacion.Add(obeTipoClasificacion);
                }
            }
            drd.Close();
            return lstObeTipoClasificacion;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un insert a la tabla "PS_PAISES" para 
        ///          ingresar un pais nuevo
        /// Retorno: Variable "idElemento" de tipo "int"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public int AdicionarTipoClasificacion(SqlConnection con, beTipoClasificacion obeTipoClasificacion, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_TipoClasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeTipoClasificacion.NOMBRE_TipoClasificacion);
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
        public bool ActualizarTipoClasificacion(SqlConnection con, beTipoClasificacion obeTipoClasificacion, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_TipoClasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_TipoClasificacion", obeTipoClasificacion.ID_TipoClasificacion);
            cmd.Parameters.AddWithValue("@NOMBRE", obeTipoClasificacion.NOMBRE_TipoClasificacion);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdTipoClasificacion, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_TipoClasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_TIPOCLASIFICACION", IdTipoClasificacion);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
