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
using CSPresentacion.Sistema.General.Buscador;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Frm Tipo Mov y Tipo Doc
    /// </summary>
    public partial class FrmDocumentos : XtraForm
    {
        // ReSharper disable once InconsistentNaming
        private static FrmDocumentos childInstance;
        private readonly ServicioDocumentos servicioDocumentos = new ServicioDocumentos();

        private TipoMovimiento tipoMovimiento;
        private TipoDocumento tipoDocumento;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmDocumentos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmDocumentos Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmDocumentos();
            }

            childInstance.BringToFront();

            return childInstance;
        }

        #region Metodos

        private void LimpiarTipoMov()
        {
            dxErrorProvider.ClearErrors();

            tipoMovimiento = new TipoMovimiento();

            tipoMovimiento.IdTipoMov = -1;

            CargarTipoMovimiento();
        }

        private void CargarTipoMovimiento()
        {
            txtIdTipoMov.Text = tipoMovimiento.IdTipoMov.ToString("D6");
            txtTipoMov.Text = tipoMovimiento.TipoMov;
            seAfectaciones.Value = tipoMovimiento.Afectaciones;
            sePresupuesto.Value = tipoMovimiento.Afectaciones;
        }

        private void LimpiarTipoDoc()
        {
            dxErrorProvider.ClearErrors();

            tipoDocumento = new TipoDocumento();

            CargarTipoDocumento();
        }

        private void CargarTipoDocumento()
        {
            glueTipoMovimiento.EditValue = tipoDocumento.IdTipoMov;
            seIdTipoDoc.Value = tipoDocumento.IdTipoDoc;
            seIdTipoDoc.Enabled = tipoDocumento.IdTipoDoc == 0;
            glueTipoMovimiento.Enabled = tipoDocumento.IdTipoDoc == 0;
            seNoInical.Value = tipoDocumento.NoInicial;
            txtTipoDocumento.Text = tipoDocumento.TipoDoc;
            seExistencias.Value = tipoDocumento.Existencias;
            seCoberturaMinima.Value = tipoDocumento.Cobertura_Mínima;
            ckbContabiliza.Checked = tipoDocumento.Contabiliza;
            ckbActivo.Checked = tipoDocumento.Activo;
            lueEmpresa.EditValue = tipoDocumento.IdEmpresa;
            txtImpresora.Text = tipoDocumento.Impresora;
            meComentario.Text = tipoDocumento.Comentario;
        }

        private void CargarTodo()
        {
            try
            {
                servicioDocumentos.CargarTipoMovs(gcTipoMov, gvTipoMov);
                servicioDocumentos.CargarTipoDocs(gcTipoDoc, gvTipoDoc);
                servicioDocumentos.CargarTipoMovs(glueTipoMovimiento);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion

        #region Eventos

        private void FrmDocumentos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarTodo();

                servicioDocumentos.CargarSucursales(lueEmpresa, false);

                LimpiarTipoMov();
                LimpiarTipoDoc();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnBuscarBrechas_Click(object sender, EventArgs e)
        {
            FrmBuscador frmBuscador = new FrmBuscador(FrmBuscador.TipoBuscador.BrechasEnTipoDoc);

            if (frmBuscador.ShowDialog() == DialogResult.OK)
            {
                if (frmBuscador.ValorDeLaCelda is DBNull)
                {
                    UIHelper.AlertarDeError("Seleccione los numeros y no celdas vacias");
                }
                else
                {
                    int idATomar = Convert.ToInt32(frmBuscador.ValorDeLaCelda);

                    seIdTipoDoc.Value = idATomar;
                }
            }
        }

        private void btnNuevoMov_Click(object sender, EventArgs e)
        {
            LimpiarTipoMov();
        }

        private void btnNuevoDoc_Click(object sender, EventArgs e)
        {
            LimpiarTipoDoc();
        }

        private void btnGuardarDoc_Click(object sender, EventArgs e)
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Guardando");

            wait.Show();

            try
            {
                dxErrorProvider.ClearErrors();

                if (string.IsNullOrWhiteSpace(txtTipoDocumento.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtTipoDocumento,
                        "Debe proporcionar un nombre para el tipo documento valido");
                    return;
                }

                if (seIdTipoDoc.Enabled)
                {
                    if (servicioDocumentos.ElIdDelDocumentoYaEstaSiendoUsado(Convert.ToInt32(seIdTipoDoc.Value),
                        Convert.ToInt32(glueTipoMovimiento.EditValue)))
                    {
                        UIHelper.AlertarDeError(dxErrorProvider, seIdTipoDoc,
                            "El id ya esta siendo usado en otro tipo de documento");
                        return;
                    }
                }

                tipoDocumento.IdTipoMov = Convert.ToInt32(glueTipoMovimiento.EditValue);
                tipoDocumento.IdTipoDoc = decimal.ToInt32(seIdTipoDoc.Value);
                tipoDocumento.NoInicial = decimal.ToInt32(seNoInical.Value);
                tipoDocumento.TipoDoc = txtTipoDocumento.Text;
                tipoDocumento.Existencias = decimal.ToInt32(seExistencias.Value);
                tipoDocumento.Cobertura_Mínima = decimal.ToInt32(seCoberturaMinima.Value);
                tipoDocumento.Contabiliza = ckbContabiliza.Checked;
                tipoDocumento.Activo = ckbActivo.Checked;
                tipoDocumento.IdEmpresa = Convert.ToInt32(lueEmpresa.EditValue);
                tipoDocumento.Impresora = txtImpresora.Text;
                tipoDocumento.Comentario = meComentario.Text;

                servicioDocumentos.GuardarTipoDocumento(tipoDocumento, Datos_Globales.Usuario, Datos_Globales.IdLogin);

                LimpiarTipoDoc();

                CargarTodo();

                wait.Close();

                XtraMessageBox.Show("Se ha guardado el tipo de documento");
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
            finally
            {
                if (!wait.IsDisposed) wait.Close();
            }
        }

        private void btnGuardarMov_Click(object sender, EventArgs e)
        {
            WaitDialogForm waitDialog = new WaitDialogForm("Por favor espere...", "Guardando");

            waitDialog.Show();

            try
            {
                dxErrorProvider.ClearErrors();

                if (string.IsNullOrWhiteSpace(txtTipoMov.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtTipoMov, "Escriba un tipo mov valido.");
                    return;
                }

                tipoMovimiento.TipoMov = txtTipoMov.Text;
                tipoMovimiento.Afectaciones = decimal.ToInt32(seAfectaciones.Value);
                tipoMovimiento.Presupuesto = (double) sePresupuesto.Value;

                servicioDocumentos.GuardarTipoMovimiento(tipoMovimiento, Datos_Globales.Usuario);

                LimpiarTipoMov();

                CargarTodo();

                waitDialog.Close();

                XtraMessageBox.Show("Se ha guardado el tipo de movimento");
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
            finally
            {
                if (!waitDialog.IsDisposed) waitDialog.Close();
            }
        }

        private void gvTipoDoc_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvTipoDoc.FocusedRowHandle < 0) return;

                tipoDocumento = UIHelper.ObtenerItem<TipoDocumento>(
                    servicioDocumentos.ObtenerTipoDoc(Convert.ToInt32(
                        gvTipoDoc.GetFocusedDataRow()["IdTipoMov"]), Convert.ToInt32(
                        gvTipoDoc.GetFocusedDataRow()["IdTipoDoc"])));

                CargarTipoDocumento();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvTipoDoc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (gvTipoDoc.FocusedRowHandle < 0) return;
                if (e.KeyCode != Keys.Enter) return;

                tipoDocumento = UIHelper.ObtenerItem<TipoDocumento>(
                    servicioDocumentos.ObtenerTipoDoc(Convert.ToInt32(
                        gvTipoDoc.GetFocusedDataRow()["IdTipoMov"]), Convert.ToInt32(
                        gvTipoDoc.GetFocusedDataRow()["IdTipoDoc"])));

                CargarTipoDocumento();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvTipoMov_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvTipoMov.FocusedRowHandle < 0) return;

                tipoMovimiento = UIHelper.ObtenerItem<TipoMovimiento>(
                    servicioDocumentos.ObtenerTipoMov(Convert.ToInt32(
                        gvTipoMov.GetFocusedDataRow()["IdTipoMov"])));

                CargarTipoMovimiento();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvTipoMov_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (gvTipoMov.FocusedRowHandle < 0) return;
                if (e.KeyCode != Keys.Enter) return;

                tipoMovimiento = UIHelper.ObtenerItem<TipoMovimiento>(
                    servicioDocumentos.ObtenerTipoMov(Convert.ToInt32(
                        gvTipoMov.GetFocusedDataRow()["IdTipoMov"])));

                CargarTipoMovimiento();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion
    }
}