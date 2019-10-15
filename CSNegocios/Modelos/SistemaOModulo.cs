using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSNegocios.Modelos
{
    /// <summary>
    /// Modelo sistema o modulo
    /// </summary>
    public class SistemaOModulo
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; } = 0;
        
        /// <summary>
        /// Nombre del sistema o modulo
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Nombre a mostrar
        /// </summary>
        public string NombreAMostrar { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Url del actualizador de dicho sistem
        /// </summary>
        public string UrlActualizador { get; set; }
    }
}
