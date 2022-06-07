using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace CSPresentacion.Sistema.Opcion_Catalogo
{
    public partial class FrmProveedoresInformatica : FrmBase

    {

        private static FrmProveedoresInformatica _childInstance = null;

        Modeloproveedorinformatica proveedor = new Modeloproveedorinformatica();
        ServicioProveedorinformatica servicioProveedor = new ServicioProveedorinformatica();



        public FrmProveedoresInformatica()
        {
            InitializeComponent();
        }


        public static FrmProveedoresInformatica Instance()

        {
            if (_childInstance == null || _childInstance.IsDisposed)
            {
                _childInstance = new FrmProveedoresInformatica();


                _childInstance.MostrarBotones(true, Opciones.Nuevo, Opciones.Guardar, Opciones.Eliminar);


            }
            _childInstance.BringToFront();

            return _childInstance;
        }


        private void Cargarproveedores()
        {

            try
            {
                if (!gvProveedores.IsValidRowHandle(gvProveedores.FocusedRowHandle)) return;

                Cargarproveedor(
                     Convert.ToInt32(
                         gvProveedores.GetRowCellValue(gvProveedores.FocusedRowHandle, "IdProveedor")));
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        private void Cargarproveedor(int codigo)

        {

            servicioProveedor.Obtenercontactosdatable(codigo, gccontacto, gvcontacto);
            proveedor = servicioProveedor.Obtenerproveedorinformatica(codigo);

            txtCodigo.EditValue = codigo;
            txtproveedor.Text = proveedor.Descripcion;
            txtdireccion.Text = proveedor.Dirección;
            txtnoruc.Text = proveedor.NoRuc;
            txtsucursal.Text = proveedor.Sucursal;
            txttelefono.EditValue = proveedor.Teléfono;
            txtcorreo.Text = proveedor.Correo;
        }

        private void Cargarcontacto(int codigo)
        {
            servicioProveedor.Obtenercontactosdatable(codigo, gccontacto, gvcontacto);
        }


        private void Limpiar()
        {
            try
            {
                dxErrorProvider.ClearErrors();

                txtCodigo.Text = servicioProveedor.Obtenerultimoregistro(proveedor.IdProveedor);
                txtCodigo.ReadOnly = true;
                txtproveedor.Text = "";
                txtdireccion.Text = "";
                txtnoruc.Text = "";
                txtsucursal.Text = "";
                txtcorreo.Text = "";
                txttelefono.Text = "";
                txtcontacto.Text = "";
                txtnocontacto.Text = "";
                txtcorreocontact.Text = "";
                txtCargo.Text = "";
                ActivarBoton(true, Opciones.Guardar);
            }

            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void LimpiarContacto()
        {
            txtidcontacto.Text = "";
            txtcontacto.Text = "";
            txtnocontacto.Text = "";
            txtcorreocontact.Text = "";
            txtCargo.Text = "";
        }


        protected override void NuevoEvent()
        {
            txtproveedor.Focus();
            Limpiar();
            txtCodigo.ReadOnly = true;
            gvcontacto.Columns.Clear();
        }

        protected override void GuardarEvent()
        {

            if (string.IsNullOrWhiteSpace(txtproveedor.Text))
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtproveedor, "Debe proporcionar un proveedor");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtdireccion.Text))
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtdireccion, "Debe proporcionar una dirección");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtnoruc.Text))
            {
                UIHelper.AlertarDeError(dxErrorProvider, txtnoruc, "Debe proporcionar un número Ruc");
                return;
            }


            WaitDialogForm wait = new WaitDialogForm("Guardando proveedor", "Por favor espere...");

            wait.Show();

            try
            {
                proveedor.Descripcion = txtproveedor.Text;
                proveedor.Dirección = txtdireccion.Text;
                proveedor.NoRuc = txtnoruc.Text;
                proveedor.Sucursal = txtsucursal.Text;
                proveedor.Correo = txtcorreo.Text;
                proveedor.Teléfono = txttelefono.Text;
                proveedor.Contacto = txtcontacto.Text;
                proveedor.NoContacto = txtnocontacto.Text;
                proveedor.Correo_Contacto = txtcorreocontact.Text;
                proveedor.Cargo = txtCargo.Text;



                servicioProveedor.GuardarProveedor(proveedor, Datos_Globales.IdLogin);
                servicioProveedor.ObtenerProveedores(gcProveedores, gvProveedores);
                Limpiar();
            }
            catch
            {
                XtraMessageBox.Show("Se ha guardardo el proveedor");
                return;
            }

            finally
            {
                wait.Close();
            }
            txtCodigo.Focus();

        }


        protected override void EliminarEvent()
        {
            try
            {
                if (txtproveedor.Text.Length > 0)
                {
                    txtCodigo.Focus();

                    if (XtraMessageBox.Show(
                        "¿ Está seguro que desea eliminar al proveedor \"" + proveedor.Descripcion + "\"  y todos sus contactos ?",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2
                    ) == DialogResult.Yes)

                    {
                        WaitDialogForm wait = new WaitDialogForm("Eliminando al proveedor", "Por favor espere...");

                        if (servicioProveedor.EliminarProveedor(Convert.ToInt32(txtCodigo.Text)) > 0) ;
                        XtraMessageBox.Show("Se ha Eliminando al proveedor.");
                        Limpiar();
                        servicioProveedor.ObtenerProveedores(gcProveedores, gvProveedores);
                        gvcontacto.Columns.Clear();
                        wait.Close();
                    }
                    else
                    {

                        UIHelper.AlertarDeError("Ocurrio un error inesperado, contacte al administrador");
                    }
                }

                else
                {
                    UIHelper.AlertarDeError("Primero seleccione un proveedor");
                }

            }
            catch (Exception ex)
            {

                UIHelper.MostrarError(ex);
            }

        }

        private void ObtenerProveedores()
        {
            try
            {
                servicioProveedor.ObtenerProveedores(gcProveedores, gvProveedores);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void FrmProveedoresInformatica_Shown(object sender, EventArgs e)
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere", "Cargando pantalla");

            wait.Show();

            try
            {
                ObtenerProveedores();
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


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtcontacto.Text.Length > 0)/*reparar no valida*/
                {

                    servicioProveedor.Agregarnuevocontacto(txtidcontacto.Text, Convert.ToString(txtCodigo.EditValue),
                        txtcontacto.Text, txtnocontacto.Text, txtcorreocontact.Text, txtCargo.Text);

                    Cargarcontacto(Convert.ToInt32(txtCodigo.EditValue));
                    LimpiarContacto();


                }
                else
                {
                    UIHelper.AlertarDeError("Ingrese un contacto");
                    txtcontacto.Focus();
                }
            }
            catch (Exception ex)
            {

                UIHelper.MostrarError(ex);

            }

        }



        private void gcProveedores_Click(object sender, EventArgs e)
        {

            Cargarproveedores();

        }

        private void gccontacto_Click(object sender, EventArgs e) // excelente para capturar valores de un gv y asignarlos a textbox
        {
            try
            {

                DataRow dr = gvcontacto.GetDataRow(gvcontacto.FocusedRowHandle);


                if (dr != null)  //me ayudo para que el click null en el gvproducto 
                {

                    txtcontacto.Text = Convert.ToString(dr["Contacto"]);
                    txtcorreocontact.Text = Convert.ToString(dr["Correo"]);
                    txtCargo.Text = Convert.ToString(dr["Cargo"]);
                    txtnocontacto.Text = Convert.ToString(dr["Celular"]);
                    txtidcontacto.Text = Convert.ToString(dr["IdContacto"]);

                }

            }

            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtcontacto.Text = "";
            txtnocontacto.Text = "";
            txtcorreocontact.Text = "";
            txtCargo.Text = "";
            txtidcontacto.Text = "";
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

            if (txtcontacto.Text.Length > 0)
            {
                servicioProveedor.Eliminar_Contacto(Convert.ToInt32(txtidcontacto.Text));
                Cargarcontacto(Convert.ToInt32(txtCodigo.EditValue));
                LimpiarContacto();

            }
            else
            {
                UIHelper.AlertarDeError("Primero seleccione un Contacto");
            }
        }
    }
}


