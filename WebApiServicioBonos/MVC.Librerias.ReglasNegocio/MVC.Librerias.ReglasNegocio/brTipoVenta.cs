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
    public class brTipoVenta : brGeneral
    {
        
        public List<beTipoVenta> ListarTipoVenta()
        {
            List<beTipoVenta> lstObeTipoVenta = new List<beTipoVenta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoVenta odaTipoVenta = new daTipoVenta();
                    lstObeTipoVenta = odaTipoVenta.ListarTipoVenta(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeTipoVenta;
        }

        
        public int AdicionarTipoVenta(beTipoVenta obeTipoVenta, string usuario)
        {
            int idTipoVenta = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoVenta odaTipoVenta = new daTipoVenta();
                    idTipoVenta = odaTipoVenta.AdicionarTipoVenta(con, obeTipoVenta, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idTipoVenta;
        }

        
        public bool ActualizarTipoVenta(beTipoVenta obeTipoVenta, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoVenta odaTipoVenta = new daTipoVenta();
                    exito = odaTipoVenta.ActualizarTipoVenta(con, obeTipoVenta, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdTipoVenta, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daTipoVenta odaTipoVenta = new daTipoVenta();
                    exito = odaTipoVenta.ActualizarEstado(con, IdTipoVenta, Estado, usuario);
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
