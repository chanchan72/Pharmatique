using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Genaral.Librerias.CodigoUsuario
{
    public class Objeto
    {
        public static void Grabar<T>(T obj, string archivo)
        {
            PropertyInfo[] propiedades = obj.GetType().GetProperties();
            using (StreamWriter sw = new StreamWriter(archivo,true))
            {
                object valor;
                foreach (PropertyInfo propiedad in propiedades)
                {
                    valor = propiedad.GetValue(obj, null);
                    sw.WriteLine("{0} = {1}", propiedad.Name,valor!=null?valor.ToString():"");
                }
                sw.WriteLine(new String('_', 60));
            }
        }
    }
}
