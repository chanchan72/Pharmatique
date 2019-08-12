using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Librerias.EntidadesNegocio;
using Genaral.Librerias.CodigoUsuario;
using MVC.Libreria.AccesoDatos;
using MVC.Libreria.EntidadesNegocio;
using MVC.Libreria.ReglasNegocio;
using System.Data.SqlClient;
using MVC.Librerias.ReglasNegocio;

namespace MVC.Libreria.ReglasNegocio
{
    public class brTipoClasificacion : brGeneral
    {
        
        public List<beTipoClasificacion> ListarTipoClasificacion()
        {
            List<beTipoClasificacion> lstObeTipoClasificacion = new List<beTipoClasificacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoClasificacion odaTipoClasificacion = new daTipoClasificacion();
                    lstObeTipoClasificacion = odaTipoClasificacion.ListarTipoClasificacion(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeTipoClasificacion;
        }

        
        public int AdicionarTipoClasificacion(beTipoClasificacion obeTipoClasificacion, string usuario)
        {
            int idTipoClasificacion = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoClasificacion odaTipoClasificacion = new daTipoClasificacion();
                    idTipoClasificacion = odaTipoClasificacion.AdicionarTipoClasificacion(con, obeTipoClasificacion, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idTipoClasificacion;
        }

        
        public bool ActualizarTipoClasificacion(beTipoClasificacion obeTipoClasificacion,string usuario )
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoClasificacion odaTipoClasificacion = new daTipoClasificacion();
                    exito = odaTipoClasificacion.ActualizarTipoClasificacion(con, obeTipoClasificacion, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdTipoClasificacion, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoClasificacion odaTipoClasificacion = new daTipoClasificacion();
                    exito = odaTipoClasificacion.ActualizarEstado(con, IdTipoClasificacion, Estado, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }
    }
}
