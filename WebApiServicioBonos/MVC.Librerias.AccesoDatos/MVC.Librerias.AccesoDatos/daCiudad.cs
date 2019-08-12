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
    
    public class daCiudad
    {
        

        public beDatosGeograficos ListaCiudad(SqlConnection con)
        {

            beDatosGeograficos obeDatosDepartamento = new beDatosGeograficos();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Ciudad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                obeDatosDepartamento.ListaCiudades = new List<beCiudad>();
                beCiudad obeCiudad;
                int posID_CIUDAD = drd.GetOrdinal("ID_CIUDAD");
                int posCIUDAD = drd.GetOrdinal("CIUDAD");
                int posID_DEPTO = drd.GetOrdinal("ID_DEPTO");
                int NOMBRE_DEPTO = drd.GetOrdinal("NOMBRE_DEPTO");
                int posNOMBRE_PAIS = drd.GetOrdinal("NOMBRE_PAIS");
                int posID_PAIS = drd.GetOrdinal("ID_PAIS");
                int posESTADO = drd.GetOrdinal("ESTADO");
                while (drd.Read())
                {
                    obeCiudad = new beCiudad();
                    obeCiudad.ID_CIUDAD = drd.GetInt32(posID_CIUDAD);
                    obeCiudad.CIUDAD = drd.GetString(posCIUDAD);
                    obeCiudad.ID_DEPTO = drd.GetInt32(posID_DEPTO);
                    obeCiudad.DEPARTAMENTO = drd.GetString(NOMBRE_DEPTO);
                    obeCiudad.ID_PAIS = drd.GetInt32(posID_PAIS);
                    obeCiudad.PAIS = drd.GetString(posNOMBRE_PAIS);
                    obeCiudad.ESTADO = drd.GetString(posESTADO);
                    obeDatosDepartamento.ListaCiudades.Add(obeCiudad);
                }

                if (drd.NextResult())
                {
                    
                    //beDepartamento obeDepartamento;
                    //obeDatosDepartamento.ListaDepartamento = new List<beDepartamento>();
                    //int posID_DEPTO1 = drd.GetOrdinal("ID_DEPTO");
                    //int NOMBRE_DEPTO1 = drd.GetOrdinal("NOMBRE_DEPTO");
                    //int posID_PAIS1 = drd.GetOrdinal("ID_PAIS");
                    //int posESTADO1 = drd.GetOrdinal("ESTADO");
                    //while (drd.Read())
                    //{
                    //    obeDepartamento = new beDepartamento();
                    //    obeDepartamento.ID_DEPTO = drd.GetInt32(posID_DEPTO1);
                    //    obeDepartamento.NOMBRE_DEPTO = drd.GetString(NOMBRE_DEPTO1);
                    //  //  obeDepartamento.NOMBRE_PAIS = drd.GetString(posNOMBRE_PAIS1);
                    //    obeDepartamento.ID_PAIS = drd.GetInt32(posID_PAIS1);
                    //    obeDepartamento.ESTADO = drd.GetString(posESTADO1);
                    //    obeDatosDepartamento.ListaDepartamento.Add(obeDepartamento);
                    //}
                }
                if (drd.NextResult())
                {
                    obeDatosDepartamento.ListaPaises = new List<bePais>();
                    bePais obePais;
                    int posIdPais = drd.GetOrdinal("ID_PAIS");
                    int posNombre = drd.GetOrdinal("NOMBRE_PAIS");
                    int posEstado = drd.GetOrdinal("ESTADO");
                    while (drd.Read())
                    {
                        obePais = new bePais();
                        obePais.ID_PAIS = drd.GetInt32(posIdPais);
                        obePais.NOMBRE_PAIS = drd.GetString(posNombre);
                        obePais.ESTADO = drd.GetString(posEstado);
                        obeDatosDepartamento.ListaPaises.Add(obePais);
                    }
                }
                drd.Close();
            }
            return obeDatosDepartamento;
        }

        public int AdicionarCiudad(SqlConnection con, beCiudad obeCiudad, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Ciudad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CIUDAD", obeCiudad.ID_CIUDAD);
            cmd.Parameters.AddWithValue("@CIUDAD", obeCiudad.CIUDAD);
            cmd.Parameters.AddWithValue("@ID_DEPTO", obeCiudad.ID_DEPTO);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarCiudad(SqlConnection con, beCiudad obeCiudad, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Ciudad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CIUDAD", obeCiudad.ID_CIUDAD);
            cmd.Parameters.AddWithValue("@CIUDAD", obeCiudad.CIUDAD);
            cmd.Parameters.AddWithValue("@ID_DEPTO", obeCiudad.ID_DEPTO);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }


        public int CargueMasivo(SqlConnection con, string Cadena)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Ciudad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CADENA", Cadena);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        public bool ActualizarEstado(SqlConnection con, int IdCiudad, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Ciudad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CIUDAD", IdCiudad);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
