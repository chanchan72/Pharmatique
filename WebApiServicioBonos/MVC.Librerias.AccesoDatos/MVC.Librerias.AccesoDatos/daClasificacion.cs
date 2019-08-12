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
    public class daClasificacion
    {
        
        public List<beClasificacion> ListarClasificacion(SqlConnection con)
        {
            List<beClasificacion> lstObeClasificacion = new List<beClasificacion>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Clasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beClasificacion obeClasificacion;
                int posIdClasificacion = drd.GetOrdinal("ID_CLASIFICACION");
                int posNombre = drd.GetOrdinal("CLASIFICACION");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeClasificacion = new beClasificacion();
                    obeClasificacion.ID_Clasificacion = drd.GetInt32(posIdClasificacion);
                    obeClasificacion.NOMBRE_Clasificacion = drd.GetString(posNombre);
                    obeClasificacion.ESTADO = drd.GetString(posEstado);
                    lstObeClasificacion.Add(obeClasificacion);
                }
            }
            drd.Close();
            return lstObeClasificacion;
        }

        
        public int AdicionarClasificacion(SqlConnection con, beClasificacion obeClasificacion, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Clasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeClasificacion.NOMBRE_Clasificacion);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarClasificacion(SqlConnection con, beClasificacion obeClasificacion, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Clasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Clasificacion", obeClasificacion.ID_Clasificacion);
            cmd.Parameters.AddWithValue("@NOMBRE", obeClasificacion.NOMBRE_Clasificacion);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdClasificacion, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Clasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLASIFICACION", IdClasificacion);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public int CargueMasivo(SqlConnection con, string Cadena)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Clasificacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CADENA", Cadena);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }
    }
}
