namespace CSNegocios.Modelos
{
    /// <summary>
    ///     Accion
    /// </summary>
    public class Accion
    {
        /// <summary>
        ///     Identificador
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        ///     Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        ///     Descripcion
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        ///     Auditable
        /// </summary>
        public bool Auditable { get; set; }
    }
}