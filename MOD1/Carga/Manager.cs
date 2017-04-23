using System;
using System.IO;
using System.Collections.Generic;
using CargaExcel.Tables;
using System.Diagnostics;

namespace CargaExcel
{
    class Manager
    {
        private static Manager manager;

        public static Manager getInstance()
        {
            if (manager == null) manager = new Manager();
            return manager;
        }

        private Manager() {}

        public void loadForecast(String file)
        {
            Reader reader = new Reader();
            
            reader.open(file);

            Forecast forecast = Forecast.getDefault();
            reader.getData(forecast);

            Data data = Data.getInstance();
            data.WriteToDatabase(forecast);

            data.executeStoredProcedure("MOD1_HIS_TO_MOD1HIS");
            reader.close();
        }
    }
}
