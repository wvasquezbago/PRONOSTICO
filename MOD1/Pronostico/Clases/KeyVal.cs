using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Pronostico_Diario
{
    public class KeyVal<Key, Val>
    {
        public Key key { get; set; }
        public Val value { get; set; }

        public KeyVal() { }

        public KeyVal(Key key, Val val)
        {
            this.key = key;
            this.value = val;
        }
    }
}
