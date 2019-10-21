namespace CSNegocios.Modelos
{
    /// <summary>
    /// Define el modelo de un rol en el sistema
    /// </summary>
    public class Rol
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Es super administrador
        /// </summary>
        public bool EsSuperAdministrador { get; set; }
    }
}