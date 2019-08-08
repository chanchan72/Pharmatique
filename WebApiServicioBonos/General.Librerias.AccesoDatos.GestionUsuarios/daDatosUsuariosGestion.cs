
using General.Librerias.Entidades.GestionUsuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace General.Librerias.AccesoDatos.GestionUsuarios
{
    public class daDatosUsuariosGestion
    {
        public beDatosUsuariosGestion ListaUsuarios(SqlConnection con, string APLICACION)
        {
            beDatosUsuariosGestion obeDatosUsuarios = new beDatosUsuariosGestion();
            SqlCommand cmd = new SqlCommand("APLICACIONES_SP_LISTAR_USUARIOS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@APLICACION", APLICACION);
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                obeDatosUsuarios.ListaUsuarios = new List<beUsuarioGestion>();
                beUsuarioGestion obeUsuario;
                int posIdLogin = drd.GetOrdinal("ID_LOGIN");
                int posNombres = drd.GetOrdinal("NOMBRES");
                int posApellidos = drd.GetOrdinal("APELLIDOS");
                int posLoginName = drd.GetOrdinal("LOGIN_NAME");
                int posCorreo = drd.GetOrdinal("CORREO");
                int posFechaCreacion = drd.GetOrdinal("FECHA_CREACION");
                int posFechaModificacion = drd.GetOrdinal("FECHA_MODIFICACION");
                int posNumeroIntentos = drd.GetOrdinal("NUMERO_INTENTOS");
                int posIdUnidad = drd.GetOrdinal("ID_UNIDAD");
                int posIdEstado = drd.GetOrdinal("ID_ESTADO");
                int posDescripcionEstadoUsuario = drd.GetOrdinal("DESCRIPCION_ESTADO_USUARIO");
                int posIdTipoEstado = drd.GetOrdinal("ID_TIPO_ESTADO");
                int posDescripcionTipoEstado = drd.GetOrdinal("DESCRIPCION_TIPO_ESTADO");
                int posNombreUnidad = drd.GetOrdinal("NOMBRE_UNIDAD");
                int posSigla = drd.GetOrdinal("SIGLA");
                int posIdEstadoUnidad = drd.GetOrdinal("ID_ESTADO_UNIDAD");
                int posDescripcionEstadoUnidad = drd.GetOrdinal("DESCRIPCION_ESTADO_UNIDAD");
                int posIdPadre = drd.GetOrdinal("ID_PADRE");
                int posNombreUnidadPadre = drd.GetOrdinal("NOMBRE_UNIDAD_PADRE");
                int posIdEstadoUnidadPadre = drd.GetOrdinal("ID_ESTADO_UNIDAD_PADRE");
                int posDescripcionEstadoUnidadPadre = drd.GetOrdinal("DESCRIPCION_ESTADO_UNIDAD_PADRE");
                int posIdUsuarioRegistro = drd.GetOrdinal("ID_USUARIO_REGISTRO");
                int posIdSucursal = drd.GetOrdinal("ID_SUCURSAL");
                int posNombreSucursal = drd.GetOrdinal("NOMBRE_SUCURSAL");
                int posIdCentro = drd.GetOrdinal("ID_CENTRO_FORMACION");
                int posNombreCentro = drd.GetOrdinal("NOMBRE_CENTRO");
                //int posObservaciones = drd.GetOrdinal("OBSERVACIONES");
                while (drd.Read())
                {
                    obeUsuario = new beUsuarioGestion();
                    obeUsuario.ID_LOGIN = drd.GetInt32(posIdLogin);
                    obeUsuario.NOMBRES = drd.GetString(posNombres);
                    obeUsuario.APELLIDOS = drd.GetString(posApellidos);
                    obeUsuario.LOGIN_NAME = drd.GetString(posLoginName);
                    obeUsuario.CORREO = drd.GetString(posCorreo);
                    obeUsuario.FECHA_CREACION = drd.GetDateTime(posFechaCreacion);
                    obeUsuario.FECHA_MODIFICACION = drd.GetDateTime(posFechaModificacion);
                    obeUsuario.NUMERO_INTENTOS = Convert.ToInt32(drd.GetInt32(posNumeroIntentos));
                    obeUsuario.ID_UNIDAD = drd.GetInt32(posIdUnidad);
                    obeUsuario.ID_ESTADO = drd.GetInt32(posIdEstado);
                    obeUsuario.DESCRIPCION_ESTADO_USUARIO = drd.GetString(posDescripcionEstadoUsuario);
                    obeUsuario.ID_TIPO_ESTADO = drd.GetInt32(posIdTipoEstado);
                    obeUsuario.DESCRIPCION_TIPO_ESTADO = drd.GetString(posDescripcionTipoEstado);
                    obeUsuario.NOMBRE_UNIDAD = drd.GetString(posNombreUnidad);
                    obeUsuario.SIGLA = drd.GetString(posSigla);
                    obeUsuario.ID_ESTADO_UNIDAD = drd.GetInt32(posIdEstadoUnidad);
                    obeUsuario.DESCRIPCION_ESTADO_UNIDAD = drd.GetString(posDescripcionEstadoUnidad);
                    obeUsuario.ID_PADRE = drd.GetInt32(posIdPadre);
                    obeUsuario.NOMBRE_UNIDAD_PADRE = drd.GetString(posNombreUnidadPadre);
                    obeUsuario.ID_ESTADO_UNIDAD_PADRE = drd.GetInt32(posIdEstadoUnidadPadre);
                    obeUsuario.DESCRIPCION_ESTADO_UNIDAD_PADRE = drd.GetString(posDescripcionEstadoUnidadPadre);
                    obeUsuario.ID_USUARIO_REGISTRO = drd.GetInt32(posIdUsuarioRegistro);
                    if (!drd.IsDBNull(posIdSucursal)) obeUsuario.ID_SUCURSAL = drd.GetInt32(posIdSucursal);
                    if (!drd.IsDBNull(posNombreSucursal)) obeUsuario.NOMBRE_SUCURSAL = drd.GetString(posNombreSucursal);
                    if (!drd.IsDBNull(posIdCentro)) obeUsuario.ID_CENTRO_FORMACION = drd.GetInt32(posIdCentro);
                    if (!drd.IsDBNull(posNombreCentro)) obeUsuario.NOMBRE_CENTRO = drd.GetString(posNombreCentro);
                    //obeUsuario.OBSERVACIONES = drd.GetString(posObservaciones);
                    obeDatosUsuarios.ListaUsuarios.Add(obeUsuario);
                }
                if (drd.NextResult())
                {
                    obeDatosUsuarios.ListaRoles = new List<beRolGestion>();
                    beRolGestion obeRol;
                    int posIdRol = drd.GetOrdinal("ID_ROL");
                    int posRol = drd.GetOrdinal("ROL");
                    int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                    int posIdEstadoR = drd.GetOrdinal("ID_ESTADO");
                    while (drd.Read())
                    {
                        obeRol = new beRolGestion();
                        obeRol.ID_ROL = drd.GetInt32(posIdRol);
                        obeRol.ROL = drd.GetString(posRol);
                        obeRol.DESCRIPCION = drd.GetString(posDescripcion);
                        obeRol.ID_ESTADO = drd.GetInt32(posIdEstadoR);
                        obeDatosUsuarios.ListaRoles.Add(obeRol);
                    }
                }
                if (drd.NextResult())
                {
                    obeDatosUsuarios.ListaUsuariosRoles = new List<beUsuariosRolesGestion>();
                    beUsuariosRolesGestion obeUsuariosRoles;
                    int posIdRol = drd.GetOrdinal("ID_ROL");
                    int posRol = drd.GetOrdinal("ROL");
                    int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                    int posIdEstadoR = drd.GetOrdinal("ID_ESTADO");
                    int posIdLoginRol = drd.GetOrdinal("ID_LOGIN_ROL");
                    int posIdLoginUR= drd.GetOrdinal("ID_LOGIN");
                    while (drd.Read())
                    {
                        obeUsuariosRoles = new beUsuariosRolesGestion();
                        obeUsuariosRoles.ID_ROL = drd.GetInt32(posIdRol);
                        obeUsuariosRoles.ROL = drd.GetString(posRol);
                        obeUsuariosRoles.DESCRIPCION = drd.GetString(posDescripcion);
                        obeUsuariosRoles.ID_ESTADO = drd.GetInt32(posIdEstadoR);
                        obeUsuariosRoles.ID_LOGIN_ROL = drd.GetInt32(posIdLoginRol);
                        obeUsuariosRoles.ID_LOGIN = drd.GetInt32(posIdLoginUR);
                        obeDatosUsuarios.ListaUsuariosRoles.Add(obeUsuariosRoles);
                    }
                }
                drd.Close();
            }
            return obeDatosUsuarios;
        }

        public beDatosUsuarioAplicacionesGestion ValidarUsuario(SqlConnection con, string LOGIN_NAME)
        {
            beDatosUsuarioAplicacionesGestion obeDatosUsuarioAplicacionesGestion = new beDatosUsuarioAplicacionesGestion();
            SqlCommand cmd = new SqlCommand("APLICACIONES_SP_VALIDAR_USUARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LOGIN_NAME", LOGIN_NAME);

            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                obeDatosUsuarioAplicacionesGestion.Usuario = new beUsuarioGestion();
                beUsuarioGestion obeUsuarioGestion;
                int posIdLogin = drd.GetOrdinal("ID_LOGIN");
                int posNombres = drd.GetOrdinal("NOMBRES");
                int posApellidos = drd.GetOrdinal("APELLIDOS");
                int posLoginName = drd.GetOrdinal("LOGIN_NAME");
                int posCorreo = drd.GetOrdinal("CORREO");
                int posFechaCreacion = drd.GetOrdinal("FECHA_CREACION");
                int posFechaModificacion = drd.GetOrdinal("FECHA_MODIFICACION");
                int posNumeroIntentos = drd.GetOrdinal("NUMERO_INTENTOS");
                int posIdUnidad = drd.GetOrdinal("ID_UNIDAD");
                int posIdEstado = drd.GetOrdinal("ID_ESTADO");
                int posDescripcionEstadoUsuario = drd.GetOrdinal("DESCRIPCION_ESTADO_USUARIO");
                int posIdTipoEstado = drd.GetOrdinal("ID_TIPO_ESTADO");
                int posDescripcionTipoEstado = drd.GetOrdinal("DESCRIPCION_TIPO_ESTADO");
                int posNombreUnidad = drd.GetOrdinal("NOMBRE_UNIDAD");
                int posSigla = drd.GetOrdinal("SIGLA");
                int posIdEstadoUnidad = drd.GetOrdinal("ID_ESTADO_UNIDAD");
                int posDescripcionEstadoUnidad = drd.GetOrdinal("DESCRIPCION_ESTADO_UNIDAD");
                int posIdPadre = drd.GetOrdinal("ID_PADRE");
                int posNombreUnidadPadre = drd.GetOrdinal("NOMBRE_UNIDAD_PADRE");
                int posIdEstadoUnidadPadre = drd.GetOrdinal("ID_ESTADO_UNIDAD_PADRE");
                int posDescripcionEstadoUnidadPadre = drd.GetOrdinal("DESCRIPCION_ESTADO_UNIDAD_PADRE");
                int posIdUsuarioRegistro = drd.GetOrdinal("ID_USUARIO_REGISTRO");
                //int posObservaciones = drd.GetOrdinal("OBSERVACIONES");

                while (drd.Read())
                {
                    obeUsuarioGestion = new beUsuarioGestion();
                    obeUsuarioGestion.ID_LOGIN = drd.GetInt32(posIdLogin);
                    obeUsuarioGestion.NOMBRES = drd.GetString(posNombres);
                    obeUsuarioGestion.APELLIDOS = drd.GetString(posApellidos);
                    obeUsuarioGestion.LOGIN_NAME = drd.GetString(posLoginName);
                    obeUsuarioGestion.CORREO = drd.GetString(posCorreo);
                    obeUsuarioGestion.FECHA_CREACION = drd.GetDateTime(posFechaCreacion);
                    obeUsuarioGestion.FECHA_MODIFICACION = drd.GetDateTime(posFechaModificacion);
                    obeUsuarioGestion.NUMERO_INTENTOS = drd.GetInt32(posNumeroIntentos);
                    obeUsuarioGestion.ID_UNIDAD = drd.GetInt32(posIdUnidad);
                    obeUsuarioGestion.ID_ESTADO = drd.GetInt32(posIdEstado);
                    obeUsuarioGestion.DESCRIPCION_ESTADO_USUARIO = drd.GetString(posDescripcionEstadoUsuario);
                    obeUsuarioGestion.ID_TIPO_ESTADO = drd.GetInt32(posIdTipoEstado);
                    obeUsuarioGestion.DESCRIPCION_TIPO_ESTADO = drd.GetString(posDescripcionTipoEstado);
                    obeUsuarioGestion.NOMBRE_UNIDAD = drd.GetString(posNombreUnidad);
                    obeUsuarioGestion.SIGLA = drd.GetString(posSigla);
                    obeUsuarioGestion.ID_ESTADO_UNIDAD = drd.GetInt32(posIdEstadoUnidad);
                    obeUsuarioGestion.DESCRIPCION_ESTADO_UNIDAD = drd.GetString(posDescripcionEstadoUnidad);
                    obeUsuarioGestion.ID_PADRE = drd.GetInt32(posIdPadre);
                    obeUsuarioGestion.NOMBRE_UNIDAD_PADRE = drd.GetString(posNombreUnidadPadre);
                    obeUsuarioGestion.ID_ESTADO_UNIDAD_PADRE = drd.GetInt32(posIdEstadoUnidadPadre);
                    obeUsuarioGestion.DESCRIPCION_ESTADO_UNIDAD_PADRE = drd.GetString(posDescripcionEstadoUnidadPadre);
                    obeUsuarioGestion.ID_USUARIO_REGISTRO = drd.GetInt32(posIdUsuarioRegistro);
                    //obeUsuarioGestion.OBSERVACIONES = drd.GetString(posObservaciones);
                    obeDatosUsuarioAplicacionesGestion.Usuario = obeUsuarioGestion;
                }
                if (drd.NextResult())
                {
                    obeDatosUsuarioAplicacionesGestion.ListaAplicacionesUsuario = new List<beAplicacionesUsuarioGestion>();
                    beAplicacionesUsuarioGestion obeAplicacionesUsuarioGestion;
                    int posIdApliciacion = drd.GetOrdinal("ID_APLICACION");
                    int posNombre = drd.GetOrdinal("NOMBRE");
                    int posIdLoginA = drd.GetOrdinal("ID_LOGIN");
                    while (drd.Read())
                    {
                        obeAplicacionesUsuarioGestion = new beAplicacionesUsuarioGestion();
                        obeAplicacionesUsuarioGestion.ID_APLICACION = drd.GetInt32(posIdApliciacion);
                        obeAplicacionesUsuarioGestion.NOMBRE = drd.GetString(posNombre);
                        obeAplicacionesUsuarioGestion.ID_LOGIN = drd.GetInt32(posIdLoginA);
                        obeDatosUsuarioAplicacionesGestion.ListaAplicacionesUsuario.Add(obeAplicacionesUsuarioGestion);
                    }
                }
                drd.Close();
            }
            return obeDatosUsuarioAplicacionesGestion;
        }

        public int AdicionarUsuario(SqlConnection con, beUsuarioGestion obeUsuario, string cadenaTbRol)
        {
            int idUsuario = -1;
            SqlCommand cmd = new SqlCommand("APLICACIONES_SP_INSERTAR_USUARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRES", obeUsuario.NOMBRES);
            cmd.Parameters.AddWithValue("@APELLIDOS", obeUsuario.APELLIDOS);
            cmd.Parameters.AddWithValue("@LOGIN_NAME", obeUsuario.LOGIN_NAME);
            cmd.Parameters.AddWithValue("@PASWORD", obeUsuario.PASSWORD);
            cmd.Parameters.AddWithValue("@CORREO", obeUsuario.CORREO);
            cmd.Parameters.AddWithValue("@FECHA_CREACION", obeUsuario.FECHA_CREACION);
            cmd.Parameters.AddWithValue("@FECHA_MODIFICACION", obeUsuario.FECHA_MODIFICACION);
            cmd.Parameters.AddWithValue("@NUMEROINTENTOS", obeUsuario.NUMERO_INTENTOS);
            cmd.Parameters.AddWithValue("@ID_ESTADO", obeUsuario.ID_ESTADO);
            cmd.Parameters.AddWithValue("@IDUNIDAD", obeUsuario.ID_UNIDAD);
            cmd.Parameters.AddWithValue("@ID_SUCURSAL", obeUsuario.ID_SUCURSAL);
            cmd.Parameters.AddWithValue("@ID_TIPO_ESTADO", obeUsuario.ID_TIPO_ESTADO);
            cmd.Parameters.AddWithValue("@ID_USUARIO_REGISTRO", obeUsuario.ID_USUARIO_REGISTRO);
            cmd.Parameters.AddWithValue("@CADENA_TB_ROL", cadenaTbRol);
            
            int nRegistros = Convert.ToInt32(cmd.ExecuteScalar());
            if (nRegistros > 0)
            {
                idUsuario = nRegistros;
            }
            return idUsuario;
        }

        public bool ActualizarUsuario(SqlConnection con, beUsuarioGestion obeUsuario, string cadenaTbRol)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("UPDATE APLICACIONES_LOGINS SET NOMBRES =@NOMBRES ,APELLIDOS =@APELLIDOS ,CORREO = @CORREO ,ID_ESTADO =@ID_ESTADO ,ID_UNIDAD = @IDUNIDAD" +
                       ",ID_TIPO_ESTADO = @ID_TIPO_ESTADO  WHERE ID_LOGIN = @ID_LOGIN \n" +
                       "UPDATE APLICACIONES_LOGIN_ROL SET ID_ROL =@CADENA_TB_ROL  WHERE ID_LOGIN =@ID_LOGIN", con);

            cmd.Parameters.AddWithValue("@ID_LOGIN", obeUsuario.ID_LOGIN);
            cmd.Parameters.AddWithValue("@NOMBRES", obeUsuario.NOMBRES);
            cmd.Parameters.AddWithValue("@APELLIDOS", obeUsuario.APELLIDOS);
            cmd.Parameters.AddWithValue("@CORREO", obeUsuario.CORREO);
            cmd.Parameters.AddWithValue("@ID_ESTADO", obeUsuario.ID_ESTADO);
            cmd.Parameters.AddWithValue("@IDUNIDAD", obeUsuario.ID_UNIDAD);
            cmd.Parameters.AddWithValue("@ID_TIPO_ESTADO", obeUsuario.ID_TIPO_ESTADO);
            cmd.Parameters.AddWithValue("@CADENA_TB_ROL", cadenaTbRol);
            //cmd.Parameters.AddWithValue("@OBSERVACIONES", obeUsuario.OBSERVACIONES);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }  
    }
}
