using System;
using System.Data.SqlClient;
using System.Data;
using MOD1.Entidades;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MOD1
{
    class Conex
    {
        public static String cadena =

            //@"Data Source=MACBOOKPRO\SQLEXPRESS; Initial Catalog=TestLaiveSCM; Integrated Security=Yes ;Max Pool Size=10000";
            @"Data Source=192.168.1.51;Initial Catalog=TestLaiveSCM;User ID=sa;Password=Tecsup00";
            //@"Data Source=zeus;Initial Catalog=TestLaiveSCM;User ID=AppLaiveSCM;Password=laive2017";
        //@"Data Source=zeus;Initial Catalog=TestLaiveSCM;User ID=AppLaive;Password=password";
        //@"user id=Gabriel;" +
        //"password=123;Data Source=192.168.139.130,1433;" +
        //"Persist Security Info=True;" +
        //"Initial Catalog=LaiveSCM;" +
        //"database=LaiveSCM; ";

        public SqlConnection conexion()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = obtenerCadena();
            return conexion;
        }
        public void abrirCon()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = obtenerCadena();
            conexion.Open();
        }
        public void cerrarCon()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = obtenerCadena();
            conexion.Close();
        }
        public string obtenerCadena()
        {
            string cadena = Conex.cadena;
            return cadena;
        }

        public void executeStoredProcedures(List<string> storedProcedures)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = obtenerCadena();
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion;

                foreach (string procedure in storedProcedures) {
                    cmd.CommandText = procedure;
                    cmd.ExecuteNonQuery();
                }

                conexion.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error executando el SP" + Ex.Message);
            }
        }

        public DataTable execSP(string proc)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = obtenerCadena();
                conexion.Open();
                SqlCommand cmd = new SqlCommand(proc);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion;
                cmd.ExecuteNonQuery();
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(dt);
                conexion.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error obteniendo la data" + Ex.Message);
            }
            return dt;
        }
        public int execNI(string proc)
        {
            int NumInc=0;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = obtenerCadena();
                conexion.Open();
                SqlCommand cmd = new SqlCommand(proc);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NumInc = Convert.ToInt32(dr["INCOM"]);
                }
                conexion.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error obteniendo la data" + Ex.Message);
            }

            return NumInc;
        }
        public void updHisDia(string proc)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = obtenerCadena();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(proc, conexion))
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception Ex)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception("Error obteniendo la data" + Ex.Message);
            }
        }
        public void updPronDiarioDiscreto(string proc, EPronDiario pron)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = obtenerCadena();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(proc, conexion))
                {
                    cmd.Parameters.Add("@ID_ARTICULO", SqlDbType.VarChar).Value = pron.ID_ARTICULO;
                    cmd.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = pron.FECHA;
                    cmd.Parameters.Add("@VENTA", SqlDbType.Float).Value = pron.VENTA;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error obteniendo la data" + Ex.Message);
            }
        }
        public void updPronSemDiscreto(string proc, EPronSem pron)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = obtenerCadena();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(proc, conexion))
                {
                    cmd.Parameters.Add("@ID_ARTICULO", SqlDbType.VarChar).Value = pron.ID_ARTICULO;
                    cmd.Parameters.Add("@ID_SEM", SqlDbType.VarChar).Value = pron.ID_SEM;
                    cmd.Parameters.Add("@VENTA", SqlDbType.Float).Value = pron.VENTA;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error obteniendo la data" + Ex.Message);
            }
        }
        public void updPronMensual(string proc, EPronMen pron)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = obtenerCadena();
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(proc, conexion))
                {
                    cmd.Parameters.Add("@ID_ARTICULO", SqlDbType.VarChar).Value = pron.ID_ARTICULO;
                    cmd.Parameters.Add("@ID_YEAR", SqlDbType.Int).Value = pron.ID_YEAR;
                    cmd.Parameters.Add("@ID_MONTH", SqlDbType.Int).Value = pron.ID_MONTH;
                    cmd.Parameters.Add("@VENTA", SqlDbType.Float).Value = pron.VENTA;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error obteniendo la data" + Ex.Message);
            }
        }
        
    }
}
