using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPresentacion.Sistema.General;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario Sistema
    /// </summary>
    public partial class FrmAdministracionDeSistema : FrmBase
    {
        private static FrmAdministracionDeSistema childlInstance = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmAdministracionDeSistema()
        {
            InitializeComponent();
        }

        #region Metodos

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmAdministracionDeSistema Instance()
        {
            if (childlInstance == null || childlInstance.IsDisposed)
            {
                childlInstance = new FrmAdministracionDeSistema();

                childlInstance.MostrarBotones(true, Opciones.Guardar, Opciones.Eliminar, Opciones.Nuevo);
                childlInstance.MostrarCaptionEnBotones(true, Opciones.Guardar, Opciones.Eliminar, Opciones.Nuevo);
            }

            return childlInstance;
        }

        #endregion
    }
}