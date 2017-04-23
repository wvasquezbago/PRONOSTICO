using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Pronostico_Diario
{
    class Pronostico
    {
        public int month;
        public int year;
        public String idArticulo;
        public float venta;

        public Pronostico(int month, int year, String idArticulo, float venta)
        {
            this.month = month;
            this.year = year;
            this.idArticulo = idArticulo;
            this.venta = venta;
        }
    }
}
