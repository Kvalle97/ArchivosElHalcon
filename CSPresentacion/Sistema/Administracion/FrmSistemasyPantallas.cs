using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    ///     Formulario Sistema
    /// </summary>
    public partial class FrmSistemasyPantallas : XtraForm
    {
        private static FrmSistemasyPantallas childlInstance;
        private readonly ServicioSistemasyPantallas servicioSistemasyPantallas = new ServicioSistemasyPantallas();
        private SistemaOModulo sistemaOModulo = new SistemaOModulo();
        private Pantalla pantalla = new Pantalla();

        /// <summary>
        ///     Constructor
        /// </summary>
        public FrmSistemasyPantallas()
        {
            InitializeComponent();
        }

        #region Metodos

        /// <summary>
        ///     Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmSistemasyPantallas Instance()
        {
            if (childlInstance == null || childlInstance.IsDisposed)
            {
                childlInstance = new FrmSistemasyPantallas();
            }

            childlInstance.BringToFront();

            return childlInstance;
        }

        private void CargarSistemaOModulo()
        {
            txtNombreSistema.Text = sistemaOModulo.Nombre;
            txtNombreAMostrarSistema.Text = sistemaOModulo.NombreAMostrar;
            txtLinkActualizadorSistema.Text = sistemaOModulo.UrlActualizador;
            meDescripcionSistema.Text = sistemaOModulo.Descripcion;
        }

        private void CargarPantalla()
        {
            txtNombreDePantalla.Text = pantalla.Nombre;
            ckbEsReporte.Checked = pantalla.EsReporte;
            meDescripcionPantalla.Text = pantalla.Descripcion;
        }

        #endregion

        #region Eventos

        private void FrmSistemasyPantallas_Load(object sender, System.EventArgs e)
        {
            try
            {
                servicioSistemasyPantallas.MostrarSistemas(gcSistemaOModulo, gvSistemaOModulo);
                servicioSistemasyPantallas.MostrarPantallas(gcPantallas, gvPantallas);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnNuevoSistemaOModulo_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.ClearErrors();

                sistemaOModulo = new SistemaOModulo();

                servicioSistemasyPantallas.MostrarSistemas(gcSistemaOModulo, gvSistemaOModulo);

                CargarSistemaOModulo();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvSistemaOModulo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvSistemaOModulo.FocusedRowHandle < 0) return;

                sistemaOModulo = UIHelper.ObtenerItem<SistemaOModulo>(
                    servicioSistemasyPantallas.ObtenerSistemaOModulo(
                        Convert.ToInt32(gvSistemaOModulo.GetFocusedDataRow()["Id"])));

                CargarSistemaOModulo();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnGuardarSistema_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.ClearErrors();

                if (string.IsNullOrEmpty(txtNombreSistema.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombreSistema, "Escriba un nombre valido");
                    return;
                }

                if (servicioSistemasyPantallas.ElNombreDelSistemaEstaEnUso(sistemaOModulo.Id, txtNombreSistema.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombreSistema, "El nombre ya esta en uso");
                    return;
                }

                sistemaOModulo.Nombre = txtNombreSistema.Text;
                sistemaOModulo.NombreAMostrar = txtNombreAMostrarSistema.Text;
                sistemaOModulo.UrlActualizador = txtLinkActualizadorSistema.Text;
                sistemaOModulo.Descripcion = meDescripcionSistema.Text;

                servicioSistemasyPantallas.GuardarSistemaOModulo(sistemaOModulo);

                btnNuevoSistemaOModulo.PerformClick();
            }
            catch (SqlException exception)
            {
                UIHelper.MostrarError(exception);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnQuitarSistema_Click(object sender, EventArgs e)
        {
            try
            {
                if (sistemaOModulo.Id <= 0)
                {
                    UIHelper.AlertarDeError("Primero seleccione un sistema o modulo");
                }
                else
                {
                    if (UIHelper.PreguntarSn($"Esta seguro que desea eliminar {sistemaOModulo.Nombre}") ==
                        DialogResult.Yes)
                    {
                        servicioSistemasyPantallas.EliminarSistemaOModulo(sistemaOModulo.Id);
                    }
                }
            }
            catch (SqlException exception)
            {
                UIHelper.MostrarError(exception);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnNuevoPantalla_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.ClearErrors();

                pantalla = new Pantalla();

                servicioSistemasyPantallas.MostrarPantallas(gcPantallas, gvPantallas);

                CargarPantalla();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnGuardarPantalla_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.ClearErrors();

                if (string.IsNullOrWhiteSpace(txtNombreDePantalla.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombreDePantalla, "Nombre de la pantalla no valida");
                    return;
                }

                if (servicioSistemasyPantallas.ElNombreDeLaPantallaEstaEnUso(pantalla.Id, pantalla.Nombre))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombreDePantalla, "El nombre ya esta siendo usado");
                    return;
                }

                pantalla.Nombre = txtNombreDePantalla.Text;
                pantalla.EsReporte = ckbEsReporte.Checked;
                pantalla.Descripcion = meDescripcionPantalla.Text;

                servicioSistemasyPantallas.GuardarPantalla(pantalla);

                btnNuevoPantalla.PerformClick();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnQuitarPantalla_Click(object sender, EventArgs e)
        {
            try
            {
                if (pantalla.Id > 0)
                {
                    if (UIHelper.PreguntarSn($"Está seguro que desea eliminar la panta {pantalla.Nombre}") ==
                        DialogResult.Yes)
                    {
                        servicioSistemasyPantallas.EliminarPantalla(pantalla.Id);

                        btnNuevoPantalla.PerformClick();
                    }
                }
                else
                {
                    UIHelper.AlertarDeError("Primero seleccione una pantalla");
                }
            }
            catch (SqlException exception)
            {
                UIHelper.MostrarError(exception);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvPantallas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvPantallas.FocusedRowHandle < 0) return;

                pantalla = UIHelper.ObtenerItem<Pantalla>(
                    servicioSistemasyPantallas.ObtenerPantalla(
                        Convert.ToInt32(gvPantallas.GetFocusedDataRow()["Id"])));
                
                CargarPantalla();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion
    }
}