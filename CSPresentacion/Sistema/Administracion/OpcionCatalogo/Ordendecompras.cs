using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using CSPresentacion.Sistema.General;
using CSNegocios.Modelos;
using CSPresentacion.Sistema.General.Buscador;
using CSNegocios;
using System.Globalization;
using CSPresentacion.Sistema.Administracion.OpcionCatalogo.Reporte;
using DevExpress.DashboardCommon;
using DevExpress.XtraReports.UI;

namespace CSPresentacion.Sistema.Administracion.OpcionCatalogo
{
    public partial class Ordendecompra : FrmBase
    {

        private ModeloOrdendeCompra ordenDeCompra = new ModeloOrdendeCompra();
        ServicioOrdenesDeCompra servicioOrdenesDeCompras = new ServicioOrdenesDeCompra();
        private static Ordendecompra _childInstance = null;
        private string codigo;
        private string codigod;

        public Ordendecompra()
        {
            InitializeComponent();
        }



        public static Ordendecompra Instance()
        {
            if (_childInstance == null || _childInstance.IsDisposed)
            {
                _childInstance = new Ordendecompra();


                _childInstance.MostrarBotones(true, Opciones.Nuevo, Opciones.Guardar, Opciones.Eliminar,
                                                       Opciones.Buscar, Opciones.Imprimir, Opciones.Aplicar, Opciones.RevertirAplicar);


            }
            _childInstance.BringToFront();

            return _childInstance;
        }





        private void ActualizarProductosMostrados()
        {
            try
            {
                servicioOrdenesDeCompras.ObtnerProductosDeLaOrden(gcProductos, gvProductos, Datos_Globales.IdLogin, ckbDolarizarCompras.Checked);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }


        private void Actualizardatosdelaorden()
        {
            try
            {
                DataTable dt =
                    servicioOrdenesDeCompras.ObtenerDatosDeLaOrden(Datos_Globales.IdLogin);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ordenDeCompra.DescuentoTotal = ordenDeCompra.DescuentoTotal = ordenDeCompra.DescuentoTotal =
                       seDescue.Value = Convert.ToDecimal(dt.Rows[0]["Descuento"]);
                    ordenDeCompra.SubTotal = ordenDeCompra.SubTotal = ordenDeCompra.SubTotal =
                        seSubTotal.Value = Convert.ToDecimal(dt.Rows[0]["SubTotal"]);
                    ordenDeCompra.Iva = seIva.Value =
                        !ckbCompraExoneradoIva.Checked ? Convert.ToDecimal(dt.Rows[0]["IVA"]) : 0;
                    ordenDeCompra.Totalprecioproducto = seTotal.Value = seSubTotal.Value + seIva.Value;
                }
            }
            catch (Exception e)

            {
                UIHelper.AlertarDeError("Ocurrio un error inesperado, contacte al administrador.");
                UIHelper.MostrarError(e);
            }
        }

        private void Limpiar()
        {

            try
            {
                ordenDeCompra = new ModeloOrdendeCompra();

                servicioOrdenesDeCompras.LimpiarOrdenDeCompraTemporal(Datos_Globales.IdLogin, null);
                txtSucursalOrigen.Text = ordenDeCompra.SucursalOrigen;
                txtNoDoc.Text = servicioOrdenesDeCompras.Obtenerultimoregistro(ordenDeCompra.IdOrden);
                txtProveedor.Text = "";
                txtcontacto.Text = "";
                meComentarios.Text = "";
                dpFecha.DateTime = ordenDeCompra.FechaDelDocumento;
                seSubTotal.Value = 0;
                seIva.Value = 0;
                seTotal.Value = 0;
                dxErrorProvider1.ClearErrors();
                ActualizarProductosMostrados();
                Limpiarcamposcodigo();

            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }

        }

        private void Limpiarcamposcodigo()
        {
            txtcodigop.Text = string.Empty;
            txtdescripcion.Text = "";
            seCantidad.Value = 0;
            seCosto.Value = 0;
            seDesc.Value = 0;

        }

        private void ActivarEventos()
        {

            ActivarBoton(true, Opciones.Guardar, Opciones.Aplicar);
            dpFecha.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            btnProveedores.Enabled = true;
            ckbCompraExoneradoIva.Enabled = true;
            ckbDolarizarCompras.Enabled = true;

        }


        private void CambiarCultura(bool dolar) /*es util para cambiar signo de cordoba a dolares*/
        {
            string cultura = dolar ? "en-US" : "es-NI";

            seSubTotal.Properties.Mask.Culture = new CultureInfo(cultura);
            seSubTotal.Properties.Mask.UseMaskAsDisplayFormat = true;

            seIva.Properties.Mask.Culture = new CultureInfo(cultura);
            seIva.Properties.Mask.UseMaskAsDisplayFormat = true;

            seCosto.Properties.Mask.Culture = new CultureInfo(cultura);
            seCosto.Properties.Mask.UseMaskAsDisplayFormat = true;

            seTotal.Properties.Mask.Culture = new CultureInfo(cultura);
            seTotal.Properties.Mask.UseMaskAsDisplayFormat = true;

            seCosto.Properties.Mask.Culture = new CultureInfo(cultura);
            seCosto.Properties.Mask.UseMaskAsDisplayFormat = true;

            seDescue.Properties.Mask.Culture = new CultureInfo(cultura);
            seDescue.Properties.Mask.UseMaskAsDisplayFormat = true;

        }


        private void GuardarOrdenDeCompra()
        {
            int idorden = 0;

            if (ordenDeCompra.IdOrden != 0)
            {

                if (XtraMessageBox.Show(
                  "¿ Desea  guardar la orden de compra ?", "",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
            }


            WaitDialogForm Wait = new WaitDialogForm("Por favor espere...", "Guardando  orden de compra");

            Wait.Show();

            try
            {


                List<Error> lstErrores = new List<Error>();

                if (string.IsNullOrWhiteSpace(txtProveedor.Text))
                    lstErrores.Add(new Error("Debe agregar un proveedor a la orden de compra", txtProveedor));

                if (string.IsNullOrWhiteSpace(meComentarios.Text))
                    lstErrores.Add(new Error("Debe agregar un comentario valido a la orden de compra", meComentarios));


                if (lstErrores.Count > 0)
                {
                    UIHelper.AlertarDeError(dxErrorProvider1, lstErrores);
                    return;
                }


                ordenDeCompra.Sucursal = txtSucursalOrigen.Text;
                ordenDeCompra.ProveedorDescripcion = txtProveedor.Text;
                ordenDeCompra.FechaDelDocumento = dpFecha.DateTime;
                ordenDeCompra.Comentario = meComentarios.Text;
                ordenDeCompra.ExoneradoDeIVa = ckbCompraExoneradoIva.Checked;
                ordenDeCompra.DolarizarOrdenDeCompra = ckbDolarizarCompras.Checked;
                ordenDeCompra.SubTotal = seSubTotal.Value;
                ordenDeCompra.Iva = !ckbCompraExoneradoIva.Checked ? seIva.Value : 0;
                ordenDeCompra.DescuentoTotal = seDescue.Value;
                ordenDeCompra.CostoTotalOrden = seTotal.Value = seSubTotal.Value + seIva.Value;
                ordenDeCompra.Contacto = txtcontacto.Text;


                servicioOrdenesDeCompras.GuardarOrdendeCompra(ordenDeCompra, Datos_Globales.IdLogin,
                   Datos_Globales.Usuario);

                ModeloOrdendeCompra oc;

                oc = idorden == 0
                    ? servicioOrdenesDeCompras.ObtenerUltimaOrdendeCompra()
                    : servicioOrdenesDeCompras.ObtenerUltimaOrdendeCompra();

                Limpiar();

                CargarOrdenDeCompra(oc.IdOrden);
                ImprimirEvent();


            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
            finally
            {
                Wait.Close();
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtdescripcion.Text.Length > 0)  /*reparar no valida*/
                {


                    servicioOrdenesDeCompras.AgregarProdutctoATemporal(Convert.ToString(txtcodigop.EditValue), seCantidad.Value, seCosto.Value, seDesc.Value,
                        Convert.ToString(txtdescripcion.EditValue), Datos_Globales.IdLogin);
                    ActualizarProductosMostrados();
                    Actualizardatosdelaorden();
                    Limpiarcamposcodigo();


                }
                else
                {
                    UIHelper.AlertarDeError("Ingrese una Descripción Del Producto");
                    txtdescripcion.Focus();
                }
            }
            catch (Exception ex)
            {

                UIHelper.MostrarError(ex);

            }
            txtdescripcion.Focus();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

            servicioOrdenesDeCompras.LimpiarOrdenDeCompraTemporal(Datos_Globales.IdLogin, txtcodigop.Text);
            ActualizarProductosMostrados();
            Actualizardatosdelaorden();
            Limpiarcamposcodigo();

        }

        private void btnProveedores_Click_1(object sender, EventArgs e)
        {
            try
            {
                FrmBuscador frmBuscador = new FrmBuscador(FrmBuscador.TipoBuscador.Proveedor);

                frmBuscador.CaptionBuscadorproveedor = "Proveedores Informatica";

                if (frmBuscador.ShowDialog() == DialogResult.OK)
                {
                    ordenDeCompra.ProveedorCodigo = Convert.ToInt32(frmBuscador.DataRow["Codigo"]);
                    ordenDeCompra.ProveedorDescripcion = Convert.ToString(frmBuscador.DataRow["Descripcion"]);
                    ordenDeCompra.Contacto = Convert.ToString(frmBuscador.DataRow["Contacto"]);
                    ordenDeCompra.NoContacto = Convert.ToString(frmBuscador.DataRow["NoContacto"]);
                    ordenDeCompra.NoRuc = Convert.ToString(frmBuscador.DataRow["NoRuc"]);


                    Modeloproveedorinformatica p = new ServicioProveedorinformatica().ObtenerProveedorinf(ordenDeCompra.ProveedorCodigo);

                    ordenDeCompra.ProveedorCodigo = p.IdProveedor;
                    txtProveedor.Text = ordenDeCompra.Proveedorconcodigo;
                    ordenDeCompra.NoContacto = p.NoContacto;
                    txtcontacto.Text = ordenDeCompra.Contactoconcell;


                    //XtraMessageBox.Show(frmBuscador.DataRow["Descripcion"].ToString());
                }
                txtdescripcion.Focus();
                dxErrorProvider1.ClearErrors();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }



        protected override void NuevoEvent()
        {
            ActivarEventos();
            Limpiar();
        }

        protected override void GuardarEvent()
        {
            GuardarOrdenDeCompra();
        }


        protected override void BuscarEvent()
        {
            try
            {
                FrmBuscador frmBuscador = new FrmBuscador(FrmBuscador.TipoBuscador.OrdenesDeCompra);

                if (frmBuscador.ShowDialog() == DialogResult.OK)
                    CargarOrdenDeCompra(
                        Convert.ToInt32(frmBuscador.DataRow["No_Orden"]));

            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }


        private void Ordendecompra_Load(object sender, EventArgs e)
        {
            ActivarBoton(false, Opciones.Imprimir);
            Limpiar();

        }

        private void CargarOrdenDeCompra(int IdOrden)
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Cargando orden de compra");

            try
            {
                Limpiar();


                servicioOrdenesDeCompras.CargarATemporalOrdenesDeCompra(IdOrden, Datos_Globales.IdLogin);

                ordenDeCompra = servicioOrdenesDeCompras.ObtenerOrdenDeCompra(IdOrden);


                txtNoDoc.Text = Convert.ToString(ordenDeCompra.IdOrden);
                txtProveedor.Text = ordenDeCompra.ProveedorDescripcion;
                txtSucursalOrigen.Text = ordenDeCompra.Sucursal;
                dpFecha.DateTime = ordenDeCompra.FechaDelDocumento;
                meComentarios.Text = ordenDeCompra.Comentario;
                ckbCompraExoneradoIva.Checked = ordenDeCompra.ExoneradoDeIVa;
                ckbDolarizarCompras.Checked = ordenDeCompra.DolarizarOrdenDeCompra;
                txtcontacto.Text = ordenDeCompra.Contacto;



                ActivarBoton(true, Opciones.Imprimir);

                if (!ordenDeCompra.Cerrado)
                {
                    ActivarBoton(true, Opciones.Guardar, Opciones.Aplicar);
                    btnAgregar.Enabled = true;
                    btnQuitar.Enabled = true;
                    btnProveedores.Enabled = true;
                    ckbCompraExoneradoIva.Enabled = true;
                    ckbDolarizarCompras.Enabled = true;
                    ckbDolarizarCompras.Enabled = true;
                }
                else
                {
                    ActivarBoton(false, Opciones.Guardar, Opciones.Aplicar);
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnProveedores.Enabled = false;
                    ckbCompraExoneradoIva.Enabled = false;
                    ckbDolarizarCompras.Enabled = false;
                    ckbDolarizarCompras.Enabled = false;
                }



                ActualizarProductosMostrados();

                Actualizardatosdelaorden();

            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
            finally
            {
                wait.Close();
            }
        }

        protected override void ImprimirEvent()
        {
            //if (ordenDeCompra.IdOrden <= 0)
            //{
            //    UIHelper.AlertarDeError("Primero seleccione una orden de compra");
            //    return;
            //}


            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Generando Vista Previa ♣♠");

            try
            {

                rptOrdenDeCompracs ReporteOrdenDeCompra =
                           new rptOrdenDeCompracs(ordenDeCompra.DolarizarOrdenDeCompra);

                ReporteOrdenDeCompra.DataSource = servicioOrdenesDeCompras.ReporteOrdenDeCompra(ordenDeCompra.IdOrden);
                ReporteOrdenDeCompra.DataMember = "spReporteOrdenDeCompraInformatica";


                ReportPrintTool printTool = new ReportPrintTool(ReporteOrdenDeCompra);
                printTool.PreviewForm.MdiParent = this.MdiParent;
                printTool.PreviewForm.Text = "Reporte Proyecto";
                printTool.ShowPreview();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
            finally
            {
                wait.Close();
            }

        }

        protected override void EliminarEvent()
        {
            try
            {
                if (ordenDeCompra.IdOrden > 0)
                {

                    if (XtraMessageBox.Show(
                        "¿ Está seguro que desea eliminar la Orden \"" + ordenDeCompra.IdOrden + "\" ?",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2
                    ) == DialogResult.Yes)

                    {
                        WaitDialogForm wait = new WaitDialogForm("Eliminando LA Orden", "Por favor espere...");

                        if (servicioOrdenesDeCompras.EliminarOrden(Convert.ToInt32(txtNoDoc.Text)) > 0) ;
                        XtraMessageBox.Show("Se ha Eliminando La Orden");
                        Limpiar();
                        ActivarEventos();
                        wait.Close();
                    }
                    else
                    {

                        UIHelper.AlertarDeError("Ocurrio un error inesperado, contacte al administrador");
                    }
                }

                else
                {
                    UIHelper.AlertarDeError("Primero seleccione una Orden");
                }

            }
            catch (Exception ex)
            {

                UIHelper.MostrarError(ex);
            }
        }

        protected override void AplicarEvent()
        {
            if (ordenDeCompra.IdOrden != 0)
            {
                WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Aplicando orden de compra.");

                wait.Show();


                try
                {
                    servicioOrdenesDeCompras.AplicarOrdenDeCompra(ordenDeCompra.IdOrden);

                    Limpiar();

                    wait.Close();

                    XtraMessageBox.Show("Orden de compra aplicada");
                }
                catch (Exception ex)
                {
                    UIHelper.MostrarError(ex);
                }
                finally
                {
                    if (!wait.IsDisposed) wait.Close();
                }
            }
            else
            {
                UIHelper.AlertarDeError("Seleccione una Orden de Compra ");
            }
        }

        protected override void RevertirAplicarEvent()
        {
            if (ordenDeCompra.IdOrden != 0)
            {
                servicioOrdenesDeCompras.RevertirAplicar(ordenDeCompra.IdOrden);



                CargarOrdenDeCompra(ordenDeCompra.IdOrden);
            }
            else
            {
                UIHelper.AlertarDeError("Seleccione una Orden de Compra ");
            }
        }


        private void ckbCompraExoneradoIva_CheckedChanged(object sender, EventArgs e)
        {
            Actualizardatosdelaorden();

        }

        private void gcProductos_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gcProductos.Visible = false;
                    txtcodigop.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    DataRow dr = gvProductos.GetDataRow(gvProductos.FocusedRowHandle);

                    if (dr != null)
                    {
                        txtcodigop.Text = Convert.ToString(dr["Código"]);
                        txtdescripcion.Text = Convert.ToString(dr["Descripción"]);
                        seCantidad.Value = Convert.ToDecimal(dr["Cantidad"]);
                        seCosto.Value = Convert.ToDecimal(dr["SubTotal"]);


                    }
                    gcProductos.Visible = true;

                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }

        }

        private void ckbDolarizarCompras_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CambiarCultura(ckbDolarizarCompras.Checked);

                ActualizarProductosMostrados();


            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void Ordendecompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (gvProductos.RowCount > 0)
                {
                    if (ordenDeCompra.IdOrden != 0)
                    {
                        if (!ordenDeCompra.Cerrado)
                        {
                            if (XtraMessageBox.Show("Si sale ahora no se aplicaran los cambios ¿ Está seguro ?", "",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                e.Cancel = true;
                            else
                                servicioOrdenesDeCompras.LimpiarOrdenDeCompraTemporal(Datos_Globales.IdLogin, codigo);
                        }
                    }
                    else if (XtraMessageBox.Show("Si sale ahora no se guardaran los cambios ¿ Está seguro ?", "",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        servicioOrdenesDeCompras.LimpiarOrdenDeCompraTemporal(Datos_Globales.IdLogin, codigo);
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }



        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {

            try
            {
                FrmBuscador frmBuscador = new FrmBuscador(FrmBuscador.TipoBuscador.OrdenesDeCompra);

                if (frmBuscador.ShowDialog() == DialogResult.OK)
                    CargarOrdenDeCompra(
                        Convert.ToInt32(frmBuscador.DataRow["No_Orden"]));

            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void gcProductos_Click(object sender, EventArgs e)
        {


            try
            {

                DataRow dr = gvProductos.GetDataRow(gvProductos.FocusedRowHandle);


                if (dr != null)  //me ayudo para que el click null en el gvproducto 
                {
                    txtcodigop.Text = Convert.ToString(dr["Código"]);
                    txtdescripcion.Text = Convert.ToString(dr["Descripción"]);
                    seCantidad.Value = Convert.ToDecimal(dr["Cantidad"]);
                    seCosto.Value = Convert.ToDecimal(dr["SubTotal"]);
                    seDesc.Value = Convert.ToDecimal(dr["%"]);


                }

            }

            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void txtdescripcion_KeyUp(object sender, KeyEventArgs e)


        {
            if (e.KeyCode != Keys.Enter) return;
            seCantidad.Focus();

        }

        private void seCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            seCosto.Focus();
        }

        private void seCosto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnAgregar.Focus();

        }
    }
}