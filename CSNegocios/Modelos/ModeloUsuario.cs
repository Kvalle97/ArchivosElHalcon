using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos
{
    /// <summary>
    /// Modelo usuario
    /// </summary>
    public class ModeloUsuario
    {
        #region Propiedades del usuario

        /// <summary>
        /// Id usuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Usuaruio
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Correo
        /// </summary>
        public string email {get; set;}

        /// <summary>
        /// Id de nivel de usuario, algo como roles pero al parecer no funciona
        /// o no fue aplicado correctamente
        /// </summary>
        public int IdNivel { get; set; } = 1;

        /// <summary>
        /// Telefono
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Id Empresa ubicacion
        /// </summary>
        public int IdEmpresaUbicacion { get; set; } = -1;

        /// <summary>
        /// Activo
        /// </summary>
        public int Activo { get; set; } = 1;

        /// <summary>
        /// Id Descuento
        /// </summary>
        public int IdDescuento { get; set; }

         /// <summary>
        /// Id Promotor
        /// </summary>
        public int idPromotor{ get;set; }

          /// <summary>
        /// Id Segmento
        /// </summary>
        public int idSegmento { get; set; }

        #endregion


        // Esto queda obsoleto.

        #region Permisos del usario

        public bool Ventas { get; set; }
        public bool Inventario { get; set; }
        public bool Compras { get; set; }
        public bool Produccion { get; set; }
        public bool Cartera { get; set; }
        public bool Caja { get; set; }
        public bool Bancos { get; set; }
        public bool Administracion { get; set; }
        public bool Proveedores { get; set; }
        public bool Proyecto { get; set; }
        public bool VentaCompartida {get; set; } /*ok*/
        public bool VendedorProyectos {get;set;}  /*ok*/
        public bool GerenciaComercial { get;set;}/*ok*/
        public bool PuedePonerMetas { get;set;}/*ok*/
        public bool TieneMeta { get;set; }
        public bool  VerAverias { get;set; }
        public bool ProformaWeb { get;set; }
        public bool verMargen { get;set; }
        public bool PermitirRegalia { get;set; }
        public bool PagarFacturasMasAntiguas { get;set; }
        public bool Prestamos { get ; set; }


       

        #region PermisosKevin

        
        public bool PermitirRealizarTraslados { get; set; }
        public bool GuardarPrestamos { get; set; }
        public bool AplicarPrestamos { get; set; }

        // ReSharper disable once InconsistentNaming
        public bool AutorizarST { get; set; }
        public bool PermitirDepCompras { get; set; }
        public bool GirarPreingresos { get; set; }

        #endregion

        #endregion
    }
}