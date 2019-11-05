using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Properties;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.Utils;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    ///     Formulario de usuarios
    /// </summary>
    public partial class FrmUsuarios : FrmBase
    {
        // ReSharper disable once InconsistentNaming
        private static FrmUsuarios childInstance;
        private ModeloUsuario modeloUsuario = new ModeloUsuario();

        private readonly ServicioAcciones servicioAcciones = new ServicioAcciones();
        private readonly ServicioUsuarios servicioUsuarios = new ServicioUsuarios();

        private enum TipoDeCuerpoEnCorreo
        {
            NuevaContra,
            NuevaContraTemporal,
            Bienvenida
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        #region Metodos

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

        private void CargarUsuario()
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Cargando usuario");

            wait.Show();

            try
            {
                txtUsuario.Text = modeloUsuario.Usuario;
                txtNombres.Text = modeloUsuario.Nombres;
                txtApellidos.Text = modeloUsuario.Apellidos;
                txtTelefono.Text = modeloUsuario.Telefono;

                ckAdministracion.Checked = modeloUsuario.Administracion;
                ckBancos.Checked = modeloUsuario.Bancos;
                ckCaja.Checked = modeloUsuario.Caja;
                ckCartera.Checked = modeloUsuario.Cartera;
                ckCompras.Checked = modeloUsuario.Compras;
                ckInventario.Checked = modeloUsuario.Inventario;
                ckProduccion.Checked = modeloUsuario.Produccion;
                ckProveedores.Checked = modeloUsuario.Proveedores;
                ckProyecto.Checked = modeloUsuario.Proyecto;
                ckVentas.Checked = modeloUsuario.Ventas;
                seNumerDeDescuento.Value = modeloUsuario.IdDescuento;
                seDescuentoMaximo.Value = servicioUsuarios.ObtenerDescuentoMaximoDelUsuario(modeloUsuario.IdUsuario);

                ckbActivo.Checked = modeloUsuario.Activo == 1;

                lueNievelDeAcceso.EditValue = modeloUsuario.IdNivel.ToString("D2");

                if (modeloUsuario.IdEmpresaUbicacion != 0)
                    lueSucursalDeOrigen.EditValue = modeloUsuario.IdEmpresaUbicacion;
                else
                    lueSucursalDeOrigen.EditValue = null;

                servicioUsuarios.CargarCorreosDeUsuario(ckComboEnviarA, modeloUsuario.IdUsuario);

                if (modeloUsuario.IdUsuario == 0)
                {
                    tabControlUsuario.SelectedTabPage = tabDatosGenerales;
                    txtUsuario.ReadOnly = false;
                }
                else
                {
                    txtUsuario.ReadOnly = true;
                    servicioAcciones.MostrarAccesoBase(gcAcceso, gvAcceso);

                    // Mostrar donde puede acceder
                    List<ConjuntoAcceso> lstConjuntoAccesos =
                        UIHelper.ConvertirDataTable<ConjuntoAcceso>(
                            servicioUsuarios.ObtenerAccesosDeUsuario(modeloUsuario.IdUsuario));

                    for (int i = 0; i < gvAcceso.RowCount + 1; i++)
                    {
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

                tabCambioDeContrasenia.PageEnabled = modeloUsuario.IdUsuario != 0;
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

        private void EnviarCorreo(TipoDeCuerpoEnCorreo tipo)
        {
            try
            {
                MailMessage correo = new MailMessage();
                SmtpClient servidor = new SmtpClient("192.168.0.9");

                servidor.Port = 25;

                correo.From = new MailAddress("admin@elhalcon.com.ni");
                correo.To.Add("agaitan@elhalcon.com.ni");
                correo.Subject = "Contraseña temporal";
                //correo.CC.Add("informatica@elhalcon.com.ni");

                string cuerpo = Resources.HtmlPass;
                string cuerpoDelCorreo = string.Empty;

                switch (tipo)
                {
                    case TipoDeCuerpoEnCorreo.NuevaContra:
                        cuerpoDelCorreo = Datos_Globales.CambioContra;
                        break;
                    case TipoDeCuerpoEnCorreo.NuevaContraTemporal:
                        cuerpoDelCorreo = Datos_Globales.CambioContraTemporal;
                        break;
                    case TipoDeCuerpoEnCorreo.Bienvenida:
                        cuerpoDelCorreo = Datos_Globales.Bienvenida;
                        cuerpoDelCorreo = cuerpoDelCorreo.Replace("@Usuario", modeloUsuario.Usuario);
                        break;
                }

                cuerpo = cuerpo.Replace("@Cuerpo", cuerpoDelCorreo);

                cuerpo = cuerpo.Replace("@USUARIO", modeloUsuario.Nombres);
                cuerpo = cuerpo.Replace("@PASSWORD", txtContrasenia.Text);

                correo.Body = cuerpo;
                correo.IsBodyHtml = true;

                servidor.Credentials = new NetworkCredential("admin@elhalcon.com.ni", "e8ad1bHjr");
                servidor.EnableSsl = false;

                servidor.SendAsync(correo, null);

                servidor.SendCompleted += (sender, args) =>
                {
                    alertControl.Show(this, "Correo enviado con exito", "Se envió el correo al destinatario",
                        Resources.adjuntar);
                };
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        #endregion

        #region Sobrecarga

        /// <inheritdoc />
        protected override void NuevoEvent()
        {
            modeloUsuario = new ModeloUsuario();
            CargarUsuario();
        }

        #endregion

        #region Eventos

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                servicioUsuarios.CargarUsuarios(gcUsuarios, gvUsuarios);
                servicioUsuarios.CargarSucursales(lueSucursalDeOrigen, false);
                servicioUsuarios.CargarNiveles(lueNievelDeAcceso);
                servicioUsuarios.CargarRoles(ckComboRoles);
                servicioAcciones.MostrarAccesoBase(gcAcceso, gvAcceso);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void gvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            if (gvUsuarios.FocusedRowHandle < 0) return;
            try
            {
                modeloUsuario = UIHelper.ObtenerItem<ModeloUsuario>(
                    servicioUsuarios.ObtenerUsuario(Convert.ToInt32(gvUsuarios.GetFocusedDataRow()["IdUsuario"])));

                CargarUsuario();
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnGenerarContrasenia_Click(object sender, EventArgs e)
        {
            try
            {
                txtContrasenia.Text = UIHelper.CrearContrasenia(10);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnCambiarContrasenia_Click(object sender, EventArgs e)
        {
            if (UIHelper.PreguntarSn($"¿ Está seguro que quiere cambiar la contraseña de {modeloUsuario.Usuario} ?") ==
                DialogResult.Yes)
            {
                EnviarCorreo(TipoDeCuerpoEnCorreo.Bienvenida);
            }
        }

        #endregion

        private void tabOpcionesGenerales_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}