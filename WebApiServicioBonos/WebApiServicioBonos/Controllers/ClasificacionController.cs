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
    public class ClasificacionController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarClasificacion()
        {
            string sb = "";
            brClasificacion obrClasificacion = new brClasificacion();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_Clasificacion", Titulo = "Id Clasificacion", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_Clasificacion", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beClasificacion> lstObeClasificacion = obrClasificacion.ListarClasificacion();
            if (lstObeClasificacion != null)
            {
                if (lstObeClasificacion.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeClasificacion, '|', ';', true, campos));
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

        
        public string GuardarClasificacion()
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

            //    beClasificacion obeClasificacion = new beClasificacion();
            //    string[] camposClasificacion = rpta.Split('|');

            //    obeClasificacion.ID_Clasificacion = int.Parse(camposClasificacion[0]);
            //    obeClasificacion.NOMBRE_Clasificacion = camposClasificacion[1].ToString();

            //    brClasificacion obrClasificacion = new brClasificacion();
            //    if (obeClasificacion.ID_Clasificacion == 0)
            //    {
            //        int idClasificacion = obrClasificacion.AdicionarClasificacion(obeClasificacion,obeDatosUsuario.Usuario);
            //        if (idClasificacion > 0) retorno = "Se Adiciono el Clasificacion";
            //        else retorno = "No se pudo adicionar el Clasificacion";
            //    }
            //    else
            //    {
            //        bool exito = obrClasificacion.ActualizarClasificacion(obeClasificacion,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Clasificacion";
            //        else retorno = "No se pudo actualizar el Clasificacion";
            //    }

            //    sb += ListarClasificacion() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdClasificacion)
        {
            string sb = "";
            string mensaje = "";
            //brClasificacion obrClasificacion = new brClasificacion();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrClasificacion.ActualizarEstado(Convert.ToInt32(IdClasificacion), Estado, obeDatosUsuario.Usuario);

            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarClasificacion() + "¬" + mensaje;
            return sb;
        }

        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brClasificacion obrClasificacion = new brClasificacion();

            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);


            int idCursoImp = obrClasificacion.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idCursoImp > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarClasificacion() + "¬" + mensaje;
            return retorno;
        }
    }
}