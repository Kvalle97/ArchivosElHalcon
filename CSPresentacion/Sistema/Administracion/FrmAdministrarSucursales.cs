using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmAdministrarSucursales : FrmBase
    {
        private static FrmAdministrarSucursales _childInstance = null;

        private readonly ServicioAdministracionSucursales servicioAdministracionSucursales =
            new ServicioAdministracionSucursales();

        private ModeloSucursal mSucursal = new ModeloSucursal();

        private FrmAdministrarSucursales()
        {
            InitializeComponent();
        }

        #region Metodos

        public static FrmAdministrarSucursales Instance()
        {
            if (_childInstance is null || _childInstance.IsDisposed)
            {
                _childInstance = new FrmAdministrarSucursales();
            }

            _childInstance.MostrarBotones(true, Opciones.Nuevo, Opciones.Guardar);

            return _childInstance;
        }

        private void CargarSucursal()
        {
            try
            {
                if (!gvEmpresas.IsValidRowHandle(gvEmpresas.FocusedRowHandle)) return;

                CargarSucursal(
                    Convert.ToInt32(
                        gvEmpresas.GetRowCellValue(gvEmpresas.FocusedRowHandle, "IdEmpresa")));
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        private void CargarSucursal(int sucursal)
        {
            try
            {
                DataRow dr = servicioAdministracionSucursales.CargarInfoSucursal(sucursal);

                mSucursal = UIHelper.ObtenerItem<ModeloSucursal>(dr);

                seSucursalId.EditValue = mSucursal.IdSucursal;
                txtSucursal.Text = mSucursal.Sucursal;
                txtSlogan.Text = mSucursal.Slogan;
                lueTipoDeSucursal.EditValue = mSucursal.TipoSucursal;
                memoDireccion.Text = mSucursal.Direccion;
                txtOficina.Text = mSucursal.Oficina;
                txtTelefonos.Text = mSucursal.Telefonos;
                txtFax.Text = mSucursal.Fax;
                txtEmail.Text = mSucursal.Email;
                txtWebSite.Text = mSucursal.WebSite;
                seIva.EditValue = mSucursal.Iva;
                txtNombre.Text = mSucursal.Nombre;
                txtNombreCorto.Text = mSucursal.NombreCorto;

                if (mSucursal.IdSucursal == -1)
                {
                    tabCuentas.PageEnabled = false;
                    gvCuentas.Columns.Clear();
                    gcCuentas.DataSource = null;
                    tabSucursal.SelectedTabPage = tabOtrosAtributos;
                    seSucursalId.ReadOnly = false;
                }
                else
                {
                    seSucursalId.ReadOnly = true;
                    tabCuentas.PageEnabled = true;
                    servicioAdministracionSucursales.CargarCuentaEmpresa(gcCuentas, gvCuentas, mSucursal.IdSucursal);
                }
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        #endregion

        #region Sobrecargas

        protected override void GuardarEvent()
        {
            dxErrorProvider.ClearErrors();

            if (string.IsNullOrWhiteSpace(txtSucursal.Text))
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtSucursal, "El campo sucursal es obligatorio");
                return;
            }

            if (seSucursalId.Value < 0)
            {
                UIHelper.AlertarDeError(dxErrorProvider, seSucursalId, "El id debe ser mayor a cero");
                return;
            }

            try
            {
                bool validarIdInterfaz = false;
                if (mSucursal.IdSucursal == -1)
                {
                    int val = servicioAdministracionSucursales.ExisteElIdSucursal(Convert.ToInt32(seSucursalId.Value));

                    if (val > 0)
                    {
                        UIHelper.AlertarDeError(dxErrorProvider, seSucursalId, "El id ya está usuado");
                        return;
                    }

                    validarIdInterfaz = true;
                }


                mSucursal.IdSucursal = Convert.ToInt32(seSucursalId.EditValue);
                mSucursal.Sucursal = txtSucursal.Text;
                mSucursal.Slogan = txtSlogan.Text;
                mSucursal.TipoSucursal = Convert.ToInt32(lueTipoDeSucursal.EditValue);
                mSucursal.Direccion = memoDireccion.Text;
                mSucursal.Oficina = txtOficina.Text;
                mSucursal.Telefonos = txtTelefonos.Text;
                mSucursal.Iva = Convert.ToDouble(seIva.Value);
                mSucursal.Fax = txtFax.Text;
                mSucursal.Email = txtEmail.Text;
                mSucursal.WebSite = txtWebSite.Text;
                mSucursal.Nombre = txtNombre.Text;
                mSucursal.NombreCorto = txtNombreCorto.Text;

                servicioAdministracionSucursales.GuardarSucursal(mSucursal, Datos_Globales.IdLogin);

                if (validarIdInterfaz)
                {
                    seSucursalId.EditValue = mSucursal.IdSucursal;
                    seSucursalId.ReadOnly = true;
                }

                
                servicioAdministracionSucursales.CargarSucursales(gcEmpresas);

                XtraMessageBox.Show("Se ha guardado con exito la sucursal");
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        protected override void NuevoEvent()
        {
            dxErrorProvider.ClearErrors();
            CargarSucursal(-1);
        }

        #endregion

        #region Eventos

        private void FrmAdministrarSucursales_Shown(object sender, EventArgs e)
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere", "Cargando pantalla");

            wait.Show();

            try
            {
                servicioAdministracionSucursales.CargarSucursales(gcEmpresas);
                servicioAdministracionSucursales.CargarTipoDeSucursales(lueTipoDeSucursal);

                NuevoEvent();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
            finally
            {
                wait.Hide();
            }
        }

        private void gvEmpresas_DoubleClick(object sender, EventArgs e)
        {
            CargarSucursal();
        }

        private void gvEmpresas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            CargarSucursal();
        }

        private void gvCuentas_CellValueChanged(object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                servicioAdministracionSucursales.ActualizarAtributoNoListado(
                    Convert.ToString(gvCuentas.GetRowCellValue(e.RowHandle, "Cuenta")),
                    Convert.ToString(gvCuentas.GetRowCellValue(e.RowHandle, "CuentaContable")), mSucursal.IdSucursal);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion
    }
}