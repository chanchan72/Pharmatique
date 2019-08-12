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
    public class daPortafolio
    {
        
        public List<bePortafolio> ListarPortafolio(SqlConnection con)
        {
            List<bePortafolio> lstObePortafolio = new List<bePortafolio>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Portafolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                bePortafolio obePortafolio;
                int posIdPortafolio = drd.GetOrdinal("ID_Portafolio");
                int posNombre = drd.GetOrdinal("Portafolio");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obePortafolio = new bePortafolio();
                    obePortafolio.ID_Portafolio = drd.GetInt32(posIdPortafolio);
                    obePortafolio.NOMBRE_Portafolio = drd.GetString(posNombre);
                    obePortafolio.ESTADO = drd.GetString(posEstado);
                    lstObePortafolio.Add(obePortafolio);
                }
            }
            drd.Close();
            return lstObePortafolio;
        }

        
        public int AdicionarPortafolio(SqlConnection con, bePortafolio obePortafolio, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Portafolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obePortafolio.NOMBRE_Portafolio);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

     
        public bool ActualizarPortafolio(SqlConnection con, bePortafolio obePortafolio, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Portafolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Portafolio", obePortafolio.ID_Portafolio);
            cmd.Parameters.AddWithValue("@NOMBRE", obePortafolio.NOMBRE_Portafolio);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdPortafolio, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Portafolio", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PORTAFOLIO", IdPortafolio);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
