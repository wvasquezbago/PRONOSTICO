using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Pronostico_Diario.Clases
{
    class HistoricoDateTime
    {
        public DateTime date;
        public String articulo;
        public float venta;

        public HistoricoDateTime(DateTime date, String articulo, float venta)
        {
            this.date = date;
            this.articulo = articulo;
            this.venta = venta;
        }

        public HistoricoDateTime() { }
    }
}
