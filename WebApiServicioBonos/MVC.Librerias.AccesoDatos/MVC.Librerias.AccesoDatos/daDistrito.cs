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
    public class daDistrito
    {
        
        public List<beDistrito> ListarDistrito(SqlConnection con)
        {
            List<beDistrito> lstObeDistrito = new List<beDistrito>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Distrito", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beDistrito obeDistrito;
                int posIdDistrito = drd.GetOrdinal("ID_DISTRITO");
                int posNombre = drd.GetOrdinal("DISTRITO");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeDistrito = new beDistrito();
                    obeDistrito.ID_Distrito = drd.GetInt32(posIdDistrito);
                    obeDistrito.NOMBRE_Distrito = drd.GetString(posNombre);
                    obeDistrito.ESTADO = drd.GetString(posEstado);
                    lstObeDistrito.Add(obeDistrito);
                }
            }
            drd.Close();
            return lstObeDistrito;
        }

        
        public int AdicionarDistrito(SqlConnection con, beDistrito obeDistrito, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Distrito", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeDistrito.NOMBRE_Distrito);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarDistrito(SqlConnection con, beDistrito obeDistrito, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Distrito", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Distrito", obeDistrito.ID_Distrito);
            cmd.Parameters.AddWithValue("@NOMBRE", obeDistrito.NOMBRE_Distrito);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdDistrito, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Distrito", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_DISTRITO", IdDistrito);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

    }
}
