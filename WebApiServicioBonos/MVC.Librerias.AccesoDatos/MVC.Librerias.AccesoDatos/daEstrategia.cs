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
    public class daEstrategia
    {
        
        public List<beEstrategia> ListarEstrategia(SqlConnection con)
        {
            List<beEstrategia> lstObeEstrategia = new List<beEstrategia>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Estrategia", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beEstrategia obeEstrategia;
                int posIdEstrategia = drd.GetOrdinal("ID_ESTRATEGIA");
                int posNombre = drd.GetOrdinal("ESTRATEGIA");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeEstrategia = new beEstrategia();
                    obeEstrategia.ID_Estrategia = drd.GetInt32(posIdEstrategia);
                    obeEstrategia.NOMBRE_Estrategia = drd.GetString(posNombre);
                    obeEstrategia.ESTADO = drd.GetString(posEstado);
                    lstObeEstrategia.Add(obeEstrategia);
                }
            }
            drd.Close();
            return lstObeEstrategia;
        }

        
        public int AdicionarEstrategia(SqlConnection con, beEstrategia obeEstrategia, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Estrategia", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeEstrategia.NOMBRE_Estrategia);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarEstrategia(SqlConnection con, beEstrategia obeEstrategia, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Estrategia", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Estrategia", obeEstrategia.ID_Estrategia);
            cmd.Parameters.AddWithValue("@NOMBRE", obeEstrategia.NOMBRE_Estrategia);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public bool ActualizarEstado(SqlConnection con, int IdEstrategia, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Estategia", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ESTRATEGIA", IdEstrategia);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public int CargueMasivo(SqlConnection con, string Cadena)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Estrategia", con);
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
