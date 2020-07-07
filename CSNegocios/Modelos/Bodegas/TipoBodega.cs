using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos.Bodegas
{
    public class TipoBodega
    {
        public int IdTipoBodega { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public bool Activo { get; set; }
    }
}