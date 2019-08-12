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
    public class daDepartamentos
    {       

        public beDatosGeograficos ListaDepartamento(SqlConnection con)
        {
            beDatosGeograficos obeDatosDepartamento = new beDatosGeograficos();
            SqlCommand cmd = new SqlCommand("sp_Consultar_Departamentos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {
                //obeDatosDepartamento.ListaDepartamento = new List<beDepartamento>();
                //beDepartamento obeDepartamento;

                //int posID_DEPTO = drd.GetOrdinal("ID_DEPTO");
                //int NOMBRE_DEPTO = drd.GetOrdinal("NOMBRE_DEPTO");
                //int posNOMBRE_PAIS = drd.GetOrdinal("NOMBRE_PAIS");
                //int posID_PAIS = drd.GetOrdinal("ID_PAIS");
                //int posESTADO = drd.GetOrdinal("ESTADO");
                //while (drd.Read())
                //{
                //    obeDepartamento = new beDepartamento();
                //    obeDepartamento.ID_DEPTO = drd.GetInt32(posID_DEPTO);
                //    obeDepartamento.NOMBRE_DEPTO = drd.GetString(NOMBRE_DEPTO);
                //    obeDepartamento.NOMBRE_PAIS = drd.GetString(posNOMBRE_PAIS);
                //    obeDepartamento.ID_PAIS = drd.GetInt32(posID_PAIS);
                //    obeDepartamento.ESTADO = drd.GetString(posESTADO);
                //    obeDatosDepartamento.ListaDepartamento.Add(obeDepartamento);
                //}

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
        

        
        public int AdicionarDepartamento(SqlConnection con, string usuario)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_Insertar_Departamento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            /*cmd.Parameters.AddWithValue("@NOMBRE_DEPTO", obeDepartamento.NOMBRE_DEPTO);
            cmd.Parameters.AddWithValue("@ID_PAIS", obeDepartamento.ID_PAIS);*/
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }

        
        public bool ActualizarDepartamento(SqlConnection con, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_Actualizar_Departamento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ID_DEPTO", obeDepartameno.ID_DEPTO);
            //cmd.Parameters.AddWithValue("@NOMBRE_DEPTO", obeDepartameno.NOMBRE_DEPTO);
            //cmd.Parameters.AddWithValue("@ID_PAIS", obeDepartameno.ID_PAIS);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }

        public int CargueMasivo(SqlConnection con, string Cadena)
        {
            int idElemento = -1;
            SqlCommand cmd = new SqlCommand("sp_CargueMasivo_Departamentos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CADENA", Cadena);
            int nRegistros = cmd.ExecuteNonQuery();
            if (nRegistros > 0)
            {
                idElemento = nRegistros;
            }
            return idElemento;
        }


        public bool ActualizarEstado(SqlConnection con, int IdDepartamento, string Estado, string usuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("sp_ActualizarEstado_Departamento", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_DEPARTAMENTO", IdDepartamento);
            cmd.Parameters.AddWithValue("@ESTADO", Estado);
            cmd.Parameters.AddWithValue("@USUARIO", usuario);
            int nRegistros = cmd.ExecuteNonQuery();
            exito = (nRegistros > 0);
            return exito;
        }
    }
}
