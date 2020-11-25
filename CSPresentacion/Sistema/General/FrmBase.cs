using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSpellChecker;

namespace CSPresentacion.Sistema.General
{
    /// <summary>
    ///     Formulario base, ofrece la funcionalidad básica que usualmente se usará en cada pantalla del sistema.
    /// </summary>
    public partial class FrmBase : XtraForm
    {
        /// <summary>
        ///     Constructor del formulario base
        /// </summary>
        public FrmBase()
        {
            InitializeComponent();


            //spellChecker1.SpellCheckMode = SpellCheckMode.AsYouType;
            
            //HunspellDictionary hunspellDictionary = new HunspellDictionary
            //{
            //    Culture = new CultureInfo("es-NI"),
            //    DictionaryPath = System.AppDomain.CurrentDomain.BaseDirectory + "spanish-utf8.dic",
            //    GrammarPath = System.AppDomain.CurrentDomain.BaseDirectory + "Spanish.aff"
            //};
            //hunspellDictionary.Load();

            //spellChecker1.Dictionaries.Clear();
            //spellChecker1.Dictionaries.Add(hunspellDictionary);
        }

        #region Metódos de sobrecarga.

        /// <inheritdoc />
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool ret = false;
            switch (keyData)
            {
                case Keys.Control | Keys.Down:
                    ret = AccionarBoton(btnIrAlUltimoRegistro);
                    break;
                case Keys.Control | Keys.Left:
                    ret = AccionarBoton(btnIrAlRegistroAnterior);
                    break;
                case Keys.Control | Keys.Right:
                    ret = AccionarBoton(btnIrAlSiguienteRegistro);
                    break;
                case Keys.Control | Keys.Up:
                    ret = AccionarBoton(btnIrAlPrimerRegistro);
                    break;
                case Keys.Control | Keys.N:
                    ret = AccionarBoton(btnNuevo);
                    break;
                case Keys.Control | Keys.G:
                    ret = AccionarBoton(btnGuardar);
                    break;
                case Keys.Control | Keys.Delete:
                    ret = AccionarBoton(btnAnular);
                    break;
                case Keys.Control | Keys.F11:
                    ret = AccionarBoton(btnAplicar);
                    break;
                case Keys.Control | Keys.B:
                    ret = AccionarBoton(btnBuscar);
                    break;
                case Keys.Control | Keys.E:
                    ret = AccionarBoton(btnEliminar);
                    break;
                case Keys.Control | Keys.I:
                    ret = AccionarBoton(btnImprimir);
                    break;
                case Keys.Control | Keys.S:
                    ret = AccionarBoton(btnSalir);
                    break;
                case Keys.Control | Keys.R:
                    ret = AccionarBoton(btnRevertirAnular);
                    break;
            }


            return ret;
        }

        #endregion

        #region Funciones

        /// <summary>
        ///     Dispara el llamado al boton si es valido
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        private bool AccionarBoton(BarButtonItem btn)
        {
            if (btn.Visibility == BarItemVisibility.Always && btn.Enabled)
            {
                btn.PerformClick();
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Activa o desactiva las opciones del formulario base
        /// </summary>
        /// <param name="mostrar">Activar</param>
        /// <param name="opcion">Opcion</param>
        protected void MostrarBotones(bool mostrar, params Opciones[] opcion)
        {
            BarItemVisibility visibility = mostrar ? BarItemVisibility.Always : BarItemVisibility.Never;

            foreach (Opciones op in opcion)
                switch (op)
                {
                    case Opciones.Ultimo:

                        btnIrAlUltimoRegistro.Visibility = visibility;

                        break;
                    case Opciones.Anterior:

                        btnIrAlRegistroAnterior.Visibility = visibility;

                        break;
                    case Opciones.Siguiente:

                        btnIrAlSiguienteRegistro.Visibility = visibility;

                        break;
                    case Opciones.Primero:

                        btnIrAlPrimerRegistro.Visibility = visibility;


                        break;
                    case Opciones.Nuevo:

                        btnNuevo.Visibility = visibility;

                        break;
                    case Opciones.Guardar:

                        btnGuardar.Visibility = visibility;

                        break;

                    case Opciones.Anular:
                        btnAnular.Visibility = visibility;
                        break;
                    case Opciones.Aplicar:

                        btnAplicar.Visibility = visibility;

                        break;

                    case Opciones.Buscar:

                        btnBuscar.Visibility = visibility;

                        break;
                    case Opciones.Eliminar:

                        btnEliminar.Visibility = visibility;

                        break;
                    case Opciones.Imprimir:

                        btnImprimir.Visibility = visibility;

                        break;
                    case Opciones.Cerrar:

                        btnSalir.Visibility = visibility;

                        break;
                    case Opciones.RevertirAplicar:

                        btnRevertirAnular.Visibility = visibility;

                        break;
                }
        }

        /// <summary>
        ///     Activa o desactiva el mostrar el  caption en los botones
        /// </summary>
        /// <param name="mostrar">Activar</param>
        /// <param name="opcion">Opcion</param>
        protected void MostrarCaptionEnBotones(bool mostrar, params Opciones[] opcion)
        {
            BarItemPaintStyle visibility = mostrar ? BarItemPaintStyle.CaptionGlyph : BarItemPaintStyle.Standard;

            foreach (Opciones op in opcion)
                switch (op)
                {
                    case Opciones.Ultimo:

                        btnIrAlUltimoRegistro.PaintStyle = visibility;

                        break;
                    case Opciones.Anterior:

                        btnIrAlRegistroAnterior.PaintStyle = visibility;

                        break;
                    case Opciones.Siguiente:

                        btnIrAlSiguienteRegistro.PaintStyle = visibility;

                        break;
                    case Opciones.Primero:

                        btnIrAlPrimerRegistro.PaintStyle = visibility;


                        break;
                    case Opciones.Nuevo:

                        btnNuevo.PaintStyle = visibility;

                        break;
                    case Opciones.Guardar:

                        btnGuardar.PaintStyle = visibility;

                        break;

                    case Opciones.Anular:

                        btnAnular.PaintStyle = visibility;

                        break;
                    case Opciones.Aplicar:
                        btnAplicar.PaintStyle = visibility;
                        break;

                    case Opciones.Buscar:

                        btnBuscar.PaintStyle = visibility;

                        break;
                    case Opciones.Eliminar:

                        btnEliminar.PaintStyle = visibility;

                        break;
                    case Opciones.Imprimir:

                        btnImprimir.PaintStyle = visibility;

                        break;
                    case Opciones.Cerrar:

                        btnSalir.PaintStyle = visibility;

                        break;
                    case Opciones.RevertirAplicar:

                        btnRevertirAnular.PaintStyle = visibility;

                        break;
                }
        }

        /// <summary>
        ///     Activa o desactiva el boton
        /// </summary>
        /// <param name="activar">Activar</param>
        /// <param name="opcion">Opcion</param>
        protected void ActivarBoton(bool activar, params Opciones[] opcion)
        {
            foreach (Opciones op in opcion)
                switch (op)
                {
                    case Opciones.Ultimo:

                        btnIrAlUltimoRegistro.Enabled = activar;

                        break;
                    case Opciones.Anterior:

                        btnIrAlRegistroAnterior.Enabled = activar;

                        break;
                    case Opciones.Siguiente:

                        btnIrAlSiguienteRegistro.Enabled = activar;
                        break;
                    case Opciones.Primero:

                        btnIrAlPrimerRegistro.Enabled = activar;


                        break;
                    case Opciones.Nuevo:

                        btnNuevo.Enabled = activar;

                        break;
                    case Opciones.Guardar:

                        btnGuardar.Enabled = activar;

                        break;

                    case Opciones.Anular:

                        btnAnular.Enabled = activar;

                        break;
                    case Opciones.Aplicar:
                        btnAplicar.Enabled = activar;
                        break;

                    case Opciones.Buscar:

                        btnBuscar.Enabled = activar;

                        break;
                    case Opciones.Eliminar:

                        btnEliminar.Enabled = activar;

                        break;
                    case Opciones.Imprimir:

                        btnImprimir.Enabled = activar;

                        break;
                    case Opciones.Cerrar:

                        btnSalir.Enabled = activar;

                        break;

                    case Opciones.RevertirAplicar:

                        btnRevertirAnular.Enabled = activar;

                        break;
                }
        }

        /// <summary>
        ///     Se llama al presionar el boton ir a Ultimo
        /// </summary>
        protected virtual void UltimoEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton ir al Anterior
        /// </summary>
        protected virtual void AnteriorEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton ir al Siguiente
        /// </summary>
        protected virtual void SiguienteEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton ir al Primero
        /// </summary>
        protected virtual void PrimeroEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton Nuevo
        /// </summary>
        protected virtual void NuevoEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton Nuevo
        /// </summary>
        protected virtual void GuardarEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton anular.
        /// </summary>
        protected virtual void AnularEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton aplicar
        /// </summary>
        protected virtual void AplicarEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton Nuevo
        /// </summary>
        protected virtual void BuscarEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton Eliminar
        /// </summary>
        protected virtual void EliminarEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton Nuevo
        /// </summary>
        protected virtual void ImprimirEvent()
        {
        }

        /// <summary>
        ///     Se llama al presionar el boton cerrar
        /// </summary>
        protected virtual void CerrarEvent()
        {
            Close();
        }

        /// <summary>
        ///     Se llama al presionar el boton revertir.
        /// </summary>
        protected virtual void RevertirAplicarEvent()
        {
        }

        #endregion

        #region Eventos

        private void btnIrAlUltimoRegistro_ItemClick(object sender, ItemClickEventArgs e)
        {
            UltimoEvent();
        }

        private void btnIrAlRegistroAnterior_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnteriorEvent();
        }

        private void btnIrAlSiguienteRegistro_ItemClick(object sender, ItemClickEventArgs e)
        {
            SiguienteEvent();
        }

        private void btnIrAlPrimerRegistro_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrimeroEvent();
        }

        private void btnNuevo_ItemClick(object sender, ItemClickEventArgs e)
        {
            NuevoEvent();
        }

        private void btnGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            GuardarEvent();
        }

        private void btnBuscar_ItemClick(object sender, ItemClickEventArgs e)
        {
            BuscarEvent();
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            EliminarEvent();
        }

        private void btnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImprimirEvent();
        }

        private void btnSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            CerrarEvent();
        }

        private void btnAnular_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnularEvent();
        }

        private void btnAplicar_ItemClick(object sender, ItemClickEventArgs e)
        {
            AplicarEvent();
        }

        private void btnRevertirAnular_ItemClick(object sender, ItemClickEventArgs e)
        {
            RevertirAplicarEvent();
        }

        #endregion

        #region Propiedades

        #endregion
    }
}