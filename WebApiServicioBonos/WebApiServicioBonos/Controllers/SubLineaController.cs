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
    public class SubLineaController : ApiController
    {
        
        public string ListarSubLinea()
        {
            string sb = "";
            brSubLinea obrSubLinea = new brSubLinea();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_SubLinea", Titulo = "Id SubLinea", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_SubLinea", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beSubLinea> lstObeSubLinea = obrSubLinea.ListarSubLinea();
            if (lstObeSubLinea != null)
            {
                if (lstObeSubLinea.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeSubLinea, '|', ';', true, campos));
                }
            }
            return sb;
        }


        
        public string GuardarSubLinea()
        {
            string rpta = "";
            string retorno = "";
            string sb = "";
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //int n = (int)Request.InputStream.Length;
            //if (n > 0)
            //{
            //    io.Stream flujo = Request.InputStream;
            //    io.StreamReader lector = new io.StreamReader(flujo);
            //    rpta = lector.ReadToEnd();

            //    beSubLinea obeSubLinea = new beSubLinea();
            //    string[] camposSubLinea = rpta.Split('|');

            //    obeSubLinea.ID_SubLinea = int.Parse(camposSubLinea[0]);
            //    obeSubLinea.NOMBRE_SubLinea = camposSubLinea[1].ToString();


            //    brSubLinea obrSubLinea = new brSubLinea();
            //    if (obeSubLinea.ID_SubLinea == 0)
            //    {
            //        int idSubLinea = obrSubLinea.AdicionarSubLinea(obeSubLinea, obeDatosUsuario.Usuario);
            //        if (idSubLinea > 0) retorno = "Se Adiciono el SubLinea";
            //        else retorno = "No se pudo adicionar el SubLinea";
            //    }
            //    else
            //    {
            //        bool exito = obrSubLinea.ActualizarSubLinea(obeSubLinea, obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el SubLinea";
            //        else retorno = "No se pudo actualizar el SubLinea";
            //    }

            //    sb += ListarSubLinea() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdSubLinea)
        {
            string sb = "";
            string mensaje = "";
            //brSubLinea obrSubLinea = new brSubLinea();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrSubLinea.ActualizarEstado(Convert.ToInt32(IdSubLinea), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarSubLinea() + "¬" + mensaje;
            return sb;
        }
    }
}