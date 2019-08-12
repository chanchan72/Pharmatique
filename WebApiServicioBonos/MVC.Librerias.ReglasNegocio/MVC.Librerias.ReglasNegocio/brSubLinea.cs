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
    public class brSubLinea : brGeneral
    {
        
        public List<beSubLinea> ListarSubLinea()
        {
            List<beSubLinea> lstObeSubLinea = new List<beSubLinea>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSubLinea odaSubLinea = new daSubLinea();
                    lstObeSubLinea = odaSubLinea.ListarSubLinea(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeSubLinea;
        }

        
        public int AdicionarSubLinea(beSubLinea obeSubLinea, string usuario )
        {
            int idSubLinea = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSubLinea odaSubLinea = new daSubLinea();
                    idSubLinea = odaSubLinea.AdicionarSubLinea(con, obeSubLinea, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idSubLinea;
        }

        
        public bool ActualizarSubLinea(beSubLinea obeSubLinea, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSubLinea odaSubLinea = new daSubLinea();
                    exito = odaSubLinea.ActualizarSubLinea(con, obeSubLinea, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }
        public bool ActualizarEstado(int IdSubLinea, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSubLinea odaSubLinea = new daSubLinea();
                    exito = odaSubLinea.ActualizarEstado(con, IdSubLinea, Estado, usuario);
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
