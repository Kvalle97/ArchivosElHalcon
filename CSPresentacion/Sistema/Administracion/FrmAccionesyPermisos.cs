using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;
using Accion = CSNegocios.Modelos.Accion;
using String = System.String;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario de acciones y permisos
    /// </summary>
    public partial class FrmAccionesyPermisos : DevExpress.XtraEditors.XtraForm
    {
        // ReSharper disable once InconsistentNaming
        private static FrmAccionesyPermisos childInstance = null;
        private readonly ServicioAcciones servicioAcciones = new ServicioAcciones();
        private Accion accion = new Accion();
        private Rol rol = new Rol();

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmAccionesyPermisos()
        {
            InitializeComponent();
        }

        #region Metodos

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmAccionesyPermisos Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmAccionesyPermisos();
            }

            childInstance.BringToFront();

            return childInstance;
        }

        private void CargarAccion()
        {
            txtNombre.Text = accion.Nombre;
            meDescripcion.Text = accion.Descripcion;
            ckbAuditable.Checked = accion.Auditable;
        }

        private void CargarRol()
        {
            try
            {
                txtNombreRol.Text = rol.Nombre;
                meDescripcionRol.Text = rol.Descripcion;
                ckbEsSuperAdministrador.Checked = rol.EsSuperAdministrador;

                servicioAcciones.MostrarAccesoBase(gcAcceso, gvAcceso);

                // Si es super administrador no cargamos accesos
                // porque puede acceder a todo

                if (rol.Id != 0 && !rol.EsSuperAdministrador)
                {
                    List<ConjuntoAcceso> lstConjuntoAccesos =
                        UIHelper.ConvertirDataTable<ConjuntoAcceso>(servicioAcciones.ObtenerAccesoDelRol(rol.Id));

                    for (int i = 0; i < gvAcceso.RowCount; i++)
                    {
                        DataRowView dr = (DataRowView) gvAcceso.GetRow(i);

                        int childCount = gvAcceso.GetChildRowCount(i);

                        for (int j = 0; j < childCount; j++)
                        {
                            int childRowHandle = gvAcceso.GetChildRowHandle(i, j);
                            
                            int idPantalla = Convert.ToInt32(gvAcceso.GetDataRow(childRowHandle)[0]);

                            int idAccion = Convert.ToInt32(gvAcceso.GetDataRow(childRowHandle)[2]);

                            if (lstConjuntoAccesos.Any(x => x.IdPantalla == idPantalla && x.IdAccion == idAccion))
                            {
                                gvAcceso.SelectRow(childRowHandle);
                            }
                        }
                    }
                }

                // Debes haber guardado el rol para poder 
                // Agregar o modificar sus accesos
                gcAcceso.Enabled = !rol.EsSuperAdministrador && rol.Id > 0;
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        #endregion

        #region Eventos

        private void FrmAccionesyPermisos_Load(object sender, EventArgs e)
        {
            try
            {
                servicioAcciones.MostrarAcciones(gcAcciones, gvAcciones);
                servicioAcciones.MostrarRoles(gcRoles, gvRoles);
                servicioAcciones.MostrarAccesoBase(gcAcceso, gvAcceso);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvAcciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvAcciones.FocusedRowHandle >= 0)
                {
                    accion = UIHelper.ObtenerItem<Accion>(
                        servicioAcciones.ObtenerAccion(Convert.ToInt32(gvAcciones.GetFocusedDataRow()["Id"])));

                    CargarAccion();
                }
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dxErrorProvider.ClearErrors();

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombre, "Nombre no valido");
                    return;
                }

                if (servicioAcciones.EstaEnUsoNombreDeAccion(txtNombre.Text, accion.Id))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombre, "El nombre ya está en uso");
                    return;
                }

                accion.Nombre = txtNombre.Text;
                accion.Descripcion = meDescripcion.Text;
                accion.Auditable = ckbAuditable.Checked;

                servicioAcciones.GuardarAccion(accion);

                btnNuevo.PerformClick();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                accion = new Accion();

                CargarAccion();

                servicioAcciones.MostrarAcciones(gcAcciones, gvAcciones);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvAcciones_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gvAcciones.FocusedRowHandle >= 0)
                    {
                        accion = UIHelper.ObtenerItem<Accion>(
                            servicioAcciones.ObtenerAccion(Convert.ToInt32(gvAcciones.GetFocusedDataRow()["Id"])));

                        CargarAccion();
                    }
                }
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (accion.Id != 0)
                {
                    if (UIHelper.PreguntarSn($"¿Está seguro que desea eliminar la acción {accion.Nombre}?") ==
                        DialogResult.Yes)
                    {
                        servicioAcciones.EliminarAccion(accion.Id);
                    }
                }
                else
                {
                    UIHelper.AlertarDeError("Primero seleccione una accion");
                }
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvRoles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvRoles.FocusedRowHandle < 0) return;

                rol = UIHelper.ObtenerItem<Rol>(servicioAcciones.ObtenerRol(
                    Convert.ToInt32(gvRoles.GetFocusedDataRow()["Id"])
                ));

                CargarRol();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreRol.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombreRol, "Nombre de rol no valido");
                    return;
                }

                if (servicioAcciones.EstaEnUsoNombreDeRol(txtNombreRol.Text, rol.Id))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombreRol, "El nombre del rol ya está siendo usado");
                    return;
                }

                rol.Nombre = txtNombreRol.Text;
                rol.Descripcion = meDescripcionRol.Text;
                rol.EsSuperAdministrador = ckbEsSuperAdministrador.Checked;

                servicioAcciones.GuardarRol(rol);

                if (rol.Id != 0)
                {
                    servicioAcciones.LimpiarAcceso(rol.Id);
                }

                // Guardamos los accesos si no es super administrador
                // con super administrador puede entrar a todos los sistemas
                // definidos con sus acciones definidas
                if (!rol.EsSuperAdministrador)
                {
                    List<ConjuntoAcceso> lstConjuntoAccesos = new List<ConjuntoAcceso>();

                    foreach (var indice in gvAcceso.GetSelectedRows())
                    {
                        if (indice < 0) continue;

                        DataRowView drv = (DataRowView) gvAcceso.GetRow(indice);

                        var acceso = new ConjuntoAcceso()
                        {
                            IdAccion = Convert.ToInt32(drv["IdAccion"]),
                            IdPantalla = Convert.ToInt32(drv["IdPantalla"])
                        };

                        lstConjuntoAccesos.Add(acceso);
                    }

                    foreach (ConjuntoAcceso acceso in lstConjuntoAccesos)
                    {
                        servicioAcciones.GuardarAcceso(rol.Id, acceso.IdPantalla, acceso.IdAccion);
                    }
                }

                btnNuevoRol.PerformClick();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            rol = new Rol();

            CargarRol();
        }

        #endregion
        
    }
}