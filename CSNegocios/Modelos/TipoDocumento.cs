using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos
{
    public class TipoDocumento
    {
        public int IdTipoDoc { get; set; }
        public string TipoDoc { get; set; }
        public int IdTipoMov { get; set; }
        public string Comentario { get; set; }
        public int NoInicial { get; set; } = 1;
        public int IdEmpresa { get; set; }
        public bool Contabiliza { get; set; }
        public bool Activo { get; set; } = true;
        public int Existencias { get; set; }
        
        // ReSharper disable once InconsistentNaming
        public int Cobertura_Mínima { get; set; }
        public string Impresora { get; set; }

    }
}
