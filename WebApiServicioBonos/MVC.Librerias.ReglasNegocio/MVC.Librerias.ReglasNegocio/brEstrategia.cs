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
    public class brEstrategia : brGeneral
    {
       
        public List<beEstrategia> ListarEstrategia()
        {
            List<beEstrategia> lstObeEstrategia = new List<beEstrategia>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEstrategia odaEstrategia = new daEstrategia();
                    lstObeEstrategia = odaEstrategia.ListarEstrategia(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeEstrategia;
        }

        
        public int AdicionarEstrategia(beEstrategia obeEstrategia, string usuario)
        {
            int idEstrategia = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEstrategia odaEstrategia = new daEstrategia();
                    idEstrategia = odaEstrategia.AdicionarEstrategia(con, obeEstrategia, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idEstrategia;
        }

        
        public bool ActualizarEstrategia(beEstrategia obeEstrategia, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEstrategia odaEstrategia = new daEstrategia();
                    exito = odaEstrategia.ActualizarEstrategia(con, obeEstrategia,usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public bool ActualizarEstado(int IdEstrategia, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEstrategia odaEstrategia = new daEstrategia();
                    exito = odaEstrategia.ActualizarEstado(con, IdEstrategia, Estado, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }

        public int CargueMasivo(string Cadena)
        {
            int idEstrategia = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEstrategia odaEstrategia = new daEstrategia();
                    idEstrategia = odaEstrategia.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idEstrategia;
        }
    }
}
