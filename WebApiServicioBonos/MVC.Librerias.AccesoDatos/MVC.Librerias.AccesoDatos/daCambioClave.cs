using System.Data.SqlClient;
using MVC.Librerias.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MVC.Librerias.AccesoDatos
{
    public class daCambioClave
    {
        public bool ActualizarClave(SqlConnection con, beCambioClave obeCambioClave)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("UPDATE APLICACIONES_LOGINS SET PASSWORD = @PASSWORD WHERE LOGIN_NAME = @LOGIN_NAME", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LOGIN_NAME", obeCambioClave.LOGIN_NAME);
            cmd.Parameters.AddWithValue("@PASSWORD", obeCambioClave.ConfirmarPassword);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
