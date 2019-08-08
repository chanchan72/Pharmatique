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
    /// Nombre de la clase: CiudadController 
    /// Función: Establece comunicacion con el javascript "jsCiudad.js" para el paso de datos a la vista 
    /// Fecha Documentación: 8 de abril de 2019
    /// </summary>
    public class CiudadController : ApiController
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarCiudad
        /// Función: Enviar a la vista los datos serializados de la información de las ciudades 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 5 de abril de 2019
        /// </summary>
        public string ListarCiudad()
        {
            string sb = "";
            brCiudad obrDepartamento = new brCiudad();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_CIUDAD", Titulo = "Id Ciudad", Ancho = 5 });
            campos.Add(new beDataColumn { Campo = "CIUDAD", Titulo = "Nombre Ciudad", Ancho = 30 });
            campos.Add(new beDataColumn { Campo = "DEPARTAMENTO", Titulo = "Nombre Departamento", Ancho = 30 });
            campos.Add(new beDataColumn { Campo = "PAIS", Titulo = "Nombre Pais", Ancho = 30 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 5 });
            campos.Add(new beDataColumn { Campo = "ID_DEPTO", Titulo = "Id Departamento", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_PAIS", Titulo = "id pais", Ancho = 0 });
            beDatosGeograficos lstObeDatos = obrDepartamento.ListarCiudad();
            if (lstObeDatos != null)
            {
                //sb = (CSV.SerializarCamposLista(lstObeDatos.ListaCiudades, '|', ';', true, campos));
                //sb += "¬";
                //sb += (CSV.SerializarLista(lstObeDatos.ListaDepartamento, '|', ';', false));
                //sb += "¬";
                //sb += (CSV.SerializarLista(lstObeDatos.ListaPaises, '|', ';', false));
            }
            return sb;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: GuardarCiudad
        /// Función: Recibe los datos de la vista, los guarda en un objeto de tipo "beCiudad" y si el id del Departamento viene 
        ///          vacio envia a insertar el dato, sino lo envia a actualizar. 
        /// Retorno: Variable "sb" de tipo "string"
        /// Fecha Documentación: 8 de abril de 2019
        /// </summary>

       
        public string GuardarCiudad()
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

            //    beCiudad obeCiudad = new beCiudad();
            //    string[] camposDepartamento = rpta.Split('|');

            //    obeCiudad.ID_CIUDAD = int.Parse(camposDepartamento[0]);
            //    obeCiudad.CIUDAD = camposDepartamento[1].ToString();
            //    obeCiudad.ID_DEPTO = int.Parse(camposDepartamento[2].ToString());
            //    obeCiudad.ID_PAIS = int.Parse(camposDepartamento[3].ToString());
            //    brCiudad obrCiudad = new brCiudad();
            //    if (int.Parse(camposDepartamento[4]) == 0)
            //    {
            //        int idDepartamento = obrCiudad.AdicionarCiudad(obeCiudad,obeDatosUsuario.Usuario);
            //        if (idDepartamento > 0) retorno = "Se Adiciono el Ciudad";
            //        else retorno = "No se pudo adicionar el Ciudad";
            //    }
            //    else
            //    {
            //        bool exito = obrCiudad.ActualizarCiudad(obeCiudad,obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el Ciudad";
            //        else retorno = "No se pudo actualizar el Ciudad";
            //    }

            //    sb += ListarCiudad() + "¬" + retorno;

            //}
            return sb;
        }


        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brCiudad obrCiudad = new brCiudad();
            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);
            int idCiudad = obrCiudad.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idCiudad > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarCiudad() + "¬" + mensaje;
            return retorno;
        }

        public string CambioEstado(string Estado, string IdCiudad)
        {
            string sb = "";
            string mensaje = "";
            //brCiudad obrCiudad = new brCiudad();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrCiudad.ActualizarEstado(Convert.ToInt32(IdCiudad), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";
            //sb = ListarCiudad() + "¬" + mensaje;
            return sb;
        }

    }

}