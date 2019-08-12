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
