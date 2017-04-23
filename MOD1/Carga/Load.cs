using System.Collections.Generic;
using System.Data;

namespace CargaExcel.Tables
{
    public abstract class Load
    {
        public string storedProcedure;
        public string parameterName;
        public DataTable dataTable;
        public int[] columnsPositions;

        public Load() { }

        public Load(string storedProcedure, string parameterName, int[] columnPositions)
        {
            this.storedProcedure = storedProcedure;
            this.parameterName = parameterName;
            this.columnsPositions = columnPositions;
        }

        public abstract DataTable buildDataTable();
    }
}
