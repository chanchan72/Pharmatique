using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Libreria.EntidadesNegocio;
using System.Data.SqlClient;
using System.Data;

namespace MVC.Libreria.AccesoDatos
{
    public class daGerente
    {
        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: ListarCiudad
        /// Función: Enlace con la base de datos y realiza un select a la tabla "PS_CIUDAD" para 
        ///          consultar las ciudades existentes y traer los paises y departamentos existentes para llenar el control 
        ///          que maneja el listado de los paises y departamentos
        /// Retorno: Variable "obeDatosGeograficos" de tipo "beDatosGeograficos"
        /// Fecha Documentación: 8 de abril de 2019
        /// </summary>

        public beDatosGerente ListaGerente(SqlConnection con)
        {
            beDatosGerente obeDatosGerente = new beDatosGerente();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Gerente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                obeDatosGerente.ListaGerentes = new List<beGerente>();
                beGerente obeGerente;
                int posID_GERENTE_VENTAS = drd.GetOrdinal("ID_GERENTE_VENTAS");
                int posCEDULA_GERENTE_VENTAS = drd.GetOrdinal("CEDULA_GERENTE_VENTAS");
                int posNOMBRE_GERENTE_VENTAS = drd.GetOrdinal("NOMBRE_GERENTE_VENTAS");
                int posESTADO = drd.GetOrdinal("ESTADO");
                int posID_PAIS = drd.GetOrdinal("ID_PAIS");
                int posNOMBRE_PAIS = drd.GetOrdinal("NOMBRE_PAIS");
                int posID_DEPTO = drd.GetOrdinal("ID_DEPTO");
                int posNOMBRE_DEPARTAMENTO = drd.GetOrdinal("NOMBRE_DEPTO");
                int posID_CIUDAD = drd.GetOrdinal("ID_CIUDAD");
                int posNOMBRE_CIUDAD = drd.GetOrdinal("CIUDAD");
                int posID_DISTRITO = drd.GetOrdinal("ID_DISTRITO");
                int posNOMBRE_DISTRITO = drd.GetOrdinal("DISTRITO");
                int posDIRECCION = drd.GetOrdinal("DIRECCION");
                int posCORREO = drd.GetOrdinal("CORREO");
                int posTELEFONO = drd.GetOrdinal("TELEFONO");
                int posCUMPLEANOS = drd.GetOrdinal("CUMPLEANOS");
                int posHOBBIES = drd.GetOrdinal("HOBBIES");
                while (drd.Read())
                {
                    obeGerente = new beGerente();
                    if (!drd.IsDBNull(posID_GERENTE_VENTAS)) obeGerente.ID_GERENTE_VENTAS = drd.GetInt32(posID_GERENTE_VENTAS);
                    if (!drd.IsDBNull(posCEDULA_GERENTE_VENTAS)) obeGerente.CEDULA_GERENTE_VENTAS = drd.GetInt32(posCEDULA_GERENTE_VENTAS);
                    if (!drd.IsDBNull(posNOMBRE_GERENTE_VENTAS)) obeGerente.NOMBRE_GERENTE_VENTAS = drd.GetString(posNOMBRE_GERENTE_VENTAS);
                    if (!drd.IsDBNull(posESTADO)) obeGerente.ESTADO = drd.GetString(posESTADO);
                    if (!drd.IsDBNull(posID_PAIS)) obeGerente.ID_PAIS = drd.GetInt32(posID_PAIS);
                    if (!drd.IsDBNull(posNOMBRE_PAIS)) obeGerente.NOMBRE_PAIS = drd.GetString(posNOMBRE_PAIS);
                    if (!drd.IsDBNull(posID_DEPTO)) obeGerente.ID_DEPTO = drd.GetInt32(posID_DEPTO);
                    if (!drd.IsDBNull(posNOMBRE_DEPARTAMENTO)) obeGerente.NOMBRE_DEPARTAMENTO = drd.GetString(posNOMBRE_DEPARTAMENTO);
                    if (!drd.IsDBNull(posID_CIUDAD)) obeGerente.ID_CIUDAD = drd.GetInt32(posID_CIUDAD);
                    if (!drd.IsDBNull(posNOMBRE_CIUDAD)) obeGerente.NOMBRE_CIUDAD = drd.GetString(posNOMBRE_CIUDAD);
                    if (!drd.IsDBNull(posID_DISTRITO)) obeGerente.ID_DISTRITO = drd.GetInt32(posID_DISTRITO);
                    if (!drd.IsDBNull(posNOMBRE_DISTRITO)) obeGerente.NOMBRE_DISTRITO = drd.GetString(posNOMBRE_DISTRITO);
                    if (!drd.IsDBNull(posDIRECCION)) obeGerente.DIRECCION = drd.GetString(posDIRECCION);
                    if (!drd.IsDBNull(posCORREO)) obeGerente.CORREO = drd.GetString(posCORREO);
                    if (!drd.IsDBNull(posTELEFONO)) obeGerente.TELEFONO = drd.GetString(posTELEFONO);
                    if (!drd.IsDBNull(posCUMPLEANOS)) obeGerente.CUMPLEANOS = drd.GetDateTime(posCUMPLEANOS);
                    if (!drd.IsDBNull(posHOBBIES)) obeGerente.HOBBIES = drd.GetString(posHOBBIES);
                    obeDatosGerente.ListaGerentes.Add(obeGerente);
                }
                if (drd.NextResult())
                {
                    obeDatosGerente.ListaPaises = new List<bePais>();
                    bePais obePais;
                    int posIdPais = drd.GetOrdinal("ID_PAIS");
                    int posNombre = drd.GetOrdinal("NOMBRE_PAIS");
                    int posEstado = drd.GetOrdinal("ESTADO");
                    while (drd.Read())
                    {
                        obePais = new bePais();
                        if (!drd.IsDBNull(posIdPais)) obePais.ID_PAIS = drd.GetInt32(posIdPais);
                        if (!drd.IsDBNull(posNombre)) obePais.NOMBRE_PAIS = drd.GetString(posNombre);
                        if (!drd.IsDBNull(posEstado)) obePais.ESTADO = drd.GetString(posEstado);
                        obeDatosGerente.ListaPaises.Add(obePais);
                    }
                }

                if (drd.NextResult())
                {

                    //beDepartamento obeDepartamento;
                    //obeDatosGerente.ListaDepartamentos = new List<beDepartamento>();
                    //int posID_DEPTO1 = drd.GetOrdinal("ID_DEPTO");
                    //int NOMBRE_DEPTO1 = drd.GetOrdinal("NOMBRE_DEPTO");
                    //int posID_PAIS1 = drd.GetOrdinal("ID_PAIS");
                    //int posESTADO1 = drd.GetOrdinal("ESTADO");
                    //while (drd.Read())
                    //{
                    //    obeDepartamento = new beDepartamento();
                    //    if (!drd.IsDBNull(posID_DEPTO1)) obeDepartamento.ID_DEPTO = drd.GetInt32(posID_DEPTO1);
                    //    if (!drd.IsDBNull(NOMBRE_DEPTO1)) obeDepartamento.NOMBRE_DEPTO = drd.GetString(NOMBRE_DEPTO1);
                    //    if (!drd.IsDBNull(posID_PAIS1)) obeDepartamento.ID_PAIS = drd.GetInt32(posID_PAIS1);
                    //    if (!drd.IsDBNull(posESTADO1)) obeDepartamento.ESTADO = drd.GetString(posESTADO1);
                    //    obeDatosGerente.ListaDepartamentos.Add(obeDepartamento);
                    //}
                }

                if (drd.NextResult())
                {
                    obeDatosGerente.ListaCiudad = new List<beCiudad>();
                    beCiudad obeCiudad;
                    int posID_CIUDAD1 = drd.GetOrdinal("ID_CIUDAD");
                    int posCIUDAD = drd.GetOrdinal("CIUDAD");
                    int posID_DEPTO1 = drd.GetOrdinal("ID_DEPTO");
                    int posESTADO1 = drd.GetOrdinal("estado");
                    while (drd.Read())
                    {
                        obeCiudad = new beCiudad();
                        if (!drd.IsDBNull(posID_CIUDAD1)) obeCiudad.ID_CIUDAD = drd.GetInt32(posID_CIUDAD1);
                        if (!drd.IsDBNull(posCIUDAD)) obeCiudad.CIUDAD = drd.GetString(posCIUDAD);
                        if (!drd.IsDBNull(posID_DEPTO1)) obeCiudad.ID_DEPTO = drd.GetInt32(posID_DEPTO1);
                        if (!drd.IsDBNull(posESTADO1)) obeCiudad.ESTADO = drd.GetString(posESTADO1);
                        obeDatosGerente.ListaCiudad.Add(obeCiudad);
                    }
                }
                if (drd.NextResult())
                {
                    beDistrito obeDistrito;
                    obeDatosGerente.ListaDistrito = new List<beDistrito>();
                    int posIdDistrito = drd.GetOrdinal("ID_DISTRITO");
                    int posNombre = drd.GetOrdinal("DISTRITO");
                    int posEstado = drd.GetOrdinal("ESTADO");
                    while (drd.Read())
                    {
                        obeDistrito = new beDistrito();
                        if (!drd.IsDBNull(posIdDistrito)) obeDistrito.ID_Distrito = drd.GetInt32(posIdDistrito);
                        if (!drd.IsDBNull(posNombre)) obeDistrito.NOMBRE_Distrito = drd.GetString(posNombre);
                        if (!drd.IsDBNull(posEstado)) obeDistrito.ESTADO = drd.GetString(posEstado);
                        obeDatosGerente.ListaDistrito.Add(obeDistrito);
                    }
                }
                drd.Close();
            }
            return obeDatosGerente;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarCiudad
        /// Función: Enlace con la base de datos y realiza un insert a la tabla "PS_CIUDAD" para 
        ///          ingresar una ciudad nueva
        /// Retorno: Variable "idElemento" de tipo "int"
        /// Fecha Documentación: 8 de abril de 2019
        /// </summary>
        public int AdicionarGerente(SqlConnection con, beGerente obeGerente)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Gerente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CEDULA_GERENTE_VENTAS", obeGerente.CEDULA_GERENTE_VENTAS);
            cmd.Parameters.AddWithValue("@NOMBRE_GERENTE_VENTAS", obeGerente.NOMBRE_GERENTE_VENTAS);
            cmd.Parameters.AddWithValue("@ID_PAIS", obeGerente.ID_PAIS);
            cmd.Parameters.AddWithValue("@ID_DEPTO", obeGerente.ID_DEPTO);
            cmd.Parameters.AddWithValue("@ID_CIUDAD", obeGerente.ID_CIUDAD);
            cmd.Parameters.AddWithValue("@ID_DISTRITO", obeGerente.ID_DISTRITO);
            cmd.Parameters.AddWithValue("@DIRECCION", obeGerente.DIRECCION);
            cmd.Parameters.AddWithValue("@CORREO", obeGerente.CORREO);
            cmd.Parameters.AddWithValue("@TELEFONO", obeGerente.TELEFONO);
            cmd.Parameters.AddWithValue("@CUMPLEANOS", obeGerente.CUMPLEANOS);
            cmd.Parameters.AddWithValue("@HOBBIES", obeGerente.HOBBIES);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        /// <summary>
        /// Autor: Sebastian Mateus Villegas
        /// Nombre del Metodo: AdicionarPais
        /// Función: Enlace con la base de datos y realiza un update a la tabla "PS_CIUDAD" para 
        ///          actualizar una ciudad que este en la tabla
        /// Retorno: Variable "exito" de tipo "bool"
        /// Fecha Documentación: 8 de abril de 2019
        /// </summary>
        public bool ActualizarGerente(SqlConnection con, beGerente obeGerente)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Gerente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_GERENTE_VENTAS", obeGerente.ID_GERENTE_VENTAS);
            cmd.Parameters.AddWithValue("@CEDULA_GERENTE_VENTAS", obeGerente.CEDULA_GERENTE_VENTAS);
            cmd.Parameters.AddWithValue("@NOMBRE_GERENTE_VENTAS", obeGerente.NOMBRE_GERENTE_VENTAS);
            cmd.Parameters.AddWithValue("@ID_PAIS", obeGerente.ID_PAIS);
            cmd.Parameters.AddWithValue("@ID_DEPTO", obeGerente.ID_DEPTO);
            cmd.Parameters.AddWithValue("@ID_CIUDAD", obeGerente.ID_CIUDAD);
            cmd.Parameters.AddWithValue("@ID_DISTRITO", obeGerente.ID_DISTRITO);
            cmd.Parameters.AddWithValue("@DIRECCION", obeGerente.DIRECCION);
            cmd.Parameters.AddWithValue("@CORREO", obeGerente.CORREO);
            cmd.Parameters.AddWithValue("@TELEFONO", obeGerente.TELEFONO);
            cmd.Parameters.AddWithValue("@CUMPLEANOS", obeGerente.CUMPLEANOS);
            cmd.Parameters.AddWithValue("@HOBBIES", obeGerente.HOBBIES);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
