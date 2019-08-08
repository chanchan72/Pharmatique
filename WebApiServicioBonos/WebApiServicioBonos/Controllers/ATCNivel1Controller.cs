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
    public class ATCNivel1Controller : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarATCNivel1()
        {
            string sb = "";
            brATCNivel1 obrATCNivel1 = new brATCNivel1();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_ATCNivel1", Titulo = "Id ATCNivel1", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_ATCNivel1", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beATCNivel1> lstObeATCNivel1 = obrATCNivel1.ListarATCNivel1();
            if (lstObeATCNivel1 != null)
            {
                if (lstObeATCNivel1.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeATCNivel1, '|', ';', true, campos));
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

        public string GuardarATCNivel1()
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

            //    beATCNivel1 obeATCNivel1 = new beATCNivel1();
            //    string[] camposATCNivel1 = rpta.Split('|');

            //    obeATCNivel1.ID_ATCNivel1 = int.Parse(camposATCNivel1[0]);
            //    obeATCNivel1.NOMBRE_ATCNivel1 = camposATCNivel1[1].ToString();

            //    brATCNivel1 obrATCNivel1 = new brATCNivel1();
            //    if (obeATCNivel1.ID_ATCNivel1 == 0)
            //    {
            //        int idATCNivel1 = obrATCNivel1.AdicionarATCNivel1(obeATCNivel1,obeDatosUsuario.Usuario);
            //        if (idATCNivel1 > 0) retorno = "Se Adiciono el ATCNivel1";
            //        else retorno = "No se pudo adicionar el ATCNivel1";
            //    }
            //    else
            //    {
            //        bool exito = obrATCNivel1.ActualizarATCNivel1(obeATCNivel1,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el ATCNivel1";
            //        else retorno = "No se pudo actualizar el ATCNivel1";
            //    }

            //    sb += ListarATCNivel1() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdATCNivel1)
        {
            string sb = "";
            string mensaje = "";
            //brATCNivel1 obrATCNivel1 = new brATCNivel1();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrATCNivel1.ActualizarEstado(Convert.ToInt32(IdATCNivel1), Estado, obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarATCNivel1() + "¬" + mensaje;
            return sb;
        }

    }
}