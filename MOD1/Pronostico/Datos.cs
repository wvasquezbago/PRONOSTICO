using Calculo_Pronostico_Diario.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using MOD1;

namespace Calculo_Pronostico_Diario
{
    class Datos
    {
        
        private SqlConnection conexion;
        private SqlCommand cmd;

        public Datos()
        {
            conexion = new SqlConnection();
            cmd = new SqlCommand();
        }

        //private String conectionString()
        //{
           
        //    return
        //        @"user id=josue;" +
        //        "password=agoSAC2016;Data Source=192.168.50.175,1433;" +
        //        "Persist Security Info=True;" +
        //        "Initial Catalog=LaiveSCM;" +
        //        "database=LaiveSCM;";
        //    //@"Data Source=ASUS\SQLEXPRESS; Initial Catalog=LaiveSCM; Integrated Security=Yes ;Max Pool Size=10000";
        //    //@"Data Source=zeus;Initial Catalog=LaiveSCM;Persist Security Info=True;User ID=AppLaive;Password=password";
        //}

        public void abrirConexion()
        {
            Conex cn = new Conex();
            try
            {
                conexion.ConnectionString = cn.obtenerCadena();
                conexion.Open();
            }
            catch(Exception e)
            {
                Cursor.Current = Cursors.Default;
                this.printError(e);

            }
            
        }

        public void cerrarConexion()
        {
            conexion.Close();
        }

        public void executeStoredProcedure(String storedProcedure)
        {
            try
            {
                cmd = new SqlCommand(storedProcedure);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                this.printError(e);
            }
        }
        public int getHisDiaYears()
        {
            int histYears = 0;
            cmd = new SqlCommand("MOD1_GET_HIST_YEARS");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                histYears = Convert.ToInt16(row[0]);
            }
            return histYears;
        }

        /// <summary>
        /// Busca en la base de datos el mes futuro límite para el calculo del pronóstico. Utiliza el procedimiento MOD1_SELECT_TOP_PRON_MONTH.
        /// </summary>
        /// <returns>Mes y año limites</returns>
        /// 
        public List<int> getHDYears()
        {
            List<int> years = new List<int>();
            try
            {
                cmd = new SqlCommand("MOD1_SELECT_DISTINCT_YEAR_HD_ALL");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = conexion;
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    years.Add(Convert.ToInt32(row[0]));
                }
            }
            catch (Exception e)
            {
                printError(e);
            }
            return years;
        }
        public int[] topMonthYear()
        {
            int[] monthYear = new int[2];
            cmd = new SqlCommand("MOD1_SELECT_TOP_PRON_MONTH");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);

            foreach(DataRow row in dataTable.Rows)
            {
                monthYear[0] = Convert.ToInt16(row[1]);
                monthYear[1] = Convert.ToInt32(row[0]);
            }
            return monthYear;
        }

        /// <summary>
        /// Busca en la base de datos los pronosticos que cumplen con los paramentros de fecha. Procedimiento: MOD1_SELECT_PRO_MONTH_ORIGINAL.
        /// </summary>
        /// <param name="mesInferior">Mes inferior del cual se quiere el pronostico.</param>
        /// <param name="anInferior">Año inferior del mes del cual se quiere el pronostico.</param>
        /// <param name="mesSuperior">Mes superior del cual se quiere el pronostico.</param>
        /// <param name="anSuperior">Año superior del mes del cual se quiere el pronostico.</param>
        /// <returns>Una lista de pronosticos</returns>
        public List<Pronostico> pronosticoMensual(int mesInferior, int anInferior, int mesSuperior, int anSuperior)
        {
            List<Pronostico> pronMensual = new List<Pronostico>();
            cmd = new SqlCommand("MOD1_SELECT_PRO_MONTH_ORIGINAL");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@mes_inf", SqlDbType.Int).Value = mesInferior;
            cmd.Parameters.Add("@mes_sup", SqlDbType.Int).Value = mesSuperior;
            cmd.Parameters.Add("@an_inf", SqlDbType.Int).Value = anInferior;
            cmd.Parameters.Add("@an_sup", SqlDbType.Int).Value = anSuperior;
            cmd.Connection = conexion;

            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(dataTable);
            

            foreach (DataRow row in dataTable.Rows)
            {
                pronMensual.Add(new Pronostico(
                    Convert.ToInt32(row[0]), 
                    Convert.ToInt32(row[1]), 
                    Convert.ToString(row[2]), 
                    Convert.ToInt32(row[3])));
            }
            return pronMensual;
        }

        /// <summary>
        /// Busca en la base de datos todos los historicos para los articulos que se encuentran en los pronosticos mensuales.
        /// </summary>
        /// <param name="mesInferior">Mes inferior del rango del que se quiere el pronostico.</param>
        /// <param name="mesSuperior">Mes superior del rango del que se quiere el pronostico.</param>
        /// <param name="histYears">Años hacia atras de los caules se quiere el pronostico.</param>
        /// <returns>Lista de historicos</returns>
        public List<Historico> historicosDiario(int mesInferior, int mesSuperior)
        {
            List<Historico> historicos = new List<Historico>();
            try
            {
                cmd = new SqlCommand("MOD1_SELECT_HIS_DIA");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mes_inf", SqlDbType.Int).Value = mesInferior;
                //cmd.Parameters.Add("@mes_sup", SqlDbType.Int).Value = mesSuperior;
                cmd.Connection = conexion;

                cmd.ExecuteNonQuery();
                DataTable nuevatabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(nuevatabla);

                foreach (DataRow row in nuevatabla.Rows)
                {
                    historicos.Add(new Historico(
                        Convert.ToString(row[0]),
                        Convert.ToInt32(row[1]),
                        Convert.ToInt32(row[2]),
                        Convert.ToInt32(row[3]),
                        Convert.ToInt32(row[4]),
                        Convert.ToString(row[5])));       
                }
            }
            catch (Exception e)
            {
                printError(e);
            }
            return historicos;
        }

        /// <summary>
        /// Busca en la base de datos todos los historicos para los articulos que se encuentran en los pronosticos mensuales.
        /// </summary>
        /// <param name="mesInferior">Mes inferior del rango del que se quiere el pronostico.</param>
        /// <param name="mesSuperior">Mes superior del rango del que se quiere el pronostico.</param>
        /// <param name="histYears">Años hacia atras de los caules se quiere el pronostico.</param>
        /// <returns>Lista de historicos con atributos DateTime.</returns>
        public List<HistoricoDateTime> historicosDiarioDateTime(int mesInferior, int mesSuperior, int histYears)
        {
            List<HistoricoDateTime> historicos = new List<HistoricoDateTime>();
            try
            {
                cmd = new SqlCommand("MOD1_SELECT_HIS_DIA");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mes_inf", SqlDbType.Int).Value = mesInferior;
                //cmd.Parameters.Add("@mes_sup", SqlDbType.Int).Value = mesSuperior;
                //cmd.Parameters.Add("@histYears", SqlDbType.Int).Value = histYears;
                cmd.Connection = conexion;

                cmd.ExecuteNonQuery();
                DataTable nuevatabla = new DataTable();
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(nuevatabla);

                foreach (DataRow row in nuevatabla.Rows)
                {
                    historicos.Add(new HistoricoDateTime(
                        new DateTime(Convert.ToInt32(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4])),
                        Convert.ToString(row[0]),
                        Convert.ToInt32(row[1])));
                }
            }
            catch (Exception e)
            {
                printError(e);
            }
            return historicos.OrderBy(x => x.articulo).ThenBy(x => x.date).ToList<HistoricoDateTime>();
        }

        /// <summary>
        /// Convierte una lista de factores a DataTable para la inserción en la base de datos.
        /// </summary>
        /// <param name="factores">Lista de factores a convertir.</param>
        /// <returns>DataTable listo para la inserción.</returns>
        public DataTable toDataTable(List<Factor> factores)
        {
            DataTable dataTable;
            using (dataTable = new DataTable())
            {
                dataTable.Columns.Add("ID_DAY", typeof(int));
                dataTable.Columns.Add("ID_MONTH", typeof(string));
                dataTable.Columns.Add("ID_YEAR", typeof(int));
                dataTable.Columns.Add("ID_ARTICULO", typeof(string));
                dataTable.Columns.Add("VENTA", typeof(float));
                dataTable.Columns.Add("FECHA", typeof(DateTime));
                dataTable.Columns.Add("ID_SEM", typeof(string));

                foreach(Factor factor in factores)
                {
                    for(int i = 0; i < factor.diasMes; i++)
                    {
                        DateTime date = new DateTime(factor.year, factor.mes, i+1);
                        dataTable.Rows.Add(
                            i + 1,
                            factor.mes,
                            factor.year,
                            factor.idArticulo,
                            factor.pronosticoDia[i],
                            date,
                            ""
                        );
                    }
                }

            }
            return dataTable;
        }

        /// <summary>
        /// Inserta en la base de datos los pronosticos previamente convertidos.
        /// </summary>
        /// <param name="dataTable">DataTable a insertar.</param>
        public void exportarPronosticoDia(DataTable dataTable)
        {
            try
            {
                cmd = new SqlCommand("MOD1_SET_PRONOSTICO_DIA");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@dt_temp", SqlDbType.Structured).Value = dataTable;
                cmd.Connection = conexion;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                this.printError(e);
            }
        }


        /// <summary>
        /// Imprime los errores. En esta clase se utiliza para las exceptiones de conexión a la base de datos.
        /// </summary>
        /// <param name="e">Exception a imprimir.</param>
        private void printError(Exception e)
        {
            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
        }
    }
}
