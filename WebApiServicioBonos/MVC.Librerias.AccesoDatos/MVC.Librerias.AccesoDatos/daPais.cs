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
    
    public class daPais
    {
        
        public List<bePais> ListarPais(SqlConnection con)
        {
            List<bePais> lstObePais = new List<bePais>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Paises", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                bePais obePais;
                int posIdPais = drd.GetOrdinal("ID_PAIS");
                int posNombre = drd.GetOrdinal("NOMBRE_PAIS");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obePais = new bePais();
                    obePais.ID_PAIS = drd.GetInt32(posIdPais);
                    obePais.NOMBRE_PAIS = drd.GetString(posNombre);
                    obePais.ESTADO = drd.GetString(posEstado);
                    lstObePais.Add(obePais);
                }
            }
            drd.Close();
            return lstObePais;
        }

       
        public int AdicionarPais(SqlConnection con, bePais obePais, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Paises", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obePais.NOMBRE_PAIS);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarPais(SqlConnection con, bePais obePais, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Paises", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PAIS", obePais.ID_PAIS);
            cmd.Parameters.AddWithValue("@NOMBRE", obePais.NOMBRE_PAIS);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
        public bool ActualizarEstado(SqlConnection con,int IdPais, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Paises", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PAIS", IdPais);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public int CargueMasivo(SqlConnection con, string Cadena) 
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Paises", con);
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
