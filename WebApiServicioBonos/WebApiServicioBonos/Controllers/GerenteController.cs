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
    public class GerenteController : ApiController
    {
        
        public string ListarGerente()
        {
            string sb = "";
            brGerente obrGerente = new brGerente();
            List<beDataColumn> campos = new List<beDataColumn>();
            campos.Add(new beDataColumn { Campo = "ID_GERENTE_VENTAS", Titulo = "Id Gerente", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "CEDULA_GERENTE_VENTAS", Titulo = "Cedula", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_GERENTE_VENTAS", Titulo = "Nombre", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "ESTADO", Titulo = "Estado", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_PAIS", Titulo = "Pais", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_DEPARTAMENTO", Titulo = "Departamento", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_CIUDAD", Titulo = "Ciudad", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "NOMBRE_DISTRITO", Titulo = "Distrito", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "DIRECCION", Titulo = "Dirección", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "CORREO", Titulo = "Correo", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "TELEFONO", Titulo = "Telefono", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "CUMPLEANOS", Titulo = "Cumpleaños", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "HOBBIES", Titulo = "Hobbies", Ancho = 7 });
            campos.Add(new beDataColumn { Campo = "ID_PAIS", Titulo = "id pais", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_DEPTO", Titulo = "Id Departamento", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_CIUDAD", Titulo = "id ciudad", Ancho = 0 });
            campos.Add(new beDataColumn { Campo = "ID_DISTRITO", Titulo = "Id distrito", Ancho = 0 });
            beDatosGerente lstObeDatos = obrGerente.ListarGerente();
            if (lstObeDatos != null)
            {
                //if (lstObeDatos.ListaGerentes.Count() > 0)
                //{
                //    sb = (CSV.SerializarCamposLista(lstObeDatos.ListaGerentes, '|', ';', true, campos));
                //    sb += "¬";
                //    sb += (CSV.SerializarLista(lstObeDatos.ListaPaises, '|', ';', false));
                //    sb += "¬";
                //    sb += (CSV.SerializarLista(lstObeDatos.ListaDepartamentos, '|', ';', false));
                //    sb += "¬";
                //    sb += (CSV.SerializarLista(lstObeDatos.ListaCiudad, '|', ';', false));
                //    sb += "¬";
                //    sb += (CSV.SerializarLista(lstObeDatos.ListaDistrito, '|', ';', false));
                //}
                //else
                //{
                //    sb = "Id Gerente|Cedula|Nombre|Estado|Pais|Departamento|Ciudad|Distrito|Dirección|Correo|Telefono|Cumpleaños|Hobbies";
                //    sb+= ";5|5|5|5|5|5|5|5|5|5|5|5|5";
                //}
            }
            return sb;
        }

       

        
        public string GuardarGerente()
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
            //    beGerente obeGerente = new beGerente();
            //    string[] camposGerente = rpta.Split('|');
            //    obeGerente.ID_GERENTE_VENTAS = int.Parse(camposGerente[0]);
            //    obeGerente.CEDULA_GERENTE_VENTAS = int.Parse(camposGerente[1].ToString());
            //    obeGerente.NOMBRE_GERENTE_VENTAS = camposGerente[2].ToString();
            //    obeGerente.ID_PAIS = int.Parse(camposGerente[3].ToString());
            //    obeGerente.ID_DEPTO = int.Parse(camposGerente[4].ToString());
            //    obeGerente.ID_CIUDAD = int.Parse(camposGerente[5].ToString());
            //    obeGerente.ID_DISTRITO = int.Parse(camposGerente[6].ToString());
            //    obeGerente.DIRECCION = camposGerente[7].ToString();
            //    obeGerente.CORREO = camposGerente[8].ToString();
            //    obeGerente.TELEFONO = camposGerente[9].ToString();
            //    obeGerente.CUMPLEANOS = DateTime.Parse(camposGerente[10].ToString());
            //    obeGerente.HOBBIES = camposGerente[11].ToString();

            //    brGerente obrGerente = new brGerente();
            //    if (int.Parse(camposGerente[0]) == 0)
            //    {
            //        int idGerente = obrGerente.AdicionarGeneral(obeGerente);
            //        if (idGerente > 0) retorno = "Se Adiciono el Gerente";
            //        else retorno = "No se pudo adicionar el gerente";
            //    }
            //    else
            //    {
            //        bool exito = obrGerente.ActualizarGerente(obeGerente);
            //        if (exito) retorno = "Se actualizo el Gerente";
            //        else retorno = "No se pudo actualizar el Gerente";
            //    }

            //    sb += ListarGerente() + "¬" + retorno;

            //}
            return sb;
        }
    }
}