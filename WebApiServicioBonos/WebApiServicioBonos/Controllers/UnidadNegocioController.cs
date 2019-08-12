using System;
using io = System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using General.Librerias.EntidadesNegocio;
using Genaral.Librerias.CodigoUsuario;
using MVC.Libreria.EntidadesNegocio;
using MVC.Libreria.ReglasNegocio;
using System.Web.Http;

namespace Desarrollo_GDG_Migracion.Controllers
{
    public class UnidadNegocioController : ApiController
    {
        
        public string ListarUnidadNegocio()
        {
            string sb = "";
            brUnidadNegocio obrUnidadNegocio = new brUnidadNegocio();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_UnidadNegocio", Titulo = "Id UnidadNegocio", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_UnidadNegocio", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beUnidadNegocio> lstObeUnidadNegocio = obrUnidadNegocio.ListarUnidadNegocio();
            if (lstObeUnidadNegocio != null)
            {
                if (lstObeUnidadNegocio.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeUnidadNegocio, '|', ';', true, campos));
                }
            }
            return sb;
        }

       

        public string GuardarUnidadNegocio()
        {
            string rpta = "";
            string retorno = "";
            string sb = "";
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //int n = (int)Request.InputStream.Length;
            if (1 > 0)
            {
                //io.Stream flujo = Request.InputStream;
                //io.StreamReader lector = new io.StreamReader(flujo);
                //rpta = lector.ReadToEnd();

                beUnidadNegocio obeUnidadNegocio = new beUnidadNegocio();
                string[] camposUnidadNegocio = rpta.Split('|');

                obeUnidadNegocio.ID_UnidadNegocio = int.Parse(camposUnidadNegocio[0]);
                obeUnidadNegocio.NOMBRE_UnidadNegocio = camposUnidadNegocio[1].ToString();

                brUnidadNegocio obrUnidadNegocio = new brUnidadNegocio();
                if (obeUnidadNegocio.ID_UnidadNegocio == 0)
                {
                    //int idUnidadNegocio = obrUnidadNegocio.AdicionarUnidadNegocio(obeUnidadNegocio, obeDatosUsuario.Usuario);
                    //if (idUnidadNegocio > 0) retorno = "Se Adiciono el UnidadNegocio";
                    //else retorno = "No se pudo adicionar el UnidadNegocio";
                }
                else
                {
                    //bool exito = obrUnidadNegocio.ActualizarUnidadNegocio(obeUnidadNegocio, obeDatosUsuario.Usuario);
                    //if (exito) retorno = "Se actualizo el UnidadNegocio";
                    //else retorno = "No se pudo actualizar el UnidadNegocio";
                }

                sb += ListarUnidadNegocio() + "¬" + retorno;

            }
            return sb;
        }

        public string CambioEstado(string Estado, string IdUnidadNegocio)
        {
            string sb = "";
            string mensaje = "";
            brUnidadNegocio obrUnidadNegocio = new brUnidadNegocio();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrUnidadNegocio.ActualizarEstado(Convert.ToInt32(IdUnidadNegocio), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarUnidadNegocio() + "¬" + mensaje;
            return sb;
        }
    }
}