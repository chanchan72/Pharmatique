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
    public class RegionalesController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarRegional()
        {
            string sb = "";
            brRegionales obrRegionales = new brRegionales();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_REGIONAL", Titulo = "Id Regional", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "CODIGO_REGIONAL", Titulo = "Codigo", Ancho = 35 });
            campos.Add(new beDataColumn { Campo = "REGIONAL", Titulo = "Nombre", Ancho = 35 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beRegionales> lstOberegional = obrRegionales.ListarRegional();
            if (lstOberegional != null)
            {
                if (lstOberegional.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstOberegional, '|', ';', true, campos));
                }
            }
            return sb;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: GuardarPais
        /// Función: Recibe los datos de la vista, los guarda en un objeto de tipo "bePais" y si el id del pais viene 
        ///          vacio envia a insertar el dato, sino lo envia a actualizar. 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>

       
        public string GuardarRegionales()
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

            //    beRegionales obeRegional = new beRegionales();
            //    string[] camposRegional = rpta.Split('|');

            //    obeRegional.ID_REGIONAL = int.Parse(camposRegional[0]);
            //    obeRegional.CODIGO_REGIONAL = camposRegional[1].ToString();
            //    obeRegional.REGIONAL = camposRegional[2].ToString();


            //    brRegionales obrRegionales = new brRegionales();
            //    if (obeRegional.ID_REGIONAL == 0)
            //    {
            //        int idRegional = obrRegionales.AdicionarRegional(obeRegional, obeDatosUsuario.Usuario);
            //        if (idRegional > 0) retorno = "Se Adiciono la Regional";
            //        else retorno = "No se pudo adicionar la Regional";
            //    }
            //    else
            //    {
            //        bool exito = obrRegionales.ActualizarRegional(obeRegional,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo la Regional";
            //        else retorno = "No se pudo actualizar la Regional";
            //    }

            //    sb += ListarRegional() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdRegional)
        {
            string sb = "";
            string mensaje = "";
            //brRegionales obrRegionales = new brRegionales();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrRegionales.ActualizarEstado(Convert.ToInt32(IdRegional), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarRegional() + "¬" + mensaje;
            return sb;
        }
    }
}