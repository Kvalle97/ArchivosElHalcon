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

namespace CSPresentacion.Sistema.Administracion.Bodega
{
    public partial class FrmAdministracionDeBodegas : FrmBase
    {
        private readonly ServicioBodegas servicioBodegas = new ServicioBodegas();
        private ModeloBodega modeloBodega = new ModeloBodega();

        private static FrmAdministracionDeBodegas _childInstance;

        public FrmAdministracionDeBodegas()
        {
            InitializeComponent();
        }

        #region Metodos

        public static FrmAdministracionDeBodegas Instance()
        {
            if (_childInstance is null || _childInstance.IsDisposed)
            {
                _childInstance = new FrmAdministracionDeBodegas();
            }

            _childInstance.MostrarBotones(true, Opciones.Nuevo, Opciones.Guardar);
            return _childInstance;
        }

        private void CargarBodega(string bodega)
        {
            dxErrorProvider.ClearErrors();

            WaitDialogForm wait = new WaitDialogForm("Por favor espere", "Cargando bodega");

            wait.Show();

            try
            {
                modeloBodega = UIHelper.ObtenerItem<ModeloBodega>(servicioBodegas.CargarInfoBodega(bodega));

                txtIdBodega.Text = modeloBodega.IdBodega;
                txtDescripcion.Text = modeloBodega.Descripcion;
                memoComentarios.Text = modeloBodega.Comentarios;
                txtCosto.Text = modeloBodega.CuentaCosto;
                lueEmpresa.EditValue = modeloBodega.IdSucursal;

                txtIdBodega.ReadOnly = !string.IsNullOrWhiteSpace(modeloBodega.IdBodega);


                if (string.IsNullOrWhiteSpace(modeloBodega.IdBodega))
                {
                    ckComboTipoDeSucursal.EditValue = null;
                }
                else
                {
                    ckComboTipoDeSucursal.EditValue = UIHelper.ConvertirDataTableAListaSimple<int>(
                        servicioBodegas.ObtenerTipoPorBodega(modeloBodega.IdBodega), "IdTipoBodega");
                }

                ckComboTipoDeSucursal.RefreshEditValue();
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
            finally
            {
                wait.Close();
            }
        }

        private void ValidarSeleccionBodegas()
        {
            if (gvBodegas.IsValidRowHandle(gvBodegas.FocusedRowHandle))
            {
                CargarBodega(Convert.ToString(gvBodegas.GetRowCellValue(gvBodegas.FocusedRowHandle, "IdBodega")));
            }
        }

        private void ValidarInterfaz()
        {
            txtIdBodega.Properties.CharacterCasing = CharacterCasing.Upper;
            txtIdBodega.Properties.MaxLength = 2;

            txtDescripcion.Properties.CharacterCasing = CharacterCasing.Upper;
            txtDescripcion.Properties.MaxLength = 25;

            memoComentarios.Properties.CharacterCasing = CharacterCasing.Upper;
            memoComentarios.Properties.MaxLength = 50;

            txtCosto.Properties.MaxLength = 15;
        }

        #endregion


        #region SobreCargas

        protected override void NuevoEvent()
        {
            dxErrorProvider.ClearErrors();

            CargarBodega(string.Empty);
        }

        protected override void GuardarEvent()
        {
            dxErrorProvider.ClearErrors();

            if (string.IsNullOrWhiteSpace(txtIdBodega.Text))
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtIdBodega, "El campo id es necesario");
                return;
            }

            if (txtIdBodega.Text.Length != 2)
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtIdBodega, "Debe proporcionar al menos dos caracteres");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtDescripcion, "Debe proporcionar una descripción");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCosto.Text))
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtCosto, "El campo costo es necesario");
                return;
            }

            List<object> lstOb = ckComboTipoDeSucursal.EditValue as List<object>;

            if (lstOb is null)
            {
                UIHelper.AlertarDeError(dxErrorProvider, ckComboTipoDeSucursal, "Por favor seleccione un tipo");
                return;
            }

            if (lstOb.Count != 1)
            {
                UIHelper.AlertarDeError(dxErrorProvider, ckComboTipoDeSucursal,
                    "Por motivos de gerencia debe seleccionar solo un tipo");
                return;
            }

            try
            {
                if (!txtIdBodega.ReadOnly)
                {
                    if (servicioBodegas.VerificarSiYaExiste(txtIdBodega.Text))
                    {
                        UIHelper.AlertarDeError(dxErrorProvider, txtIdBodega,
                            "El código proporcionado ya se está usando");
                        return;
                    }
                }

                DataTable dtTiposPermitidos = new DataTable();

                dtTiposPermitidos.Columns.Add("IdTipo", typeof(int));


                foreach (object o in lstOb)
                {
                    var nRow = dtTiposPermitidos.NewRow();

                    nRow["IdTipo"] = Convert.ToInt32(o);

                    dtTiposPermitidos.Rows.Add(nRow);
                }

                modeloBodega.IdBodega = txtIdBodega.Text;
                modeloBodega.Descripcion = txtDescripcion.Text;
                modeloBodega.Comentarios = memoComentarios.Text;
                modeloBodega.CuentaCosto = txtCosto.Text;
                modeloBodega.IdSucursal = Convert.ToInt32(lueEmpresa.EditValue);

                servicioBodegas.GuardarBodega(modeloBodega, dtTiposPermitidos, Datos_Globales.IdLogin);

                XtraMessageBox.Show("Guardado");

                NuevoEvent();

                servicioBodegas.MostrarBodegas(gcBodegas, gvBodegas);
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        #endregion

        #region Eventos

        private void FrmAdministracionDeBodegas_Shown(object sender, EventArgs e)
        {
            try
            {
                ValidarInterfaz();
                servicioBodegas.MostrarBodegas(gcBodegas, gvBodegas);
                servicioBodegas.CargarSucursales(lueEmpresa, false);
                servicioBodegas.MostrarTipoBodega(ckComboTipoDeSucursal);

                NuevoEvent();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }


        private void gvBodegas_DoubleClick(object sender, EventArgs e)
        {
            ValidarSeleccionBodegas();
        }

        private void gvBodegas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            ValidarSeleccionBodegas();
        }

        #endregion
    }
}