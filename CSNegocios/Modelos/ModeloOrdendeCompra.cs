using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos
{
    public class ModeloOrdendeCompra
    {
        public int IdOrden { get; set; }
        public string Sucursal { get; set; }
        public bool DolarizarOrdenDeCompra { get; set; }
        public bool ExoneradoDeIVa { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal DescuentoTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal CostoTotalOrden { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaDelDocumento { get; set; } = DateTime.Now;
        public decimal Cantidad { get; set; }
        public decimal Totalprecioproducto { get; set; }
        public string NoRuc { get; set; }
        public int ProveedorCodigo { get; set; }
        public string ProveedorDescripcion { get; set; }
        public int SucursalOrigenCodigo { get; set; }
        public string SucursalOrigen =>
           string.Concat(SucursalOrigenCodigo.ToString("SUCURSAL HALCÓN CASA MATRIZ"));
        public bool Cerrado { get; set; }
        public decimal Tc { get; set; } = 0;
        public string Contacto { get; set; }


    }
}
