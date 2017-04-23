using CargaExcel.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace CargaExcel
{
    class Reader
    {
        private Excel.Range usedRange;
        private Excel.Worksheet worksheet;
        private Excel.Workbook workbook;
        private Excel.Application xlApp;

        public Reader() {}

        public void open(String file)
        {
            xlApp = new Excel.Application();
            this.workbook = xlApp.Workbooks.Open(file, ReadOnly: true);
            this.worksheet = workbook.Worksheets[1];
        }

        public DataTable getData(Load load)
        {
            DataTable table = load.buildDataTable();
            usedRange = worksheet.UsedRange.SpecialCells(Excel.XlCellType.xlCellTypeConstants);

            int rowsCnt = usedRange.Rows.Count;
            int colCnt = load.columnsPositions.Count();
            object[,] data = usedRange.Value2;

            DataRow row;
            String colName;
            int col;
            Boolean rowIsFilled;
            
            Console.WriteLine("Rows: " + rowsCnt);
            Console.WriteLine("Columns: " + colCnt);

            for (int i = 2; i <= rowsCnt; i++)
            {
                row = table.NewRow();
                rowIsFilled = false;
                for (int j = 0; j < colCnt; j++)
                {
                    col = load.columnsPositions[j];
                    if (data[i, col] != null)
                    {
                        rowIsFilled = true;
                        colName = table.Columns[j].ColumnName;                        
                        row[colName] = data[i, col];
                    }                   
                }
                if(rowIsFilled)table.Rows.Add(row);
            }
            Console.WriteLine("Done!");
            return table;
        }

        public void close()
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(usedRange);

            //close and release
            workbook.Close(false);
            Marshal.ReleaseComObject(workbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
