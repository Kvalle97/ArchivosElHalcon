using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos
{
    public class TipoMovimiento
    {
        public int IdTipoMov { get; set; } = 0;
        public string TipoMov { get; set; }
        public int Afectaciones { get; set; }
        public double Presupuesto { get; set; }
    }
}