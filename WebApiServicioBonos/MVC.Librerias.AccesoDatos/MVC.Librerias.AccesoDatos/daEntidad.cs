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
    public class daEntidad
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enlace con la base de datos y realiza un select a la tabla "PS_PAISES" para 
        ///          consultar los paises existentes
        /// Retorno: Variable "lstObePais" de tipo "List<bePais>"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public List<beEntidad> ListarEntidad(SqlConnection con)
        {
            List<beEntidad> lstObeEntidad = new List<beEntidad>();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Entidad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                beEntidad obeEntidad;
                int posIdEntidad = drd.GetOrdinal("ID_ENTIDAD");
                int posNombre = drd.GetOrdinal("ENTIDAD");
                int posEstado = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeEntidad = new beEntidad();
                    obeEntidad.ID_Entidad = drd.GetInt32(posIdEntidad);
                    obeEntidad.NOMBRE_Entidad = drd.GetString(posNombre);
                    obeEntidad.ESTADO = drd.GetString(posEstado);
                    lstObeEntidad.Add(obeEntidad);
                }
            }
            drd.Close();
            return lstObeEntidad;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un insert a la tabla "PS_PAISES" para 
        ///          ingresar un pais nuevo
        /// Retorno: Variable "idElemento" de tipo "int"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public int AdicionarEntidad(SqlConnection con, beEntidad obeEntidad, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Entidad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", obeEntidad.NOMBRE_Entidad);
            cmd.Parameters.AddWithValue("@ESTADO", obeEntidad.ESTADO);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un update a la tabla "PS_PAISES" para 
        ///          actualizar un pais que este en la tabla
        /// Retorno: Variable "exito" de tipo "bool"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public bool ActualizarEntidad(SqlConnection con, beEntidad obeEntidad, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Entidad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Entidad", obeEntidad.ID_Entidad);
            cmd.Parameters.AddWithValue("@NOMBRE", obeEntidad.NOMBRE_Entidad);
            cmd.Parameters.AddWithValue("@ESTADO", obeEntidad.ESTADO);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }


        public bool ActualizarEstado(SqlConnection con, int IdEntidad, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Entidad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ENTIDAD", IdEntidad);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public int CargueMasivo(SqlConnection con, string Cadena)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Entidad", con);
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