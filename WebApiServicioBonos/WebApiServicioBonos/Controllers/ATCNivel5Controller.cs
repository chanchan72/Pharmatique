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
    public class ATCNivel5Controller : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarATCNivel5()
        {
            string sb = "";
            brATCNivel5 obrATCNivel5 = new brATCNivel5();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_ATCNivel5", Titulo = "Id ATCNivel5", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_ATCNivel5", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beATCNivel5> lstObeATCNivel5 = obrATCNivel5.ListarATCNivel5();
            if (lstObeATCNivel5 != null)
            {
                if (lstObeATCNivel5.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeATCNivel5, '|', ';', true, campos));
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


        public string GuardarATCNivel5()
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

            //    beATCNivel5 obeATCNivel5 = new beATCNivel5();
            //    string[] camposATCNivel5 = rpta.Split('|');

            //    obeATCNivel5.ID_ATCNivel5 = int.Parse(camposATCNivel5[0]);
            //    obeATCNivel5.NOMBRE_ATCNivel5 = camposATCNivel5[1].ToString();

            //    brATCNivel5 obrATCNivel5 = new brATCNivel5();
            //    if (obeATCNivel5.ID_ATCNivel5 == 0)
            //    {
            //        int idATCNivel5 = obrATCNivel5.AdicionarATCNivel5(obeATCNivel5,obeDatosUsuario.Usuario);
            //        if (idATCNivel5 > 0) retorno = "Se Adiciono el ATCNivel5";
            //        else retorno = "No se pudo adicionar el ATCNivel5";
            //    }
            //    else
            //    {
            //        bool exito = obrATCNivel5.ActualizarATCNivel5(obeATCNivel5,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el ATCNivel5";
            //        else retorno = "No se pudo actualizar el ATCNivel5";
            //    }
            //    sb += ListarATCNivel5() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdATCNivel5)
        {
            string sb = "";
            string mensaje = "";
            //brATCNivel5 obrATCNivel5 = new brATCNivel5();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrATCNivel5.ActualizarEstado(Convert.ToInt32(IdATCNivel5), Estado, obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarATCNivel5() + "¬" + mensaje;
            return sb;
        }

    }
}