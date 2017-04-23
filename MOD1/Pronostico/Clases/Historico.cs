using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Pronostico_Diario
{
    class Historico
    {
        public String idArticulo;
        public float venta;
        public int year;
        public int month;
        public int day;
        public String dayName;

        public Historico(String idArticulo, float venta, int year, int month, int day, String dayName)
        {
            this.idArticulo = idArticulo;
            this.venta = venta;
            this.year = year;
            this.month = month;
            this.day = day;
            this.dayName = dayName;
        }

        public Historico(String idArticulo, float venta, int year, int month, int day)
        {
            this.idArticulo = idArticulo;
            this.venta = venta;
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public Historico(String idArticulo, float venta, int year, int month)
        {
            this.idArticulo = idArticulo;
            this.venta = venta;
            this.year = year;
            this.month = month;
        }
    }
}
