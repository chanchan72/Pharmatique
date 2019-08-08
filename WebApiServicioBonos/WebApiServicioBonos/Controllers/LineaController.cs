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
    public class LineaController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarLinea()
        {
            string sb = "";
            brLinea obrLinea = new brLinea();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Linea", Titulo = "Id Linea", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Linea", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beLinea> lstObeLinea = obrLinea.ListarLinea();
            if (lstObeLinea != null)
            {
                if (lstObeLinea.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeLinea, '|', ';', true, campos));
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

      
        public string GuardarLinea()
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

            //    beLinea obeLinea = new beLinea();
            //    string[] camposLinea = rpta.Split('|');

            //    obeLinea.ID_Linea = int.Parse(camposLinea[0]);
            //    obeLinea.NOMBRE_Linea = camposLinea[1].ToString();

            //    brLinea obrLinea = new brLinea();
            //    if (obeLinea.ID_Linea == 0)
            //    {
            //        int idLinea = obrLinea.AdicionarLinea(obeLinea,obeDatosUsuario.Usuario);
            //        if (idLinea > 0) retorno = "Se Adiciono el Linea";
            //        else retorno = "No se pudo adicionar el Linea";
            //    }
            //    else
            //    {
            //        bool exito = obrLinea.ActualizarLinea(obeLinea,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Linea";
            //        else retorno = "No se pudo actualizar el Linea";
            //    }

            //    sb += ListarLinea() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdLinea)
        {
            string sb = "";
            string mensaje = "";
            //brLinea obrLinea = new brLinea();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrLinea.ActualizarEstado(Convert.ToInt32(IdLinea), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarLinea() + "¬" + mensaje;
            return sb;
        }
    }
}