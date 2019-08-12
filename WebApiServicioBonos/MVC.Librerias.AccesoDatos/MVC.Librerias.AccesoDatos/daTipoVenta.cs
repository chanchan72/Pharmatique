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
    public class daTipoVenta
    {
   
        public List<beTipoVenta> ListarTipoVenta(SqlConnection con)
        {
            List<beTipoVenta> lstObeTipoVenta = new List<beTipoVenta>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_TipoVenta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beTipoVenta obeTipoVenta;
                int posIdTipoVenta = drd.GetOrdinal("ID_TIPO_VENTA");
                int posNombre = drd.GetOrdinal("TIPO_VENTA");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeTipoVenta = new beTipoVenta();
                    obeTipoVenta.ID_TipoVenta = drd.GetInt32(posIdTipoVenta);
                    obeTipoVenta.NOMBRE_TipoVenta = drd.GetString(posNombre);
                    obeTipoVenta.ESTADO = drd.GetString(posEstado);
                    lstObeTipoVenta.Add(obeTipoVenta);
                }
            }
            drd.Close();
            return lstObeTipoVenta;
        }

        public int AdicionarTipoVenta(SqlConnection con, beTipoVenta obeTipoVenta,string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_TipoVenta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeTipoVenta.NOMBRE_TipoVenta);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        public bool ActualizarTipoVenta(SqlConnection con, beTipoVenta obeTipoVenta, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_TipoVenta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_TipoVenta", obeTipoVenta.ID_TipoVenta);
            cmd.Parameters.AddWithValue("@NOMBRE", obeTipoVenta.NOMBRE_TipoVenta);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdTipoVenta, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_TipoVenta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_TIPOVENTA", IdTipoVenta);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
