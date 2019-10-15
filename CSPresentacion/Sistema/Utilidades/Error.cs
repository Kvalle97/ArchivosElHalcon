using System.Windows.Forms;

namespace CSPresentacion.Sistema.Utilidades
{
    /// <summary>
    ///     Clase error, que proporciona la funcionalidad de mostrar errores de validacion en un pantalla.
    /// </summary>
    public class Error
    {
        /// <summary>
        ///     Constructor de la clase
        /// </summary>
        /// <param name="descripcionDelError"></param>
        /// <param name="controlAlertar"></param>
        public Error(string descripcionDelError, Control controlAlertar)
        {
            DescripcionDelError = descripcionDelError;
            ControlAlertar = controlAlertar;
        }

        /// <summary>
        ///     Describe el error ocurrido
        /// </summary>
        public string DescripcionDelError { get; set; }

        /// <summary>
        ///     Control en pantalla a alertar
        /// </summary>
        public Control ControlAlertar { get; set; }
    }
}