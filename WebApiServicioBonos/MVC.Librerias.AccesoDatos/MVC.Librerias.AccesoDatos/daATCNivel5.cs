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
    public class daATCNivel5
    {
        
        public List<beATCNivel5> ListarATCNivel5(SqlConnection con)
        {
            List<beATCNivel5> lstObeATCNivel5 = new List<beATCNivel5>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_ATCNivel5", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beATCNivel5 obeATCNivel5;
                int posIdATCNivel5 = drd.GetOrdinal("ID_ATC_NIVEL5");
                int posNombre = drd.GetOrdinal("ATC_NIVEL5");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeATCNivel5 = new beATCNivel5();
                    obeATCNivel5.ID_ATCNivel5 = drd.GetInt32(posIdATCNivel5);
                    obeATCNivel5.NOMBRE_ATCNivel5 = drd.GetString(posNombre);
                    obeATCNivel5.ESTADO = drd.GetString(posEstado);
                    lstObeATCNivel5.Add(obeATCNivel5);
                }
            }
            drd.Close();
            return lstObeATCNivel5;
        }

       
        public int AdicionarATCNivel5(SqlConnection con, beATCNivel5 obeATCNivel5, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_ATCNivel5", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeATCNivel5.NOMBRE_ATCNivel5);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarATCNivel5(SqlConnection con, beATCNivel5 obeATCNivel5, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_ATCNivel5", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ATCNivel5", obeATCNivel5.ID_ATCNivel5);
            cmd.Parameters.AddWithValue("@NOMBRE", obeATCNivel5.NOMBRE_ATCNivel5);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }


        public bool ActualizarEstado(SqlConnection con, int IdATCNivel5, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_ATCNivel5", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ATCNIVEL5", IdATCNivel5);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
