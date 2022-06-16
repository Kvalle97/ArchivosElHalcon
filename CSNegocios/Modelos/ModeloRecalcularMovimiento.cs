using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos
{
    public class ModeloRecalcularMovimiento
    {
        
        public int IdEmpresa { get; set; }
        public int IdTipoMov { get; set; }
        public int IdTipoDoc { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public int nodoc { get; set; }
        public int periodo { get; set; }



    }
}
