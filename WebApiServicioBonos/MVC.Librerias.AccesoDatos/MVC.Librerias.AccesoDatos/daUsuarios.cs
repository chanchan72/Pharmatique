using MVC.Librerias.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MVC.Librerias.AccesoDatos
{
    public class daUsuarios
    {
        public beDatosUsuario LoginUsuario(SqlConnection con, beLogin obeLogin)
        {
            beDatosUsuario obeDatosUsuario = new beDatosUsuario();
            SqlCommand cmd = new SqlCommand("dbo.APLICACIONES_SP_OBTENER_USUARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USUARIO", obeLogin.UserName);
            cmd.Parameters.AddWithValue("@CLAVE", obeLogin.Password);
            cmd.Parameters.AddWithValue("@APLICACION", obeLogin.Aplicacion);
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                obeDatosUsuario.Usuario = new beUsuario();
                beUsuario obeUsuario;
                int posIdLogin = drd.GetOrdinal("ID_LOGIN");
                int posNombres = drd.GetOrdinal("NOMBRES");
                int posApellidos = drd.GetOrdinal("APELLIDOS");
                int posLoginName = drd.GetOrdinal("LOGIN_NAME");
                int posCorreo = drd.GetOrdinal("CORREO");
                int posFechaCreacion = drd.GetOrdinal("FECHA_CREACION");
                int posFechaModificacion = drd.GetOrdinal("FECHA_MODIFICACION");
                int posNumero_Intentos = drd.GetOrdinal("NUMERO_INTENTOS");
                int posIdUnidad = drd.GetOrdinal("ID_UNIDAD");
                int posIdEstado = drd.GetOrdinal("ID_ESTADO");
                int posDescripcion = drd.GetOrdinal("DESCRIPCION_ESTADO_USUARIO");
                int posDescripcionTipo = drd.GetOrdinal("DESCRIPCION_TIPO_ESTADO");
                int posNombreUnidad = drd.GetOrdinal("NOMBRE_UNIDAD");
                int posIdEstadoUnidad = drd.GetOrdinal("ID_ESTADO_UNIDAD");
                int posDescripcionEstado = drd.GetOrdinal("DESCRIPCION_ESTADO_UNIDAD");
                int posNombreUnidadPadre = drd.GetOrdinal("NOMBRE_UNIDAD_PADRE");
                int posIdEstadoUnidadPadre = drd.GetOrdinal("ID_ESTADO_UNIDAD_PADRE");
                int posDescripcionEstadoUnidad = drd.GetOrdinal("DESCRIPCION_ESTADO_UNIDAD_PADRE");
                int posIdUsuarioRegistro = drd.GetOrdinal("ID_USUARIO_REGISTRO");
                int posSiglaU = drd.GetOrdinal("SIGLA");
                while (drd.Read())
                {
                    obeUsuario = new beUsuario();
                    obeUsuario.ID_LOGIN = drd.GetInt32(posIdLogin);
                    obeUsuario.NOMBRES = drd.GetString(posNombres);
                    obeUsuario.APELLIDOS = drd.GetString(posApellidos);
                    obeUsuario.LOGIN_NAME = drd.GetString(posLoginName);
                    obeUsuario.CORREO = drd.GetString(posCorreo);
                    obeUsuario.FECHA_CREACION = drd.GetDateTime(posFechaCreacion);
                    obeUsuario.FECHA_MODIFICACION = drd.GetDateTime(posFechaModificacion);
                    obeUsuario.NUMERO_INTENTOS = 0;//drd.GetInt32(posNumero_Intentos);
                    obeUsuario.ID_UNIDAD = drd.GetInt32(posIdUnidad);
                    obeUsuario.ID_ESTADO = 0;//drd.GetInt32(posIdEstado);
                    obeUsuario.DESCRIPCION_ESTADO_USUARIO = drd.GetString(posDescripcion);
                    obeUsuario.DESCRIPCION_TIPO_ESTADO = "Activo";// drd.GetString(posDescripcionTipo);
                    obeUsuario.NOMBRE_UNIDAD = drd.GetString(posNombreUnidad);
                    obeUsuario.ID_ESTADO_UNIDAD = drd.GetInt32(posIdEstadoUnidad);
                    obeUsuario.DESCRIPCION_ESTADO_UNIDAD = drd.GetString(posDescripcionEstado);
                    obeUsuario.NOMBRE_UNIDAD_PADRE = drd.GetString(posNombreUnidadPadre);
                    obeUsuario.ID_ESTADO_UNIDAD_PADRE = drd.GetInt32(posIdEstadoUnidadPadre);
                    obeUsuario.DESCRIPCION_ESTADO_UNIDAD_PADRE = drd.GetString(posDescripcionEstadoUnidad);
                    obeUsuario.ID_USUARIO_REGISTRO = drd.GetInt32(posIdUsuarioRegistro);
                    obeUsuario.SIGLA = drd.GetString(posSiglaU);
                    obeDatosUsuario.Usuario = obeUsuario;
                }
                if (drd.NextResult())
                {
                    obeDatosUsuario.ListaRol = new List<beRol>();
                    beRol obeRol;
                    int posIdRol = drd.GetOrdinal("ID_ROL");
                    int posRol = drd.GetOrdinal("ROL");
                    int posIdEstadoRol = drd.GetOrdinal("ID_ESTADO");
                    int posDescripcionRol = drd.GetOrdinal("DESCRIPCION");
                    while (drd.Read())
                    {
                        obeRol = new beRol();
                        obeRol.ID_ROL = drd.GetInt32(posIdRol);
                        obeRol.ROL = drd.GetString(posRol);
                        obeRol.ID_ESTADO = 1;//drd.GetInt32(posIdEstadoRol);
                        obeRol.DESCRIPCION = drd.GetString(posDescripcionRol);
                        obeDatosUsuario.ListaRol.Add(obeRol);
                    }
                }

                if (drd.NextResult())
                {
                    obeDatosUsuario.ListaMenu = new List<beMenu>();
                    beMenu obeMenu;
                    int posIdMenu = drd.GetOrdinal("ID_MENU");
                    int posVista = drd.GetOrdinal("VISTA");
                    int posControlador = drd.GetOrdinal("CONTROLADOR");
                    int posNombre = drd.GetOrdinal("NOMBRE");
                    int posIdPadre = drd.GetOrdinal("ID_PADRE");
                    int posIdAplicacion = drd.GetOrdinal("ID_APLICACION");
                    while (drd.Read())
                    {
                        obeMenu = new beMenu();
                        obeMenu.ID_MENU = drd.GetInt32(posIdMenu);
                        obeMenu.VISTA = drd.GetString(posVista);
                        obeMenu.CONTROLADOR = drd.GetString(posControlador);
                        obeMenu.NOMBRE = drd.GetString(posNombre);
                        obeMenu.ID_PADRE = drd.GetInt32(posIdPadre);
                        obeMenu.ID_APLICACION = drd.GetInt32(posIdAplicacion);
                        obeDatosUsuario.ListaMenu.Add(obeMenu);
                    }
                }

                if (drd.NextResult())
                {
                    obeDatosUsuario.ListaEstado = new List<beEstado>();
                    beEstado obeEstado;
                    int posIdEstadoE = drd.GetOrdinal("ID_ESTADO");
                    int posDescripcionE = drd.GetOrdinal("DESCRIPCION");
                    while (drd.Read())
                    {
                        obeEstado = new beEstado();
                        obeEstado.ID_ESTADO = 1;//drd.GetInt32(posIdEstadoE);
                        obeEstado.DESCRIPCION = drd.GetString(posDescripcionE);
                        obeDatosUsuario.ListaEstado.Add(obeEstado);
                    }
                }

                if (drd.NextResult())
                {
                    obeDatosUsuario.ListaTipoEstado = new List<beTipoEstado>();
                    beTipoEstado obeTipoEstado;
                    int posIdTipoEstado = drd.GetOrdinal("ID_TIPO_ESTADO");
                    int posDescripcionTE = drd.GetOrdinal("DESCRIPCION");
                    while (drd.Read())
                    {
                        obeTipoEstado = new beTipoEstado();
                        obeTipoEstado.ID_TIPO_ESTADO = 1;// drd.GetInt32(posIdTipoEstado);
                        obeTipoEstado.DESCRIPCION = drd.GetString(posDescripcionTE);
                        obeDatosUsuario.ListaTipoEstado.Add(obeTipoEstado);
                    }
                }

                if (drd.NextResult())
                {
                    obeDatosUsuario.ListaUnidad = new List<beUnidad>();
                    beUnidad obebeUnidad;
                    int posIdUnidadE = drd.GetOrdinal("ID_UNIDAD");
                    int posNombreU = drd.GetOrdinal("NOMBRE");
                    int posSigla = drd.GetOrdinal("SIGLA");
                    int posIdPadre = drd.GetOrdinal("ID_PADRE");
                    int posIdEstadoU = drd.GetOrdinal("ID_ESTADO");
                    while (drd.Read())
                    {
                        obebeUnidad = new beUnidad();
                        obebeUnidad.ID_UNIDAD = drd.GetInt32(posIdUnidadE);
                        obebeUnidad.NOMBRE = drd.GetString(posNombreU);
                        obebeUnidad.SIGLA = drd.GetString(posSigla);
                        obebeUnidad.ID_PADRE = drd.GetInt32(posIdPadre);
                        obebeUnidad.ID_ESTADO = drd.GetInt32(posIdEstadoU);
                        obeDatosUsuario.ListaUnidad.Add(obebeUnidad);
                    }
                }

               
                if (drd.NextResult())
                {
                    obeDatosUsuario.ListaTipoDocumento = new List<beTipoDocumento>();
                    beTipoDocumento obeTipoDocumento;
                    int posIdTipoDocumento = drd.GetOrdinal("ID_TIPO_DOCUMENTO");
                    int posDescripcionTipoDocumento = drd.GetOrdinal("DESCRIPCION");
                    while (drd.Read())
                    {
                        obeTipoDocumento = new beTipoDocumento();
                        obeTipoDocumento.ID_TIPO_DOCUMENTO = Convert.ToInt32 (drd.GetInt32(posIdTipoDocumento));
                        obeTipoDocumento.DESCRIPCION = drd.GetString(posDescripcionTipoDocumento);
                        obeDatosUsuario.ListaTipoDocumento.Add(obeTipoDocumento);
                    }
                }
                drd.Close();
            }
            return obeDatosUsuario;
        }

        public int AdicionarUsuario(SqlConnection con, beUsuario obeUsuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("DBA.APLICACIONES_SP_INSERTAR_USUARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRES", obeUsuario.NOMBRES);
            cmd.Parameters.AddWithValue("@APELLIDOS", obeUsuario.APELLIDOS);
            cmd.Parameters.AddWithValue("@LOGIN_NAME", obeUsuario.LOGIN_NAME);
            cmd.Parameters.AddWithValue("@PASSWORD", obeUsuario.PASSWORD);
            cmd.Parameters.AddWithValue("@CORREO", obeUsuario.CORREO);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", obeUsuario.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MODIFICACION", obeUsuario.FECHA_MODIFICACION);
            cmd.Parameters.AddWithValue("@NUMEROINTENTOS", obeUsuario.NUMERO_INTENTOS);
            cmd.Parameters.AddWithValue("@ID_ESTADO", obeUsuario.ID_ESTADO);
            cmd.Parameters.AddWithValue("@IDUNIDAD", obeUsuario.ID_UNIDAD);
            cmd.Parameters.AddWithValue("@ID_TIPO_ESTADO", obeUsuario.ID_TIPO_ESTADO);
            cmd.Parameters.AddWithValue("@ID_USUARIO_REGISTRO", obeUsuario.ID_USUARIO_REGISTRO);
            int nRegistros = Convert.ToInt32(cmd.ExecuteScalar());
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }        
    }
}