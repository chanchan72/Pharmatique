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
   
    public class DepartamentoController : ApiController
    {
        
        public string ListarDepartamento()
        {
            string sb = "";
            brDepartamento obrDepartamento = new brDepartamento();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_DEPTO", Titulo = "Id Departamento", Ancho = 10 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_DEPTO", Titulo = "Nombre Departamento", Ancho = 35 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_PAIS", Titulo = "Nombre Pais", Ancho = 35 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 20 });
            campos.Add(new beDataColumn { Campo = "ID_PAIS", Titulo = "id pais", Ancho = 0 });
            beDatosGeograficos lstObeDepartamento = obrDepartamento.ListarDepartamento();
            if (lstObeDepartamento != null)
            {
               //sb = (CSV.SerializarCamposLista(lstObeDepartamento.ListaDepartamento, '|', ';', true, campos));
               //sb += "¬";
               //sb += (CSV.SerializarLista(lstObeDepartamento.ListaPaises, '|', ';', false));
            }
            return sb;
        }

        
     
        public string GuardarDepartamento()
        {
            string rpta = "";
            string retorno = "";
            string sb = "";
            //int n = (int)Request.InputStream.Length;
            //if (n > 0)
            //{
            //    io.Stream flujo = Request.InputStream;
            //    io.StreamReader lector = new io.StreamReader(flujo);
            //    rpta = lector.ReadToEnd();

            //    beDepartamento obeDepartamento = new beDepartamento();
            //    string[] camposDepartamento = rpta.Split('|');
            //    beUsuario obeDatosUsuario = new beUsuario();
            //    obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //    obeDepartamento.ID_DEPTO = int.Parse(camposDepartamento[0]);
            //    obeDepartamento.NOMBRE_DEPTO = camposDepartamento[1].ToString();
            //    obeDepartamento.ID_PAIS = int.Parse(camposDepartamento[2].ToString());

            //    brDepartamento obrDepartamento = new brDepartamento();
            //    if (obeDepartamento.ID_DEPTO == 0)
            //    {
                    
            //        int idDepartamento = obrDepartamento.AdicionarDepartamento(obeDepartamento,obeDatosUsuario.Usuario);
            //        if (idDepartamento > 0) retorno = "Se Adiciono el Departamento";
            //        else retorno = "No se pudo adicionar el Departamento";
            //    }
            //    else
            //    {
            //        bool exito = obrDepartamento.ActualizarDepartamento(obeDepartamento, obeDatosUsuario.Usuario);
            //        if (exito) retorno = "Se actualizo el departamento";
            //        else retorno = "No se pudo actualizar el departamento";
            //    }

            //    sb += ListarDepartamento() + "¬" + retorno;

            //}
            return sb;
        }

        public string GuardarCargueMasivo(beArchivo obeArchivo)
        {
            string retorno = "";
            string mensaje = "";
            brDepartamento obrDepartamento = new brDepartamento();
            byte[] Data = new byte[obeArchivo.FILES_CARGUE[0].ContentLength];
            obeArchivo.FILES_CARGUE[0].InputStream.Read(Data, 0, obeArchivo.FILES_CARGUE[0].ContentLength);
            int idDepartamento = obrDepartamento.CargueMasivo(obeArchivo.CADENA_CARGUE);
            if (idDepartamento > 0) mensaje = "Se logro el cargue masivo con exito.";
            else mensaje = "No se pudo hacer el cargo masivo.";
            retorno = ListarDepartamento() + "¬" + mensaje;
            return retorno;
        }


        public string CambioEstado(string Estado, string IdDepartamento)
        {
            string sb = "";
            string mensaje = "";
            //brDepartamento obrDepartamento = new brDepartamento();
            //beUsuario obeDatosUsuario = new beUsuario();
            //obeDatosUsuario = (HttpContext.Session["usuario"] as beUsuario);
            //bool respuesta = obrDepartamento.ActualizarEstado(Convert.ToInt32(IdDepartamento), Estado, obeDatosUsuario.Usuario);
            //if (respuesta) mensaje = "Se logro el cambio de estado con exito.";
            //else mensaje = "No se pudo hacer el cambio de estado.";


            //sb = ListarDepartamento() + "¬" + mensaje;
            return sb;
        }

    }
}