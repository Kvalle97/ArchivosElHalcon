using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPresentacion
{
    /// <summary>
    /// Datos Globales
    /// </summary>
    class Datos_Globales
    {
        private static string sistema = "Proveedores";

        /// <summary>
        /// Nombre del sistema.
        /// </summary>
        public static string Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }

        /// <summary>
        /// Ip Local
        /// </summary>
        public static string IPLocal { get; set; }

        /// <summary>
        /// Id Empresa
        /// </summary>
        public static string ID_Empresa { get; set; }

        /// <summary>
        /// Version del sistem
        /// </summary>
        public static string VersionSistemaLocal { get; set; }

        /// <summary>
        /// Id de la sucursal
        /// </summary>
        public static int IdSucursal { get; set; }

        /// <summary>
        /// Nombre de la sucursal
        /// </summary>
        public static string NombreSucursal { get; set; }

        /// <summary>
        /// Computadora
        /// </summary>
        public static string PC { get; set; }

        /// <summary>
        /// Id Login
        /// </summary>
        public static int IdLogin { get; set; }

        /// <summary>
        /// Titulo de la empresa
        /// </summary>
        public static string TituloEmpresa { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        public static string Usuario { get; set; }

        /// <summary>
        /// Nueva password
        /// </summary>
        public static string NuevaPassword { get; set; }

        /// <summary>
        /// Paleta del usuario
        /// </summary>
        public static string userPalette { get; set; }

        /// <summary>
        /// Correo
        /// </summary>
        public static string Correo { get; set; }
    }
}