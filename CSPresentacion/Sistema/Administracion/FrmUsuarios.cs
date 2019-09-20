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
    /// Formulario de usuarios
    /// </summary>
    public partial class FrmUsuarios : FrmBase
    {

        private static FrmUsuarios childInstance = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crear una nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmUsuarios Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmUsuarios();

                childInstance.MostrarBotones(true, Opciones.Guardar, Opciones.Cerrar, Opciones.Nuevo, Opciones.Eliminar);

                childInstance.MostrarCaptionEnBotones(true, Opciones.Guardar, Opciones.Cerrar, Opciones.Nuevo, Opciones.Eliminar);
            }
            return childInstance;
        }

        private void tpOpcionesGenerales_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
