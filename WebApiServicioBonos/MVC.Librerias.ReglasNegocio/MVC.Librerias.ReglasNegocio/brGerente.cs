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
    public class brGerente : brGeneral
    {
        
        public beDatosGerente ListarGerente()
        {
            beDatosGerente obeDatosGerente = new beDatosGerente();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGerente odaGerente = new daGerente();
                    obeDatosGerente = odaGerente.ListaGerente(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return obeDatosGerente;
        }

       
        public int AdicionarGeneral(beGerente obeGerente)
        {
            int idGerente = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGerente odaGerente = new daGerente();
                    idGerente = odaGerente.AdicionarGerente(con, obeGerente);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idGerente;
        }

        
        public bool ActualizarGerente(beGerente obeGerente)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daGerente odaGerente = new daGerente();
                    exito = odaGerente.ActualizarGerente(con, obeGerente);
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
