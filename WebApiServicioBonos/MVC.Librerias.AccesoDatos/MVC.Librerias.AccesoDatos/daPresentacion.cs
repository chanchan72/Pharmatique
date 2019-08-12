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
    public class daPresentacion
    {
        
        public List<bePresentacion> ListarPresentacion(SqlConnection con)
        {
            List<bePresentacion> lstObePresentacion = new List<bePresentacion>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Presentacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                bePresentacion obePresentacion;
                int posIdPresentacion = drd.GetOrdinal("ID_Presentacion");
                int posNombre = drd.GetOrdinal("Presentacion");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obePresentacion = new bePresentacion();
                    obePresentacion.ID_Presentacion = drd.GetInt32(posIdPresentacion);
                    obePresentacion.NOMBRE_Presentacion = drd.GetString(posNombre);
                    obePresentacion.ESTADO = drd.GetString(posEstado);
                    lstObePresentacion.Add(obePresentacion);
                }
            }
            drd.Close();
            return lstObePresentacion;
        }

        
        public int AdicionarPresentacion(SqlConnection con, bePresentacion obePresentacion, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Presentacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obePresentacion.NOMBRE_Presentacion);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarPresentacion(SqlConnection con, bePresentacion obePresentacion, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Presentacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Presentacion", obePresentacion.ID_Presentacion);
            cmd.Parameters.AddWithValue("@NOMBRE", obePresentacion.NOMBRE_Presentacion);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }


        public bool ActualizarEstado(SqlConnection con, int IdPresentacion, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Presentacion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PRESENTACION", IdPresentacion);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public int CargueMasivo(SqlConnection con, string Cadena)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Presentacion", con);
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
