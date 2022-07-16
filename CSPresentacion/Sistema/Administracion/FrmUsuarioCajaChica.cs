using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPresentacion.Sistema.Administracion
{

    public partial class FrmUsuarioCajaChica : DevExpress.XtraEditors.XtraForm
    {
        private static FrmUsuarioCajaChica _childInstance = null;
        ModeloUsuarioCajaChica modelosuariocajachica = new ModeloUsuarioCajaChica();
        ServicioUsuarioCajaChica servicioUsuariocajachica = new ServicioUsuarioCajaChica();

        public FrmUsuarioCajaChica()
        {
            InitializeComponent();
            Cargarlookups();

        }


        public static FrmUsuarioCajaChica Instance()

        {
            if (_childInstance == null || _childInstance.IsDisposed == true)
            {
                _childInstance = new FrmUsuarioCajaChica();

            }
            _childInstance.BringToFront();

            return _childInstance;

        }

        private void Cargarlookups()
        {

            servicioUsuariocajachica.ObtenerEmpresa(luEmpresa);
            servicioUsuariocajachica.ObtenerGastos(ckComboGasto);
            servicioUsuariocajachica.ObtenerCajaChica(lucajac);
            servicioUsuariocajachica.ObtenerEmpresa(luempresaUsuario);
            CargarData();

        }

        private void CargarData()
        {
            servicioUsuariocajachica.Obtenercajas(gccaja, gvCajas);
            servicioUsuariocajachica.ObtenerUsuarios(gcusuarios,gvusuarios);


        }

        private void gccaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (!gvCajas.IsValidRowHandle(gvCajas.FocusedRowHandle)) return;


                modelosuariocajachica.Idcajachica = Convert.ToInt32(gvCajas.GetRowCellValue(gvCajas.FocusedRowHandle, "IdCajaChica"));
                txtDescripcionCaja.Text = Convert.ToString(gvCajas.GetRowCellValue(gvCajas.FocusedRowHandle, "DescripcionCajaChica"));
                luEmpresa.Text = Convert.ToString(gvCajas.GetRowCellValue(gvCajas.FocusedRowHandle, "Empresa"));
                ckactivo.Checked = Convert.ToBoolean(gvCajas.GetRowCellValue(gvCajas.FocusedRowHandle, "Activo"));
                ckComboGasto.SetEditValue(UIHelper.ConvertirDataTableAListaSimple<int>(
                servicioUsuariocajachica.Obtenergastoscajas(modelosuariocajachica.Idcajachica), "IdGastoSucursal"));
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }


        private void luempresaUsuario_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (luempresaUsuario.EditValue != null)
                {
                    var dr = (DataRowView)luempresaUsuario.GetSelectedDataRow();

                    modelosuariocajachica.Idsucursal = Convert.ToInt32(dr["IdEmpresa"]);

                    luusuario.Properties.DataSource = servicioUsuariocajachica.ObtenerUsuarioporEmpresa(modelosuariocajachica.Idsucursal);
                    luusuario.Properties.ValueMember ="IdUsuario";
                    luusuario.Properties.DisplayMember = "Usuario";
                    luusuario.Properties.ForceInitialize();

                }
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }



        private void btnAgregarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcionCaja.Text.Length > 0 & ckComboGasto.EditValue != null & luEmpresa.EditValue != null)
                {

                    modelosuariocajachica.DescripcionCajaChica = Convert.ToString(txtDescripcionCaja.Text);
                    modelosuariocajachica.Idsucursal = Convert.ToInt32(luEmpresa.EditValue);
                    modelosuariocajachica.Activo = !ckactivo.Checked ? 0 : 1;

                    servicioUsuariocajachica.Guardarcajachica(modelosuariocajachica.DescripcionCajaChica,
                                                                      Datos_Globales.Usuario, Datos_Globales.PC, modelosuariocajachica.Activo, modelosuariocajachica.Idsucursal);

                    modelosuariocajachica.Idcajachica = servicioUsuariocajachica.Obtenerultimacaja();

                    servicioUsuariocajachica.ObtenerCajaChica(lucajac);

                    List<object> lstGastos = ckComboGasto.EditValue as List<object>;

                    if (lstGastos != null)
                    {
                        // Guardando
                        foreach (int idgasto in lstGastos)
                        {
                            servicioUsuariocajachica.GuardarGasto(modelosuariocajachica.Idcajachica, idgasto, Datos_Globales.Usuario, Datos_Globales.PC);
                        }
                    }

                }
                else
                {
                    UIHelper.AlertarDeError("Debe seleccionar todos los campos");
                }
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }

        }

        private void btnAgregarUsu_Click(object sender, EventArgs e)
        {
            try
            {
                if (lucajac.EditValue != null & luempresaUsuario.EditValue != null & luusuario.EditValue != null)
                {
                    modelosuariocajachica.Idcajachica = Convert.ToInt32(lucajac.EditValue);
                    modelosuariocajachica.idusuario = Convert.ToInt32(luusuario.EditValue);
                    modelosuariocajachica.Activo = !ckactivo1.Checked ? 0 : 1;

                    servicioUsuariocajachica.GuardarUsuario(modelosuariocajachica.Idcajachica, modelosuariocajachica.idusuario, 
                                                               Datos_Globales.Usuario, Datos_Globales.PC,modelosuariocajachica.Activo);
                }

                else
                {
                    UIHelper.AlertarDeError("Debe seleccionar todos los campos");
                }


            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }

        }
    }

}
