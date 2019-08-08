using System;

namespace MVC.Librerias.EntidadesNegocio
{
    public class beCursosImpartidos
    {
        public int ID_CURSOS_IMPARTIDOS { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public int CANTIDAD_ALUMNOS { get; set; }
        public string CERRADO { get; set; }
        public string SEDE { get; set; }
        public string NOMBRE_SEDE { get; set; }
        public decimal NUMERO_RADICADO { get; set; }
        public string DIRECCION_SEDE { get; set; }
        public int ID_CURSO_SUCURSAL { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public int ID_SUCURSAL_INSTRUCTOR { get; set; }
        public string NOMBRE_INSTRUCUTOR { get; set; }
        public int ID_SUCURSAL_EVALUADOR { get; set; }
        public string NOMBRE_EVALUADOR { get; set; }
        public int ID_CENTRO_FORMACION { get; set; }
        public string NOMBRE_CENTRO_FROMACION { get; set; }
        public int ID_SUCURSAL { get; set; }
        public string NOMBRE_SUCURSAL { get; set; }
        public string NIT { get; set; }
        public int ID_CURSO_OMI { get; set; }
        public string DESCRIPCION { get; set; }
        public string DESCRIPCION_INGLES { get; set; }
        public string CODIGO { get; set; }
        public int INTENSIDAD_HORARIA { get; set; }
        public string REGLA { get; set; }
        public int AÑOS_VIGENCIA { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public DateTime FECHA_CIERRE { get; set; }
        public int ID_LOGIN { get; set; }
        public int ID_TIPO_CURSO { get; set; }
        public string APROBO { get; set; }

        public string CADENA_ALUMNO_NUMERO_IDENTIFICACION { get; set; }
        public string CADENA_ALUMNO_NOMBRES { get; set; }
        public string CADENA_ALUMNO_APELLIDOS { get; set; }
        public string CADENA_ALUMNO_TIPO_DOCUMENTO { get; set; }
        public string CADENA_CURSO_ALUMNO_TIPO_CURSO { get; set; }
        public string CADENA_CURSO_ALUMNO_APROBO { get; set; }
        public string CADENA_CURSO_ALUMNO_ID_CURSO_ALUMNO { get; set; }
    }
}
