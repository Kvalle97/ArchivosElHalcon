namespace CSNegocios.Global
{
    /// <summary>
    ///     Tipo de documento permitidos / usados en el sistema
    /// </summary>
    public enum TipoDocumento
    {
        /// <summary>
        ///     Tipo de documento para cambio de precio
        /// </summary>
        DocumentoControlCambioDePrecio = 24,

        /// <summary>
        ///     Tipo de documento para entrada de transformaciones
        /// </summary>
        DocumentoEntradaTransformaciones = 58,

        /// <summary>
        ///     Documento Salida de transformaciones
        /// </summary>
        DocumentoSalidaTranformaciones = 25,

        /// <summary>
        ///     Documento Orden de compra
        /// </summary>
        DocumentoOrdenDeCompra = 8,

        /// <summary>
        ///     DOcumento liquiadacion
        /// </summary>
        DocumentoLiquidacion = 9,

        /// <summary>
        ///     Documento pre ingreso
        /// </summary>
        DocumentoDePreIngreso = 101
    }
}