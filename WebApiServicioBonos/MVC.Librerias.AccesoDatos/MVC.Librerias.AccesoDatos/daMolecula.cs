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
    public class daMolecula
    {
        
        public List<beMolecula> ListarMolecula(SqlConnection con)
        {
            List<beMolecula> lstObeMolecula = new List<beMolecula>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Molecula", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beMolecula obeMolecula;
                int posIdMolecula = drd.GetOrdinal("ID_MOLECULA");
                int posNombre = drd.GetOrdinal("MOLECULA");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeMolecula = new beMolecula();
                    obeMolecula.ID_Molecula = drd.GetInt32(posIdMolecula);
                    obeMolecula.NOMBRE_Molecula = drd.GetString(posNombre);
                    obeMolecula.ESTADO = drd.GetString(posEstado);
                    lstObeMolecula.Add(obeMolecula);
                }
            }
            drd.Close();
            return lstObeMolecula;
        }

       
        public int AdicionarMolecula(SqlConnection con, beMolecula obeMolecula, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Molecula", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeMolecula.NOMBRE_Molecula);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarMolecula(SqlConnection con, beMolecula obeMolecula, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Molecula", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Molecula", obeMolecula.ID_Molecula);
            cmd.Parameters.AddWithValue("@NOMBRE", obeMolecula.NOMBRE_Molecula);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdMolecula, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Molecula", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_MOLECULA", IdMolecula);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public int CargueMasivo(SqlConnection con, string Cadena)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Molecula", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CADENA", Cadena);//"'Peru','A';'Guatemala','A'");
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }
    }
}
