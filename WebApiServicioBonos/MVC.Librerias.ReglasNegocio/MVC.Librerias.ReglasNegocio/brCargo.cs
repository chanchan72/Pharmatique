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
    public class brCargo : brGeneral
    {
        
        public List<beCargo> ListarCargo()
        {
            List<beCargo> lstObeCargo = new List<beCargo>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCargo odaCargo = new daCargo();
                    lstObeCargo = odaCargo.ListarCargo(con);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return lstObeCargo;
        }

        
        public int AdicionarCargo(beCargo obeCargo, string usuario)
        {
            int idCargo = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCargo odaCargo = new daCargo();
                    idCargo = odaCargo.AdicionarCargo(con, obeCargo, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
            }
            return idCargo;
        }

        
        public bool ActualizarCargo(beCargo obeCargo, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCargo odaCargo = new daCargo();
                    exito = odaCargo.ActualizarCargo(con, obeCargo, usuario);
                }
                catch (Exception ex)
                {
                    //GrabarLog(ex.Message, ex.StackTrace);
                }
                return exito;
            }
        }


        public bool ActualizarEstado(int IdCargo, string Estado, string usuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCargo odaCargo = new daCargo();
                    exito = odaCargo.ActualizarEstado(con, IdCargo, Estado, usuario);
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
