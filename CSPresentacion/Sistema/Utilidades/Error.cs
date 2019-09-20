using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPresentacion.Sistema.Utilidades
{
    /// <summary>
    /// Clase error, que proporciona la funcionalidad de mostrar errores de validacion en un pantalla.
    /// </summary>
    public class Error
    {
        private string descripcionDelError;
        private Control controlAlertar;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="descripcionDelError"></param>
        /// <param name="controlAlertar"></param>
        public Error(string descripcionDelError, Control controlAlertar)
        {
            this.DescripcionDelError = descripcionDelError;
            this.controlAlertar = controlAlertar;
        }

        /// <summary>
        /// Describe el error ocurrido
        /// </summary>
        public string DescripcionDelError
        {
            get { return descripcionDelError; }
            set { descripcionDelError = value; }
        }

        /// <summary>
        /// Control en pantalla a alertar
        /// </summary>
        public Control ControlAlertar
        {
            get { return controlAlertar; }
            set { controlAlertar = value; }
        }
    }
}