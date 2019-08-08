using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using General.Librerias.EntidadesNegocio;

namespace Genaral.Librerias.CodigoUsuario
{
    public class CSV
    {
        public static string SerializarLista<T>(List<T> lista,char separaradorCampos='|',char separadorRegistros=';',bool tieneCabecera = true)
        {
            StringBuilder sb = new StringBuilder();
            if (lista != null && lista.Count > 0)
            {
                PropertyInfo[] propiedades;
                if (tieneCabecera)
                {
                    propiedades = lista[0].GetType().GetProperties();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        sb.Append(propiedad.Name);
                        sb.Append(separaradorCampos);
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                    sb.Append(separadorRegistros);
                }
                object valor;
                for (int i = 0; i < lista.Count; i++)
                {
                    propiedades = lista[i].GetType().GetProperties();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        valor = propiedad.GetValue(lista[i], null);
                        if (valor != null) sb.Append(valor.ToString());
                        else sb.Append("");
                        sb.Append(separaradorCampos);
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                    sb.Append(separadorRegistros);
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        public static string SerializarCamposLista<T>(List<T> Lista, char SeparadorCampo = '|', char SeparadorRegistros = ';', bool TieneCabecera = true, List<beDataColumn> Columnas = null)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbAncho = new StringBuilder();
            PropertyInfo[] oPropiedades = Lista[0].GetType().GetProperties();
            List<string> propiedades = null;
            int nCols;
            int pos = -1;
            int nFilas = Lista.Count;
            //Crear la primera fila con las cabeceras de los Campos
            if (Columnas != null && Columnas.Count > 0)
            {
                propiedades = new List<string>();
                foreach (PropertyInfo oPropiedad in oPropiedades)
                {
                    propiedades.Add(oPropiedad.Name);
                }
                nCols = Columnas.Count;
                if (TieneCabecera)
                {
                    for (int j = 0; j < nCols; j++)
                    {
                        pos = propiedades.IndexOf(Columnas[j].Campo);
                        if (pos > -1)
                        {
                            sb.Append(Columnas[j].Titulo);
                            sb.Append(SeparadorCampo);
                            sbAncho.Append(Columnas[j].Ancho);
                            sbAncho.Append(SeparadorCampo);
                        }
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                    sb.Append(SeparadorRegistros);
                    sbAncho = sbAncho.Remove(sbAncho.Length - 1, 1);
                    sbAncho.Append(SeparadorRegistros);
                    sb.Append(sbAncho.ToString());
                }
            }
            else
            {
                if(TieneCabecera)
                {
                    foreach (PropertyInfo oPropiedad in oPropiedades)
                    {
                        sb.Append(oPropiedad.Name);
                        sb.Append(SeparadorCampo);
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                    sb.Append(SeparadorRegistros);
                }
            }
            //Crear filas con los registros 
            string tipo;
            string propiedad = "";
            object valor;
            for (int i = 0; i < nFilas; i++)
            {
                oPropiedades = Lista[i].GetType().GetProperties();
                if (Columnas == null)
                {
                    nCols = oPropiedades.Length;
                    for (int j = 0; j < nCols; j++)
                    {
                        propiedad = oPropiedades[j].Name;
                        tipo = oPropiedades[j].PropertyType.ToString().ToLower();
                        valor = oPropiedades[j].GetValue(Lista[i], null);
                        if (valor != null)
                        {
                            if (tipo.Contains("byte[]")) valor = Convert.ToBase64String((byte[])valor);
                            sb.Append(valor.ToString());
                        }
                        else sb.Append("");
                        sb.Append(SeparadorCampo);
                    }
                }
                else
                {
                    nCols = Columnas.Count;
                    for (int j = 0; j < nCols; j++)
                    {
                        pos = propiedades.IndexOf(Columnas[j].Campo);
                        if (pos > -1)
                        {
                            propiedad = Columnas[j].Campo;
                            tipo = Lista[i].GetType().GetProperty(propiedad).ToString().ToLower();
                            valor = Lista[i].GetType().GetProperty(propiedad).GetValue(Lista[i],null);
                            if (valor != null)
                            {
                                if (tipo.Contains("byte[]")) valor = Convert.ToBase64String((byte[])valor);
                                else
                                {
                                    //if (tipo.Contains("datetime")) valor = String.Format("{0:dd-MM-yyyy HH:mm:ss}", valor);
                                    if (tipo.Contains("datetime")) valor = String.Format("{0:s}", valor);
                                }
                                sb.Append(valor.ToString());
                            }
                            else sb.Append("");
                            sb.Append(SeparadorCampo);
                        }
                    }
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.Append(SeparadorRegistros);
            }
            sb = sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public static string SerializarObjeto<T>(T obj, char SeparadorCampo = '|', List<string> Campos = null)
        {
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            PropertyInfo propiedad;
            string tipo;
            object valor;
            if (Campos != null)
            {
                foreach (var campo in Campos)
                {
                    propiedad = obj.GetType().GetProperty(campo);
                    if (propiedad != null)
                    {
                        tipo = propiedad.PropertyType.ToString().ToLower();
                        valor = propiedad.GetValue(obj, null);
                        if (valor != null)
                        {
                            if (tipo.Contains("datetime")) valor = String.Format("{0:s}", valor);
                            else
                            {
                                if (tipo.Contains("byte[]")) valor = Convert.ToBase64String((byte[])valor);
                            }
                            sb.Append(valor.ToString());
                            sb.Append(SeparadorCampo);
                        }
                        else sb.Append("");
                    }
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }
            else
            {
                foreach (PropertyInfo prop in propiedades)
                {
                    tipo = prop.PropertyType.ToString().ToLower();
                    valor = prop.GetValue(obj, null);
                    if (valor != null)
                    {
                        if (tipo.Contains("datetime")) valor = String.Format("{0:s}", valor);
                        else
                        {
                            if (tipo.Contains("byte[]")) valor = Convert.ToBase64String((byte[])valor);
                        }
                        sb.Append(valor.ToString());
                        sb.Append(SeparadorCampo);
                    }
                    else sb.Append("");
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }    
            return sb.ToString();
        }
    }
}
