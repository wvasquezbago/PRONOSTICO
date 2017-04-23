using Calculo_Pronostico_Diario.Clases;
using MOD1.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Pronostico_Diario
{
    class Calculo
    {
        List<Factor> factores;
        DateTime now;

        public Calculo()
        {
            factores = new List<Factor>();
            now = DateTime.Now;
        }

        /// <summary>
        /// Es el metodo principal de esta clase. 
        /// Primero, executa store procedures iniciales. 
        /// Luego, recorre cada pronostico y por cada uno encuentra los historicos correspondientes al pronostico mensual y la va agrupando
        /// de tal forma que luego se pueda procesar. Despues, de encontrar todos los historicos de cada pronostico mensual se calcula los factores de tal 
        /// pronostico mensual y se obtiene el pronostico diario.
        /// Finalmente, se exportan los resultados en la base de datos y se actualizan algunas tablas.
        /// </summary>
        public void calcularPronosticoDiario(PesosAnios pesos)
        {
            Datos dat = new Datos();
            dat.abrirConexion();
            dat.executeStoredProcedure("MOD1_DELETE_PRONOSTICO_DIA");
            dat.executeStoredProcedure("MOD1_DELETE_PRONO_SEM");
            int histYears = dat.getHisDiaYears();

            int[] monthYear = dat.topMonthYear();

            List<Pronostico> pronosticosMensuales = dat.pronosticoMensual(now.Month, now.Year, monthYear[0], monthYear[1]);
            List<Historico> historicoDiario = dat.historicosDiario(now.Month, monthYear[0]);

            foreach (Pronostico pron in pronosticosMensuales)
            {
                int diasMes = DateTime.DaysInMonth(pron.year, pron.month);

                float[] ventaAgrup = new float[5];
                float[,] ventaDiaSemAnio = new float[7, histYears];

                foreach (Historico hist in historicoDiario)
                {
                    if (hist.month == pron.month && hist.idArticulo == pron.idArticulo && pron.year - hist.year <= histYears)
                    {
                        this.agruparVentasSuma(hist.day, hist.year, hist.venta, ventaAgrup, pesos);

                        DateTime date = new DateTime(hist.year, hist.month, hist.day);
                        ventaDiaSemAnio[(int)date.DayOfWeek, pron.year - hist.year - 1] += hist.venta;
                    }
                }

                Factor factor = new Factor(pron.month, pron.year, pron.idArticulo, pron.venta, diasMes);
                this.calcularFactorSemanal(ventaAgrup, factor);
                this.calcularFactorDiario(ventaDiaSemAnio, factor, pesos);

                this.obtenerPronosticoDia(factor, diasMes);
                factores.Add(factor);
            }
            //this.printFactores();
            //this.printHistorico(4);
            dat.exportarPronosticoDia(dat.toDataTable(factores));
            dat.executeStoredProcedure("MOD1_ACTUALIZA_IDSEM");
            dat.executeStoredProcedure("MOD1_SET_PRONO_SEMANA");
            dat.executeStoredProcedure("MOD1_COPIA_RES_PRON");
            dat.cerrarConexion();
            Console.WriteLine("Finished");
        }

        private void agruparVentasSuma(int dia, int year, float venta, float[] ventaAgrup, PesosAnios pesos)
        {
            int diaMenos = dia - 1;
            int key = diaMenos / 6;
            if (key == 5) { key = 4; }

            ventaAgrup[key] += venta * pesos.pesos[now.Year - year - 1];
        }

        private void calcularFactorSemanal(float[] ventaAgrup, Factor factor)
        {
            float totalVentas = 0;
            int diasMes = factor.diasMes;
            int key;
            float[] datos = new float[diasMes];
            DateTime date;

            for (int i = 0; i < diasMes; i++)
            {
                date = new DateTime(factor.year, factor.mes, i + 1);
                if (date.DayOfWeek != DayOfWeek.Sunday)
                {
                    key = i / 6;
                    if (key == 5)
                    {
                        key = 4;
                    }
                    datos[i] = (float)Math.Pow(ventaAgrup[key], 1.25d);
                    totalVentas += datos[i];
                }
            }
            this.calcularFactorX(totalVentas, datos, factor.factorSemanal, factor);
        }

        private void calcularFactorDiario(float[,] ventaDiaSemAnio, Factor factor, PesosAnios pesos)
        {
            int diasMes = factor.diasMes;
            KeyVal<int, float>[] ventaDiaSem = new KeyVal<int, float>[7];
            float[] ventaDia = new float[diasMes];
            float total = 0;
            DateTime date;

            for (int i = 0; i < ventaDiaSemAnio.GetLength(0); i++)
            {
                ventaDiaSem[i] = new KeyVal<int, float>(i, 0);
                for (int j = 0; j < ventaDiaSemAnio.GetLength(1); j++)
                {
                    ventaDiaSem[i].value += ventaDiaSemAnio[i, j] * pesos.pesos[j];
                }
            }

            Array.Sort<KeyVal<int, float>>(ventaDiaSem,
                            delegate (KeyVal<int, float> x, KeyVal<int, float> y) {
                                return x.value.CompareTo(y.value);
                            });

            for (int i = 0; i < ventaDiaSem.Length; i++)
            {
                ventaDiaSem[i].value = ventaDiaSem[i].value * (float)Math.Pow(10, 1 + (0.1d * i));
            }

            for (int i = 0; i < diasMes; i++)
            {
                date = new DateTime(factor.year, factor.mes, i + 1);
                foreach (KeyVal<int, float> item in ventaDiaSem)
                {
                    if ((int)date.DayOfWeek == item.key)
                    {
                        ventaDia[i] = item.value;
                    }
                }
                total += ventaDia[i];
            }

            this.calcularFactorX(total, ventaDia, factor.factorDiario, factor);
        }

        private void obtenerPronosticoDia(Factor factor, int diasMes)
        {
            for (int i = 0; i < diasMes; i++)
            {
                factor.factor[i] = (factor.factorDiario[i] * 35 + 65 * factor.factorSemanal[i]) / 100;
                factor.pronosticoDia[i] = factor.pronosticoMes * factor.factor[i];
            }
        }

        private void calcularFactorX(float total, float[] datosDiarios, float[] subFactor, Factor factor)
        {
            int diasSinDom;
            int diasMes = factor.diasMes;
            DateTime date;

            diasSinDom = diasMes - CountDays(DayOfWeek.Sunday, factor.mes, factor.year);

            for (int i = 0; i < diasMes; i++)
            {
                if (total == 0)
                {
                    date = new DateTime(factor.year, factor.mes, i + 1);
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        subFactor[i] = 0;
                    }
                    else
                    {
                        subFactor[i] = 1.0f / diasSinDom;
                    }
                }
                else
                {
                    subFactor[i] = datosDiarios[i] / total;
                }
            }
        }

        private void printFactores()
        {
            using (StreamWriter file = new StreamWriter(@"./resultados.txt"))
            {
                file.WriteLine("{0,10}{1,10}{2,10}{3,15}{4,15}{5,15}{6,15}{7,15}", "Articulo", "Mes", "Pron", "Año", "Factor1", "Factor2", "Factor Total", "Pronostico Día");
                foreach (Factor fac in factores)
                {
                    file.WriteLine("\n");
                    file.WriteLine("{0,10}{1,10}{2,10}{3,15}", fac.idArticulo, fac.mes, fac.pronosticoMes, fac.year);
                    for (int i = 0; i < fac.factor.Length; i++)
                    {
                        file.WriteLine("{0,60}{1,15}{2,15}{3,15}",
                            Math.Round(fac.factorSemanal[i], 4),
                            Math.Round(fac.factorDiario[i], 4),
                            Math.Round(fac.factor[i], 4),
                            Math.Round(fac.pronosticoDia[i], 4));
                    }
                }
            }

        }

        public void printHistorico(int histYears)
        {
            String articulo = "";

            Datos dat = new Datos();
            dat.abrirConexion();
            int[] monthYear = dat.topMonthYear();
            List<HistoricoDateTime> historicoDiario = dat.historicosDiarioDateTime(now.Month, monthYear[0], histYears);
            dat.cerrarConexion();

            using (StreamWriter file = new StreamWriter(@"./historia.txt"))
            {
                file.WriteLine("{0,10}", "Historia Diaria por Año y por Producto");
                file.WriteLine("{0,15} {1,15} {2,15} ", "Articulo", "Fecha", "Venta");
                foreach (HistoricoDateTime hist in historicoDiario)
                {
                    if (articulo != hist.articulo)
                    {
                        articulo = hist.articulo;
                        file.WriteLine("\n");
                        file.WriteLine("{0,15}", articulo);
                    }

                    file.WriteLine("{0, 30} {1, 15}", hist.date.ToShortDateString(), hist.venta);

                }
            }

        }

        public int CountDays(DayOfWeek day, int month, int year)
        {
            DateTime start = new DateTime(year, month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);
            TimeSpan ts = end - start;                       // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }

    }
}
