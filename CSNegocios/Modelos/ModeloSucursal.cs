using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos
{
    public class ModeloSucursal
    {
        #region Atributos básicos

        public int IdSucursal { get; set; } = -1;
        public string Sucursal { get; set; }
        public string Slogan { get; set; }
        public int TipoSucursal { get; set; } = 1;
        public string Direccion { get; set; }

        #endregion

        #region OtrosAtributos

        public string Oficina { get; set; }
        public string Telefonos { get; set; }
        public string Fax { get; set; }
        public string Email  { get; set; }
        public string WebSite { get; set; }
        public double Iva { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        #endregion
    }
}