using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Pronostico_Diario
{
    class Factor
    {
        public float[] factor;
        public float[] factorDiario;
        public float[] factorSemanal;
        public float[] pronosticoDia;
        public int mes;
        public int year;
        public String idArticulo;
        public float pronosticoMes;
        public int diasMes;

        public Factor(int mes, int year, String idArticulo, float pronosticoMes, int diasMes)
        {
            this.mes = mes;
            this.year = year;
            this.idArticulo = idArticulo;
            this.pronosticoMes = pronosticoMes;
            this.factor = new float[diasMes];
            this.factorDiario = new float[diasMes];
            this.factorSemanal = new float[diasMes];
            this.pronosticoDia = new float[diasMes];
            this.diasMes = diasMes;
        }
    }
}
