﻿using System;
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
                lueTipoDeDescuento.EditValue = modeloUsuario.IdDescuento;
                ckbActivo.Checked = modeloUsuario.Activo == 1;

                lueNievelDeAcceso.EditValue = modeloUsuario.IdNivel.ToString("D2");

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

                tabCambioDeContrasenia.PageEnabled = modeloUsuario.IdUsuario != 0;

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
                SmtpClient servidor = new SmtpClient("192.168.0.9");

                servidor.Port = 25;

                correo.From = new MailAddress("admin@elhalcon.com.ni");

                List<object> lstCorreos = (List<object>) ckComboEnviarA.EditValue;

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

                if (((DataTable) gcCorreos.DataSource).Rows.Count <= 0)
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

                modeloUsuario.Administracion = ckAdministracion.Checked;
                modeloUsuario.Bancos = ckBancos.Checked;
                modeloUsuario.Caja = ckCaja.Checked;
                modeloUsuario.Cartera = ckCartera.Checked;
                modeloUsuario.Compras = ckCompras.Checked;
                modeloUsuario.Inventario = ckInventario.Checked;
                modeloUsuario.Produccion = ckProduccion.Checked;
                modeloUsuario.Proveedores = ckProveedores.Checked;
                modeloUsuario.Proyecto = ckProyecto.Checked;
                modeloUsuario.Ventas = ckVentas.Checked;
                modeloUsuario.IdDescuento = (int) lueTipoDeDescuento.EditValue;

                // Esto se hace asi porque en sql el tipo de dato es tinyint :(
                modeloUsuario.Activo = ckbActivo.Checked ? 1 : 0; 

                modeloUsuario.IdNivel = Convert.ToInt32(lueNievelDeAcceso.EditValue);

                // Si no hay una empresa de ubicacion se poner por defecto cero :)
                if (lueSucursalDeOrigen.EditValue == null)
                {
                    modeloUsuario.IdEmpresaUbicacion = -1;
                }
                else
                {
                    modeloUsuario.IdEmpresaUbicacion = (int) lueSucursalDeOrigen.EditValue;
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
                    gcCorreos.DataSource as DataTable);

                // Guardando correos :)

                lstCorreos.ForEach(correo =>
                {
                    servicioUsuarios.GuardarCorreoUsuario(correo.IdCorreo, correo.Correo, modeloUsuario.IdUsuario);
                });

                // Guardando empresas asociadas :)

                List<object> lstEmpresasAsociadas = (List<object>) ckComboSucursalesAsociadas.EditValue;

                // Eliminamos lo que hay para poner solo lo que esta en el ckCombo
                servicioUsuarios.EliminarSucursalesAsociadas(modeloUsuario.IdUsuario);

                // Guardando
                foreach (int idEmpresa in lstEmpresasAsociadas)
                {
                    servicioUsuarios.GuardarSucursal(modeloUsuario.IdUsuario, modeloUsuario.Usuario, idEmpresa);
                }

                // Guardando roles asociados :)

                List<object> lstRolesAsociados = (List<object>) ckComboRoles.EditValue;

                // Eliminamos lo que hay para poner solo lo que esta en el ckCombo
                servicioUsuarios.EliminarRolesAsociados(modeloUsuario.IdUsuario);

                // Guardando
                foreach (int idRol in lstRolesAsociados)
                {
                    servicioUsuarios.GuardarRol(modeloUsuario.IdUsuario, idRol);
                }

                if (preguntarPorCambioDeContra)
                {
                    servicioUsuarios.CargarCorreosDeUsuario(ckComboEnviarA, modeloUsuario.IdUsuario);
                    ckComboEnviarA.CheckAll();

                    servicioUsuarios.CambiarContraUsuario(modeloUsuario.IdUsuario,
                        new EncriptarInformacion().Encriptar(txtContrasenia.Text), true);

                    if (UIHelper.PreguntarSn("¿ Quiere crear una contraseña temporal para el usuario ?") ==
                        DialogResult.Yes)
                    {
                        txtContrasenia.Text = UIHelper.CrearContrasenia(10);

                        EnviarCorreo(TipoDeCuerpoEnCorreo.Bienvenida);
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
                servicioUsuarios.CargarRoles(ckComboRoles);
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

        #endregion
    }
}