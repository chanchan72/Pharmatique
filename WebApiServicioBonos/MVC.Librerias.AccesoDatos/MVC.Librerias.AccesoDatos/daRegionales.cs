﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Libreria.EntidadesNegocio;
using System.Data.SqlClient;
using System.Data;

namespace MVC.Libreria.AccesoDatos
{
    public class daRegionales
    {
        
        public List<beRegionales> ListarRegional(SqlConnection con)
        {
            List<beRegionales> lstObeRegionales = new List<beRegionales>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Regional", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beRegionales obeRegional;
                int posIdRegional = drd.GetOrdinal("ID_REGIONAL");
                int posCodigoRegional = drd.GetOrdinal("CODIGO_REGIONAL");
                int posRegional = drd.GetOrdinal("REGIONAL");
                int posEstado = drd.GetOrdinal("ESTADO_");
                while (drd.Read())
                {
                    obeRegional = new beRegionales();
                    obeRegional.ID_REGIONAL = drd.GetInt32(posIdRegional);
                    obeRegional.CODIGO_REGIONAL = drd.GetString(posCodigoRegional);
                    obeRegional.REGIONAL = drd.GetString(posRegional);
                    obeRegional.ESTADO = drd.GetString(posEstado);
                    lstObeRegionales.Add(obeRegional);
                }
            }
            drd.Close();
            return lstObeRegionales;
        }

        
        public int AdicionarRegional(SqlConnection con, beRegionales obeRegional, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Regional", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", obeRegional.CODIGO_REGIONAL);
            cmd.Parameters.AddWithValue("@NOMBRE", obeRegional.REGIONAL);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

       
        public bool ActualizarRegional(SqlConnection con, beRegionales obeRegional, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Regional", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_REGIONAL", obeRegional.ID_REGIONAL);
            cmd.Parameters.AddWithValue("@CODIGO", obeRegional.CODIGO_REGIONAL);
            cmd.Parameters.AddWithValue("@NOMBRE", obeRegional.REGIONAL);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }


        public bool ActualizarEstado(SqlConnection con, int IdRegional, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Regional", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_REGIONAL", IdRegional);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
