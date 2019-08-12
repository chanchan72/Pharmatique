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
    public class daSubLinea
    {
        
        public List<beSubLinea> ListarSubLinea(SqlConnection con)
        {
            List<beSubLinea> lstObeSubLinea = new List<beSubLinea>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_SubLinea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beSubLinea obeSubLinea;
                int posIdSubLinea = drd.GetOrdinal("ID_SUBLINEA");
                int posNombre = drd.GetOrdinal("SUBLINEA");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeSubLinea = new beSubLinea();
                    obeSubLinea.ID_SubLinea = drd.GetInt32(posIdSubLinea);
                    obeSubLinea.NOMBRE_SubLinea = drd.GetString(posNombre);
                    obeSubLinea.ESTADO = drd.GetString(posEstado);
                    lstObeSubLinea.Add(obeSubLinea);
                }
            }
            drd.Close();
            return lstObeSubLinea;
        }

        
        public int AdicionarSubLinea(SqlConnection con, beSubLinea obeSubLinea, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_SubLinea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeSubLinea.NOMBRE_SubLinea);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarSubLinea(SqlConnection con, beSubLinea obeSubLinea, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_SubLinea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SubLinea", obeSubLinea.ID_SubLinea);
            cmd.Parameters.AddWithValue("@NOMBRE", obeSubLinea.NOMBRE_SubLinea);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdSubLinea, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_SubLinea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SUBLINEA", IdSubLinea);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

    }
}
