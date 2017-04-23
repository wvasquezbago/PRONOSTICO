using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaExcel.Tables
{
    class Forecast : Load
    {
        public String deleteProcedure;

        public Forecast(string storedProcedure, string parameterName, int[] columnPositions, String deleteProcedure) 
            : base(storedProcedure, parameterName, columnPositions)
        {
            this.deleteProcedure = deleteProcedure;
        }

        public static Forecast getDefault()
        {
            return new Forecast("MOD1_INSERT_PRO_MEN", "data", new int[] { 1, 2, 3, 4 }, "MOD1_DELETE_PRO_MEN");
        }

        public override DataTable buildDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("ID_ARTICULO", typeof(String));
            dataTable.Columns.Add("ID_YEAR", typeof(int));
            dataTable.Columns.Add("ID_MONTH", typeof(int));
            dataTable.Columns.Add("VENTA", typeof(float));
            return dataTable;
        }
    }
}
