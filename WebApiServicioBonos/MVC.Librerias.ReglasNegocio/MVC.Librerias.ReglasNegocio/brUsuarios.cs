using System;
using System.Collections.Generic;
using System.Data;
using MVC.Librerias.EntidadesNegocio;
using MVC.Librerias.AccesoDatos;
using General.Librerias.AccesoDatos.GestionUsuarios;
using General.Librerias.Entidades.GestionUsuarios;
using System.Data.SqlClient;

namespace MVC.Librerias.ReglasNegocio
{
    public class brUsuarios : brGeneral
    {
        public beDatosUsuario ObtenerListas(beLogin obeLogin)
        {
            beDatosUsuario obeDatosUsuario = new beDatosUsuario();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUsuarios odaUsuarios = new daUsuarios();
                    obeDatosUsuario = odaUsuarios.LoginUsuario(con, obeLogin);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return obeDatosUsuario;
        }

        public beDatosUsuariosGestion ListaUsuariosGestion()
        {
            beDatosUsuariosGestion obeDatosUsuariosGestion = new beDatosUsuariosGestion();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosUsuariosGestion odaDatosUsuariosGestion = new daDatosUsuariosGestion();
                    obeDatosUsuariosGestion = odaDatosUsuariosGestion.ListaUsuarios(con, aplicacion);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return obeDatosUsuariosGestion;
        }

        public beDatosUsuarioAplicacionesGestion ValidarUsuario(string loginName)
        {
            beDatosUsuarioAplicacionesGestion obeDatosUsuarioAplicacionesGestion = new beDatosUsuarioAplicacionesGestion();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosUsuariosGestion odaDatosUsuariosGestion = new daDatosUsuariosGestion();
                    obeDatosUsuarioAplicacionesGestion = odaDatosUsuariosGestion.ValidarUsuario(con, loginName);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return obeDatosUsuarioAplicacionesGestion;
        }

        public int AdicionarUsuario(beUsuarioGestion obeUsuarioGestion, string cadenaTbRol)
        {
            int idUsuario = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosUsuariosGestion odaDatosUsuariosGestion = new daDatosUsuariosGestion();
                    idUsuario = odaDatosUsuariosGestion.AdicionarUsuario(con, obeUsuarioGestion, cadenaTbRol);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idUsuario;
        }

        public bool ActualizarUsuario(beUsuarioGestion obeUsuarioGestion, string cadenaTbRol)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDatosUsuariosGestion odaDatosUsuariosGestion = new daDatosUsuariosGestion();
                    exito = odaDatosUsuariosGestion.ActualizarUsuario(con, obeUsuarioGestion, cadenaTbRol);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }
    }
}