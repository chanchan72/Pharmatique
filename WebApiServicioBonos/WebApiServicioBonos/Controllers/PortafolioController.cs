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
    public class PortafolioController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarPortafolio()
        {
            string sb = "";
            brPortafolio obrPortafolio = new brPortafolio();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Portafolio", Titulo = "Id Portafolio", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Portafolio", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<bePortafolio> lstObePortafolio = obrPortafolio.ListarPortafolio();
            if (lstObePortafolio != null)
            {
                if (lstObePortafolio.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObePortafolio, '|', ';', true, campos));
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

        
        public string GuardarPortafolio()
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

            //    bePortafolio obePortafolio = new bePortafolio();
            //    string[] camposPortafolio = rpta.Split('|');

            //    obePortafolio.ID_Portafolio = int.Parse(camposPortafolio[0]);
            //    obePortafolio.NOMBRE_Portafolio = camposPortafolio[1].ToString();

            //    brPortafolio obrPortafolio = new brPortafolio();
            //    if (obePortafolio.ID_Portafolio == 0)
            //    {
            //        int idPortafolio = obrPortafolio.AdicionarPortafolio(obePortafolio, obeDatosUsuario.Usuario);
            //        if (idPortafolio > 0) retorno = "Se Adiciono el Portafolio";
            //        else retorno = "No se pudo adicionar el Portafolio";
            //    }
            //    else
            //    {
            //        bool exito = obrPortafolio.ActualizarPortafolio(obePortafolio,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Portafolio";
            //        else retorno = "No se pudo actualizar el Portafolio";
            //    }

            //    sb += ListarPortafolio() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdPortafolio)
        {
            string sb = "";
            string mensaje = "";
            //brPortafolio obrPortafolio = new brPortafolio();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrPortafolio.ActualizarEstado(Convert.ToInt32(IdPortafolio), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarPortafolio() + "¬" + mensaje;
            return sb;
        }
    }
}