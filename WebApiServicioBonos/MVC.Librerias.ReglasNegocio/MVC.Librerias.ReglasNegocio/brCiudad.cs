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
    
    public class brCiudad : brGeneral
    {
        
        public beDatosGeograficos ListarCiudad()
        {
            beDatosGeograficos lstObeCiudad = new beDatosGeograficos();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaDepartamento = new daCiudad();
                    lstObeCiudad = odaDepartamento.ListaCiudad(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeCiudad;
        }

       
        public int AdicionarCiudad(beCiudad obeCiudad, string usuario)
        {
            int idCiudad = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaDepartamento = new daCiudad();
                    idCiudad = odaDepartamento.AdicionarCiudad(con, obeCiudad, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idCiudad;
        }

       
        public bool ActualizarCiudad(beCiudad obeCiudad, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaCiudad = new daCiudad();
                    exito = odaCiudad.ActualizarCiudad(con, obeCiudad,usuario);
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
            int idCiudad = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaCiudad = new daCiudad();
                    idCiudad = odaCiudad.CargueMasivo(con, Cadena);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idCiudad;
        }

        public bool ActualizarEstado(int IdCiudad, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCiudad odaCiudad = new daCiudad();
                    exito = odaCiudad.ActualizarEstado(con, IdCiudad, Estado, usuario);
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
