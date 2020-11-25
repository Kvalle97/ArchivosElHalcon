using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos
{
    public class ModeloBodega
    {
        public string IdBodega { get; set; }
        public string Descripcion { get; set; }
        public string Comentarios { get; set; }
        public string CuentaCosto { get; set; }
        public int IdSucursal { get; set; }
    }
}