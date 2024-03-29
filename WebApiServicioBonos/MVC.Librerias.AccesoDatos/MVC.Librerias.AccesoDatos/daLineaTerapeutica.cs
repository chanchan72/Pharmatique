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
    public class daLineaTerapeutica
    {
        
        public List<beLineaTerapeutica> ListarLineaTerapeutica(SqlConnection con)
        {
            List<beLineaTerapeutica> lstObeLineaTerapeutica = new List<beLineaTerapeutica>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_LineaTerapeutica", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beLineaTerapeutica obeLineaTerapeutica;
                int posIdLineaTerapeutica = drd.GetOrdinal("ID_LINEA_TERAPEUTICA");
                int posNombre = drd.GetOrdinal("LINEA_TERAPEUTICA");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeLineaTerapeutica = new beLineaTerapeutica();
                    obeLineaTerapeutica.ID_LineaTerapeutica = drd.GetInt32(posIdLineaTerapeutica);
                    obeLineaTerapeutica.NOMBRE_LineaTerapeutica = drd.GetString(posNombre);
                    obeLineaTerapeutica.ESTADO = drd.GetString(posEstado);
                    lstObeLineaTerapeutica.Add(obeLineaTerapeutica);
                }
            }
            drd.Close();
            return lstObeLineaTerapeutica;
        }

        
        public int AdicionarLineaTerapeutica(SqlConnection con, beLineaTerapeutica obeLineaTerapeutica, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_LineaTerapeutica", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeLineaTerapeutica.NOMBRE_LineaTerapeutica);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarLineaTerapeutica(SqlConnection con, beLineaTerapeutica obeLineaTerapeutica, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_LineaTerapeutica", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LineaTerapeutica", obeLineaTerapeutica.ID_LineaTerapeutica);
            cmd.Parameters.AddWithValue("@NOMBRE", obeLineaTerapeutica.NOMBRE_LineaTerapeutica);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdLineaTerapeutica, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_LineaTerapeutica", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_LINEA_TERAPEUTICA", IdLineaTerapeutica);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

    }
}
