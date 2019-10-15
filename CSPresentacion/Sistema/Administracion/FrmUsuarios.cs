using System;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.General;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    ///     Formulario de usuarios
    /// </summary>
    public partial class FrmUsuarios : FrmBase
    {
        private static FrmUsuarios childInstance;

        private readonly ServicioUsuarios servicioUsuarios = new ServicioUsuarios();

        /// <summary>
        ///     Constructor
        /// </summary>
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Crear una nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmUsuarios Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmUsuarios();

                childInstance.MostrarBotones(true, Opciones.Guardar, Opciones.Cerrar, Opciones.Nuevo,
                    Opciones.Eliminar);

                childInstance.MostrarCaptionEnBotones(true, Opciones.Guardar, Opciones.Cerrar, Opciones.Nuevo,
                    Opciones.Eliminar);
            }

            childInstance.BringToFront();

            return childInstance;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            servicioUsuarios.CargarUsuarios(gcUsuarios, gvUsuarios);
            servicioUsuarios.CargarSucursales(lueSucursalDeOrigen, false);
            servicioUsuarios.CargarNiveles(lueNievelDeAcceso);
        }
    }
}