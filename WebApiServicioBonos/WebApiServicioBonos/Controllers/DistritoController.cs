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
    /// <summary>
    /// Autor: Sebastian Mateus Villegas
    /// Nombre de la clase: PaisController 
    /// Función: Establece comunicacion con el javascript "jsPais.js" para el paso de datos a la vista 
    /// Fecha Documentación: 5 de abril de 2019
    /// </summary>
    public class DistritoController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarDistrito()
        {
            string sb = "";
            brDistrito obrDistrito = new brDistrito();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Distrito", Titulo = "Id Distrito", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Distrito", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beDistrito> lstObeDistrito = obrDistrito.ListarDistrito();
            if (lstObeDistrito != null)
            {
                if (lstObeDistrito.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeDistrito, '|', ';', true, campos));
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

       
        public string GuardarDistrito()
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

            //    beDistrito obeDistrito = new beDistrito();
            //    string[] camposDistrito = rpta.Split('|');

            //    obeDistrito.ID_Distrito = int.Parse(camposDistrito[0]);
            //    obeDistrito.NOMBRE_Distrito = camposDistrito[1].ToString();

            //    brDistrito obrDistrito = new brDistrito();
            //    if (obeDistrito.ID_Distrito == 0)
            //    {
            //        int idDistrito = obrDistrito.AdicionarDistrito(obeDistrito,obeDatosUsuario.Usuario);
            //        if (idDistrito > 0) retorno = "Se Adiciono el Distrito";
            //        else retorno = "No se pudo adicionar el Distrito";
            //    }
            //    else
            //    {
            //        bool exito = obrDistrito.ActualizarDistrito(obeDistrito,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Distrito";
            //        else retorno = "No se pudo actualizar el Distrito";
            //    }

            //    sb += ListarDistrito() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdDistrito)
        {
            string sb = "";
            string mensaje = "";
            //brDistrito obrDistrito = new brDistrito();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrDistrito.ActualizarEstado(Convert.ToInt32(IdDistrito), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarDistrito() + "¬" + mensaje;
            return sb;
        }
    }
}