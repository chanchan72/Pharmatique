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
    public class TipoClasificacionController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarPais
        /// Función: Enviar a la vista los datos serializados de la información de los paises 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarTipoClasificacion()
        {
            string sb = "";
            brTipoClasificacion obrTipoClasificacion = new brTipoClasificacion();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_TipoClasificacion", Titulo = "Id TipoClasificacion", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_TipoClasificacion", Titulo = "Nombre", Ancho = 70 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            List<beTipoClasificacion> lstObeTipoClasificacion = obrTipoClasificacion.ListarTipoClasificacion();
            if (lstObeTipoClasificacion != null)
            {
                if (lstObeTipoClasificacion.Count() > 0)
                {
                    sb = (CSV.SerializarCamposLista(lstObeTipoClasificacion, '|', ';', true, campos));
                }
                else
                {
                    sb = "Id TipoClasificacion|Nombre|Estado;10|70|20";
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

        
        public string GuardarTipoClasificacion()
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

            //    beTipoClasificacion obeTipoClasificacion = new beTipoClasificacion();
            //    string[] camposTipoClasificacion = rpta.Split('|');

            //    obeTipoClasificacion.ID_TipoClasificacion = int.Parse(camposTipoClasificacion[0]);
            //    obeTipoClasificacion.NOMBRE_TipoClasificacion = camposTipoClasificacion[1].ToString();


            //    brTipoClasificacion obrTipoClasificacion = new brTipoClasificacion();
            //    if (obeTipoClasificacion.ID_TipoClasificacion == 0)
            //    {
            //        int idTipoClasificacion = obrTipoClasificacion.AdicionarTipoClasificacion(obeTipoClasificacion,obeDatosUsuario.Usuario);
            //        if (idTipoClasificacion > 0) retorno = "Se Adiciono el TipoClasificacion";
            //        else retorno = "No se pudo adicionar el TipoClasificacion";
            //    }
            //    else
            //    {
            //        bool exito = obrTipoClasificacion.ActualizarTipoClasificacion(obeTipoClasificacion, obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el TipoClasificacion";
            //        else retorno = "No se pudo actualizar el TipoClasificacion";
            //    }

            //    sb += ListarTipoClasificacion() + "¬" + retorno;

            //}
            return sb;
        }

        public string CambioEstado(string Estado, string IdTipoClasificacion)
        {
            string sb = "";
            string mensaje = "";
            brTipoClasificacion obrTipoClasificacion = new brTipoClasificacion();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrTipoClasificacion.ActualizarEstado(Convert.ToInt32(IdTipoClasificacion), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarTipoClasificacion() + "¬" + mensaje;
            return sb;
        }
    }
}