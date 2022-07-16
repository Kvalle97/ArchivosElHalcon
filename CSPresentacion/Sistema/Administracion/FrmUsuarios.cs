using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using CSDatos;
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
        private int idFirma = 0;

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

                childInstance.MostrarBotones(true, Opciones.Guardar, Opciones.Cerrar, Opciones.Nuevo);

                childInstance.MostrarCaptionEnBotones(true, Opciones.Guardar, Opciones.Cerrar, Opciones.Nuevo);
            }

            childInstance.BringToFront();

            return childInstance;
        }

        private void CargarUsuario()
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Cargando usuario");

            wait.Show();
            //ojo
            try
            {
                txtUsuario.Text = modeloUsuario.Usuario;
                txtNombres.Text = modeloUsuario.Nombres;
                txtApellidos.Text = modeloUsuario.Apellidos;
                txtTelefono.Text = modeloUsuario.Telefono;
                txtEmail.Text = modeloUsuario.email;

                ckAdministracion.Checked = modeloUsuario.Administracion;
                ckBancos.Checked = modeloUsuario.Bancos;
                ckCaja.Checked = modeloUsuario.Caja;
                ckCartera.Checked = modeloUsuario.Cartera;
                ckCompras.Checked = modeloUsuario.Compras;
                ckInventario.Checked = modeloUsuario.Inventario;
                ckProduccion.Checked = modeloUsuario.Produccion;
                ckProveedores.Checked = modeloUsuario.Proveedores;
                ckPrestamo.Checked = modeloUsuario.Proyecto;
                ckVentas.Checked = modeloUsuario.Ventas;
                lueTipoDeDescuento.EditValue = modeloUsuario.IdDescuento; /*00*/
                ckbActivo.Checked = modeloUsuario.Activo == 1;
                /*ok*/
                ckVentaCompartida.Checked = modeloUsuario.VentaCompartida;
                /*ok*/
                ckVentaproyecto.Checked = modeloUsuario.VendedorProyectos;
                ckGerenciacomercial.Checked = modeloUsuario.GerenciaComercial;
                ckPonermeta.Checked = modeloUsuario.PuedePonerMetas;
                ckTienemeta.Checked = modeloUsuario.TieneMeta;
                ckVeraveria.Checked = modeloUsuario.VerAverias;
                tipopromotor.EditValue = modeloUsuario.idPromotor;
                tiposegmento.EditValue = modeloUsuario.idSegmento;
                ckProformaWeb.Checked = modeloUsuario.ProformaWeb;
                ckVerMargen.Checked = modeloUsuario.verMargen;
                ckPermitirRegalias.Checked = modeloUsuario.PermitirRegalia;
                ckPagarfacturasA.Checked = modeloUsuario.PagarFacturasMasAntiguas;
                ckPrestamo.Checked = modeloUsuario.Prestamos;


                // PERMISOS INVENTARIO

                ckPermitirRealizarTraslados.Checked = modeloUsuario.PermitirRealizarTraslados;
                ckGuardarPrestamos.Checked = modeloUsuario.GuardarPrestamos;
                ckAplicarPrestamos.Checked = modeloUsuario.AplicarPrestamos;
                ckAutorizarST.Checked = modeloUsuario.AutorizarST;
                ckPermitirDepCompras.Checked = modeloUsuario.PermitirDepCompras;
                ckGirarPreIngresos.Checked = modeloUsuario.GirarPreingresos;

                // FIN PERMISOS INVENTARIO
                lueNievelDeAcceso.EditValue = modeloUsuario.IdNivel.ToString("D2");

                //ckComboPermiso.SetEditValue(UIHelper.ConvertirDataTableAListaSimple<int>(
                //     servicioUsuarios.ObtenerPermisosdeusuario(modeloPermisoVentas.IdUsuario), "IdUsuario"));

                ckComboSucursalesAsociadas.SetEditValue(UIHelper.ConvertirDataTableAListaSimple<int>(
                    servicioUsuarios.ObtenerSucursalesAsociadas(modeloUsuario.IdUsuario), "IdEmpresa"));

                ckComboRoles.SetEditValue(UIHelper.ConvertirDataTableAListaSimple<int>(
                    servicioUsuarios.ObtenerRolesAsociados(modeloUsuario.IdUsuario), "IdRol"));

                if (modeloUsuario.IdEmpresaUbicacion < 0)
                    lueSucursalDeOrigen.EditValue = null;
                else
                    lueSucursalDeOrigen.EditValue = modeloUsuario.IdEmpresaUbicacion;

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

                tabAdministrarFirmas.PageEnabled = tabCambioDeContrasenia.PageEnabled = modeloUsuario.IdUsuario != 0;

                servicioUsuarios.FirmasDisponiblesPorUsuario(lstBoxFirmas, modeloUsuario.IdUsuario);
                servicioUsuarios.CargarCorreos(gcCorreos, gvCorreos, modeloUsuario.IdUsuario);
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
                SmtpClient servidor = new SmtpClient("mail.elhalcon.com.ni") { Port = 25 };


                correo.From = new MailAddress("informatica@elhalcon.com.ni");

                List<object> lstCorreos = (List<object>)ckComboEnviarA.EditValue;

                foreach (int idCorreo in lstCorreos)
                {
                    correo.To.Add(servicioUsuarios.ObtenerCorreo(idCorreo));
                }

                correo.Subject = "Cambio de contraseña";
                correo.CC.Add("informatica@elhalcon.com.ni");

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

                servidor.Credentials = new NetworkCredential("informatica@elhalcon.com.ni", "E727cd9b1f");
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

            servicioUsuarios.CargarUsuarios(gcUsuarios, gvUsuarios);

            CargarUsuario();
        }

        /// <inheritdoc />
        protected override void GuardarEvent()
        {
            WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Guardando usuario");

            wait.Show();

            try
            {
                // Vamos a guardar el usuario :)

                if (((DataTable)gcCorreos.DataSource).Rows.Count <= 0)
                {
                    UIHelper.AlertarDeError("Debe agregar al menos un correo al usuario");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtUsuario, "El usuario es obligatorio");
                    return;
                }

                if (servicioUsuarios.UsuarioEstaSiendoUsado(txtUsuario.Text, modeloUsuario.IdUsuario))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtUsuario, "El usuario ya esta siendo usado");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombres.Text))
                {
                    UIHelper.AlertarDeError(dxErrorProvider, txtNombres, "El nombre es obligatorio");
                    return;
                }

                modeloUsuario.Usuario = txtUsuario.Text;
                modeloUsuario.Nombres = txtNombres.Text;
                modeloUsuario.Apellidos = txtApellidos.Text;
                modeloUsuario.Telefono = txtTelefono.Text;
                modeloUsuario.email = txtEmail.Text;

                modeloUsuario.Administracion = ckAdministracion.Checked;
                modeloUsuario.Bancos = ckBancos.Checked;
                modeloUsuario.Caja = ckCaja.Checked;
                modeloUsuario.Cartera = ckCartera.Checked;
                modeloUsuario.Compras = ckCompras.Checked;
                modeloUsuario.Inventario = ckInventario.Checked;
                modeloUsuario.Produccion = ckProduccion.Checked;
                modeloUsuario.Proveedores = ckProveedores.Checked;
                modeloUsuario.Proyecto = ckPrestamo.Checked;
                modeloUsuario.Ventas = ckVentas.Checked;
                modeloUsuario.IdDescuento = (int)lueTipoDeDescuento.EditValue; 
                //ojo
                //nuevo keyner
                modeloUsuario.VentaCompartida = ckVentaCompartida.Checked;
                modeloUsuario.VendedorProyectos = ckVentaproyecto.Checked;
                modeloUsuario.GerenciaComercial = ckGerenciacomercial.Checked;
                modeloUsuario.PuedePonerMetas = ckPonermeta.Checked;
                modeloUsuario.TieneMeta = ckTienemeta.Checked;
                modeloUsuario.VerAverias = ckVeraveria.Checked;
                modeloUsuario.idPromotor = (int)tipopromotor.EditValue;
                modeloUsuario.idSegmento = (int)tiposegmento.EditValue;
                modeloUsuario.ProformaWeb = ckProformaWeb.Checked;
                modeloUsuario.verMargen = ckVerMargen.Checked;
                modeloUsuario.PermitirRegalia = ckPermitirRegalias.Checked;
                modeloUsuario.PagarFacturasMasAntiguas = ckPagarfacturasA.Checked;
                modeloUsuario.Prestamos = ckPrestamo.Checked;
                //hasta aqui

                modeloUsuario.PermitirRealizarTraslados = ckPermitirRealizarTraslados.Checked;
                modeloUsuario.GuardarPrestamos = ckGuardarPrestamos.Checked;
                modeloUsuario.AplicarPrestamos = ckAplicarPrestamos.Checked;
                modeloUsuario.AutorizarST = ckAutorizarST.Checked;
                modeloUsuario.PermitirDepCompras = ckPermitirDepCompras.Checked;
                modeloUsuario.GirarPreingresos = ckGirarPreIngresos.Checked;

                // Esto se hace asi porque en sql el tipo de dato es tinyint :(
                // Si el usuario es nuevo siempre se le pondrá comoa ctivo
                modeloUsuario.Activo = modeloUsuario.IdUsuario == 0 ? 1 : ckbActivo.Checked ? 1 : 0;
                modeloUsuario.IdNivel = Convert.ToInt32(lueNievelDeAcceso.EditValue);

                // Si no hay una empresa de ubicacion se poner por defecto cero :)
                if (lueSucursalDeOrigen.EditValue == null)
                {
                    modeloUsuario.IdEmpresaUbicacion = -1;
                }
                else
                {
                    modeloUsuario.IdEmpresaUbicacion = (int)lueSucursalDeOrigen.EditValue;
                }

                servicioUsuarios.GuardarUsuario(modeloUsuario);



                // Nos servira para preguntar si queremos asignarle una contrasenia
                // temporal a un posible nuevo usuario
                bool preguntarPorCambioDeContra = false;

                // Si se esta ingresando un nuevo usuario

                if (modeloUsuario.IdUsuario == 0)
                {
                    modeloUsuario = UIHelper.ObtenerItem<ModeloUsuario>(servicioUsuarios.ObtenerUltimoUsuario());
                    preguntarPorCambioDeContra = true;
                }

                List<CorreoM> lstCorreos = UIHelper.ConvertirDataTable<CorreoM>(
                    (DataTable)gcCorreos.DataSource);

                // Guardando correos :)

                lstCorreos.ForEach(correo =>
                {
                    servicioUsuarios.GuardarCorreoUsuario(correo.IdCorreo, correo.Correo, modeloUsuario.IdUsuario);
                });

                // Guardando empresas asociadas :)

                List<object> lstEmpresasAsociadas = ckComboSucursalesAsociadas.EditValue as List<object>;

                // Eliminamos lo que hay para poner solo lo que esta en el ckCombo
                servicioUsuarios.EliminarSucursalesAsociadas(modeloUsuario.IdUsuario);


                if (lstEmpresasAsociadas != null)
                {
                    // Guardando
                    foreach (int idEmpresa in lstEmpresasAsociadas)
                    {
                        servicioUsuarios.GuardarSucursal(modeloUsuario.IdUsuario, modeloUsuario.Usuario, idEmpresa);
                    }
                }

                // Guardando roles asociados :)

                List<object> lstRolesAsociados = ckComboRoles.EditValue as List<object>;


                // Eliminamos lo que hay para poner solo lo que esta en el ckCombo
                servicioUsuarios.EliminarRolesAsociados(modeloUsuario.IdUsuario);


                if (lstRolesAsociados != null)
                {
                    // Guardando
                    foreach (int idRol in lstRolesAsociados)
                    {
                        servicioUsuarios.GuardarRol(modeloUsuario.IdUsuario, idRol);
                    }
                }

                if (preguntarPorCambioDeContra)
                {
                    servicioUsuarios.CargarCorreosDeUsuario(ckComboEnviarA, modeloUsuario.IdUsuario);

                    ckComboEnviarA.CheckAll();

                    if (UIHelper.PreguntarSn("¿ Quiere crear una contraseña temporal para el usuario ?") ==
                        DialogResult.Yes)
                    {
                        txtContrasenia.Text = UIHelper.CrearContrasenia(10);

                        EnviarCorreo(TipoDeCuerpoEnCorreo.Bienvenida);

                        servicioUsuarios.CambiarContraUsuario(modeloUsuario.IdUsuario,
                            new EncriptarInformacion().Encriptar(txtContrasenia.Text), true);
                    }
                }

                NuevoEvent();
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

        #endregion

        #region Eventos

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                servicioUsuarios.CargarUsuarios(gcUsuarios, gvUsuarios);
                servicioUsuarios.CargarSucursales(lueSucursalDeOrigen, false);
                servicioUsuarios.CargarNiveles(lueNievelDeAcceso);
                servicioUsuarios.CargarRoles(ckComboRoles); /*ojo*/
                servicioUsuarios.CargarTipoPromotor(tipopromotor);
                servicioUsuarios.CargarTipoSegmento(tiposegmento);
                servicioAcciones.MostrarAccesoBase(gcAcceso, gvAcceso);
                servicioUsuarios.CargarTipoDescuento(lueTipoDeDescuento);
                servicioUsuarios.CargarCorreos(gcCorreos, gvCorreos, 0);
                servicioUsuarios.CargarSucursales(ckComboSucursalesAsociadas);






                ckbActivo.Checked = true;
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
                servicioUsuarios.CambiarContraUsuario(modeloUsuario.IdUsuario,
                    new EncriptarInformacion().Encriptar(txtContrasenia.Text), ckContraEsTemporal.Checked);

                EnviarCorreo(ckContraEsTemporal.Checked
                    ? TipoDeCuerpoEnCorreo.NuevaContraTemporal
                    : TipoDeCuerpoEnCorreo.NuevaContra);
            }
        }

        private void gcUsuarios_KeyUp(object sender, KeyEventArgs e)
        {
            if (gvUsuarios.FocusedRowHandle < 0) return;
            if (e.KeyCode != Keys.Enter) return;
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

        private void gcCorreos_KeyUp(object sender, KeyEventArgs e)
        {
            if (!gvCorreos.IsValidRowHandle(gvCorreos.FocusedRowHandle)) return;
            if (e.KeyCode != Keys.Delete) return;

            if (UIHelper.PreguntarSn("¿ Está seguro que quiere borrar el correo ? ") == DialogResult.Yes)
            {
                try
                {
                    CorreoM correo = UIHelper.ObtenerItem<CorreoM>(gvCorreos.GetDataRow(gvCorreos.FocusedRowHandle));

                    gvAcceso.DeleteRow(gvCorreos.FocusedRowHandle);

                    if (correo.IdCorreo != 0)
                    {
                        servicioUsuarios.BorrarCorreo(correo.IdCorreo);
                    }
                }
                catch (Exception exception)
                {
                    UIHelper.MostrarError(exception);
                }
            }
        }

        #endregion

        #region Clases

        class CorreoM
        {
            public int IdCorreo { get; set; }
            public string Correo { get; set; }
        }

        private void btnAgregarNuevaFirma_Click(object sender, EventArgs e)
        {
        }

        private void btnQuitarNuevaFirma_Click(object sender, EventArgs e)
        {
            if (lstBoxFirmas.SelectedItem is null)
            {
                UIHelper.AlertarDeError("Primero seleccione una firma");
            }
        }

        private void btnGuardarFirma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreFirma.Text))
            {
                UIHelper.AlertarDeError(
                    "Por favor establezca un nombre para que el usuario pueda identificar la firma");
                return;
            }

            if (peVistaPreviaFirma.Image is null)
            {
                UIHelper.AlertarDeError("Suba una imagen con click derecho agregar imagen...");
                return;
            }

            servicioUsuarios.GuardarFirmaUsuario(idFirma, modeloUsuario.IdUsuario, txtNombreFirma.Text,
                UIHelper.ObtenerImagen(peVistaPreviaFirma.Image));

            servicioUsuarios.FirmasDisponiblesPorUsuario(lstBoxFirmas, modeloUsuario.IdUsuario);
        }

        private void btnNuevoFirma_Click(object sender, EventArgs e)
        {
            idFirma = 0;
            peVistaPreviaFirma.Image = null;
            txtNombreFirma.Enabled = true;
            txtNombreFirma.Text = string.Empty;
        }

        private void lstBoxFirmas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstBoxFirmas.SelectedItem is null)
            {
                btnNuevoFirma.PerformClick();
            }
            else
            {
                var drSelected = (DataRowView)lstBoxFirmas.SelectedItem;
                var dr = servicioUsuarios.ObtenerFirmaOSello(Convert.ToInt32(drSelected["Id"]));
                txtNombreFirma.Text = Convert.ToString(dr["Nombre"]);

                UIHelper.AgregarImagen(peVistaPreviaFirma, (byte[])dr["FirmaOSello"]);
            }
        }

        #endregion
    }
}