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
    public class daLinea
    {
    
        public List<beLinea> ListarLinea(SqlConnection con)
        {
            List<beLinea> lstObeLinea = new List<beLinea>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Linea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beLinea obeLinea;
                int posIdLinea = drd.GetOrdinal("ID_LINEA");
                int posNombre = drd.GetOrdinal("LINEA");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeLinea = new beLinea();
                    obeLinea.ID_Linea = drd.GetInt32(posIdLinea);
                    obeLinea.NOMBRE_Linea = drd.GetString(posNombre);
                    obeLinea.ESTADO = drd.GetString(posEstado);
                    lstObeLinea.Add(obeLinea);
                }
            }
            drd.Close();
            return lstObeLinea;
        }

        
        public int AdicionarLinea(SqlConnection con, beLinea obeLinea, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Linea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeLinea.NOMBRE_Linea);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarLinea(SqlConnection con, beLinea obeLinea, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Linea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Linea", obeLinea.ID_Linea);
            cmd.Parameters.AddWithValue("@NOMBRE", obeLinea.NOMBRE_Linea);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdLinea, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Linea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LINEA", IdLinea);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
