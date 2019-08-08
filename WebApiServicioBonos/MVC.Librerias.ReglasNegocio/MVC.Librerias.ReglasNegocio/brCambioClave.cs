using System;
using System.Collections.Generic;
using System.Data;
using MVC.Librerias.AccesoDatos;
using MVC.Librerias.EntidadesNegocio;
using System.Data.SqlClient;



namespace MVC.Librerias.ReglasNegocio
{
        public class brCambioClave : brGeneral
        {

            public bool ActualizarClave(beCambioClave obeCambioClave)
            {
                bool exito = false;
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    try
                    {
                        con.Open();
                        daCambioClave odaCambioClave = new daCambioClave();
                        exito = odaCambioClave.ActualizarClave(con, obeCambioClave);
                    }
                    catch (Exception ex)
                    {
                        GrabarLog(ex.Message, ex.StackTrace);
                    }
                    return exito;
                }
            }
        }
    }
