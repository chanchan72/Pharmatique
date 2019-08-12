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
    public class daMarca
    {
        
        public List<beMarca> ListarMarca(SqlConnection con)
        {
            List<beMarca> lstObeMarca = new List<beMarca>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Marca", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beMarca obeMarca;
                int posIdMarca = drd.GetOrdinal("ID_MARCA");
                int posNombre = drd.GetOrdinal("MARCA");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeMarca = new beMarca();
                    obeMarca.ID_Marca = drd.GetInt32(posIdMarca);
                    obeMarca.NOMBRE_Marca = drd.GetString(posNombre);
                    obeMarca.ESTADO = drd.GetString(posEstado);
                    lstObeMarca.Add(obeMarca);
                }
            }
            drd.Close();
            return lstObeMarca;
        }

        
        public int AdicionarMarca(SqlConnection con, beMarca obeMarca, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Marca", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeMarca.NOMBRE_Marca);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarMarca(SqlConnection con, beMarca obeMarca, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Marca", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Marca", obeMarca.ID_Marca);
            cmd.Parameters.AddWithValue("@NOMBRE", obeMarca.NOMBRE_Marca);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }


        public bool ActualizarEstado(SqlConnection con, int IdMarca, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Marca", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_MARCA", IdMarca);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public int CargueMasivo(SqlConnection con, string Cadena)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Marca", con);
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
