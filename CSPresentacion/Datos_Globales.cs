namespace CSPresentacion
{
    /// <summary>
    ///     Datos Globales
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal class Datos_Globales
    {
        private static readonly string saltoHtml = "</br></br>";

        public static readonly string CambioContraTemporal = $"Reestablecimos tu contraseña. {saltoHtml}" +
                                                             "Inicia sesión con tu usuario y la siguiente contraseña temporal, " +
                                                             "después de inciar sesión agrega la contraseña que " +
                                                             "deseas usar.";

        public static readonly string CambioContra = $"Reestablecimos tu contraseña. {saltoHtml}" +
                                                     "A partir de ahora inicia sesión con tu usuario y " +
                                                     "la siguiente contraseña";

        public static readonly string Bienvenida = $"Te damos la Bienvenida al Halcón. {saltoHtml}" +
                                                   "Se ha creado para ti el usuario <b>@Usuario</b> para que puedas " +
                                                   "iniciar sesión con la siguiente contraseña";

        /// <summary>
        ///     Nombre del sistema.
        /// </summary>
        public static string Sistema { get; set; } = "Proveedores";

        /// <summary>
        ///     Ip Local
        /// </summary>
        public static string IPLocal { get; set; }

        /// <summary>
        ///     Id Empresa
        /// </summary>
        public static string ID_Empresa { get; set; }

        /// <summary>
        ///     Version del sistem
        /// </summary>
        public static string VersionSistemaLocal { get; set; }

        /// <summary>
        ///     Id de la sucursal
        /// </summary>
        public static int IdSucursal { get; set; }

        /// <summary>
        ///     Nombre de la sucursal
        /// </summary>
        public static string NombreSucursal { get; set; }

        /// <summary>
        ///     Computadora
        /// </summary>
        public static string PC { get; set; }

        /// <summary>
        ///     Id Login
        /// </summary>
        public static int IdLogin { get; set; }

        /// <summary>
        ///     Titulo de la empresa
        /// </summary>
        public static string TituloEmpresa { get; set; }

        /// <summary>
        ///     Usuario
        /// </summary>
        public static string Usuario { get; set; }

        /// <summary>
        ///     Nueva password
        /// </summary>
        public static string NuevaPassword { get; set; }

        /// <summary>
        ///     Paleta del usuario
        /// </summary>
        public static string userPalette { get; set; }

        /// <summary>
        ///     Correo
        /// </summary>
        public static string Correo { get; set; }
    }
}