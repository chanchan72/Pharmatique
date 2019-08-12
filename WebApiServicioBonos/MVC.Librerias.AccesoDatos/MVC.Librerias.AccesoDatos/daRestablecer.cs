using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MVC.Librerias.EntidadesNegocio;

namespace MVC.Librerias.AccesoDatos
{
    public class daRestablecer
    {
        public bool RestablecerContrasenia()//SqlConnection con, beRestablecer obeRestablecer)
        {
            bool exito = false;
            //SqlCommand cmd = new SqlCommand("DBA.APLICACIONES_SP_RESTABLECER_CONTRASENIA", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@CORREO", obeRestablecer.correo);
            //cmd.Parameters.AddWithValue("@CONTRASENIA", obeRestablecer.contrasenia);
            //int nRegistros = cmd.ExecuteNonQuery();
            //exito = (nRegistros > 0);
            return exito;
        }
    }
}
