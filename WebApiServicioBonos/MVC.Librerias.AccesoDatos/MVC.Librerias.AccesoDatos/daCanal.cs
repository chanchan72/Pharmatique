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
    public class daCanal
    {
        
        public List<beCanal> ListarCanal(SqlConnection con)
        {
            List<beCanal> lstObeCanal = new List<beCanal>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Canal", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beCanal obeCanal;
                int posIdCanal = drd.GetOrdinal("ID_CANAL");
                int posNombre = drd.GetOrdinal("CANAL");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeCanal = new beCanal();
                    obeCanal.ID_Canal = drd.GetInt32(posIdCanal);
                    obeCanal.NOMBRE_Canal = drd.GetString(posNombre);
                    obeCanal.ESTADO = drd.GetString(posEstado);
                    lstObeCanal.Add(obeCanal);
                }
            }
            drd.Close();
            return lstObeCanal;
        }

        
        public int AdicionarCanal(SqlConnection con, beCanal obeCanal, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Canal", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeCanal.NOMBRE_Canal);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarCanal(SqlConnection con, beCanal obeCanal, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Canal", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Canal", obeCanal.ID_Canal);
            cmd.Parameters.AddWithValue("@NOMBRE", obeCanal.NOMBRE_Canal);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdCanal, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Canal", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CANAL", IdCanal);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
