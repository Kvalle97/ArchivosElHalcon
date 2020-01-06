using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CSNegocios;
using CSNegocios.Servicios;
using CSPresentacion.Properties;
using CSPresentacion.Sistema.Administracion;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace CSPresentacion
{
    /// <summary>
    ///     Formulario principal
    /// </summary>
    public partial class FrmMain : RibbonForm
    {
        private static readonly List<string> LstDePantallas = new List<string>
        {
            "Usuarios",
            "Sistemasypantallas",
            "Accionesopermisos",
            "TasaDeCambio",
            "Documentos",
            "Información",
            "Bodegas"
        };

        private readonly bool preguntarSucursal = false;
        private readonly ServicioUsuarios servicioUsuarios = new ServicioUsuarios();

        /// <summary>
        ///     Constructor
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }


        #region Funciones

        /// <summary>
        ///     Agrega al MDI el formulario correspindiente
        /// </summary>
        /// <param name="form">Formulario</param>
        private void AgregarAlMdi(Form form)
        {
            form.MdiParent = this;
            form.Icon = this.Icon;
            form.Show();
        }
        
        /// <summary>
        /// Mostrar como dialog
        /// </summary>
        /// <param name="form"></param>
        /// <param name="isFixed"></param>
        private void MostrarComoDialog(Form form, bool isFixed = false)
        {
            if (form != null)
            {
                form.Icon = this.Icon;
                form.ShowDialog();

                if (isFixed)
                {
                    form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    form.StartPosition = FormStartPosition.CenterScreen;
                }
            }
        }
        /// <summary>
        ///     Mostrar manual de usuario
        /// </summary>
        private void MostrarManualDeUsuario()
        {
            try
            {
                string path = Application.StartupPath;

                path = path + "\\manual" + "\\" + "manual.pdf";

                FrmPdfViewer frmPdfViewer = new FrmPdfViewer();

                frmPdfViewer.CargarDocumento(path);
                frmPdfViewer.WindowState = FormWindowState.Maximized;
                frmPdfViewer.Icon = Icon;
                frmPdfViewer.Text = "Manual de usuario";
                frmPdfViewer.ShowDialog();
            }
            catch (FileNotFoundException e)
            {
                UIHelper.AlertarDeError("No tienes copiado el manual de usario, contacta con informatica");
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        #endregion

        #region Eventos

        private void btnReporteTabular_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnReportePivote_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void skinPaletteRibbonGalleryBarItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Settings.Default.Recordar)
            {
                Settings.Default.UserPalette = UserLookAndFeel.Default.ActiveSvgPaletteName;
                Settings.Default.Save();
            }

            OperacionesGlobal.EjecutarConsulta("update halcon.dbo.usuarios set Paleta = '" +
                                               UserLookAndFeel.Default.ActiveSvgPaletteName + "' where Usuario = '" +
                                               Datos_Globales.Usuario + "'");
        }

        private void skinPaletteRibbonGalleryBarItem1_GalleryItemClick(object sender,
            GalleryItemClickEventArgs e)
        {
            if (Settings.Default.Recordar)
            {
                Settings.Default.UserPalette = e.Item.Value.ToString();
                Settings.Default.Save();
            }

            OperacionesGlobal.EjecutarConsulta("update halcon.dbo.usuarios set Paleta = '" + e.Item.Value +
                                               "' where Usuario = '" + Datos_Globales.Usuario + "'");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UIHelper.CrearEventoDeActualizacion();

            IniciarMain();
        }

        private void IniciarMain()
        {
            UIHelper.BuscarActualizaciones();

            int n = OperacionesGlobal.numGet_Int("select halcon.[dbo].[fxObtenerUsuarioEmpresas]('" +
                                                 Datos_Globales.Usuario + "') AS n");

            UIHelper.ValidarPantallas(LstDePantallas, rpModulos,
                new[] {"Reportes", "Importaciones en transito"});

            if (preguntarSucursal)
            {
                switch (n)
                {
                    case 0:
                        XtraMessageBox.Show("Este usuario no tiene Sucursales Asociadas");
                        Close();
                        break;

                    case 1:
                        Datos_Globales.IdSucursal = OperacionesGlobal.numGet_Int(
                            "select halcon.[dbo].[fxObtenerUsuarioIDEmpresa]('" + Datos_Globales.Usuario + "')");
                        Datos_Globales.NombreSucursal = OperacionesGlobal.strGet_String(
                            "select halcon.[dbo].[fxObtenerNombreSucursal](" + Datos_Globales.IdSucursal +
                            ") as Sucursal", "Halcon");


                        break;

                    default:
                        FrmSucursales frm = new FrmSucursales();
                        frm.ShowDialog();
                        if (frm.DialogResult != DialogResult.OK)
                            Close();
                        break;
                }

                barSucursal.Caption = "Sucursal: " + Datos_Globales.NombreSucursal;
                barSucursal.Visibility = BarItemVisibility.Always;

                Datos_Globales.ID_Empresa = Datos_Globales.IdSucursal.ToString();
            }
            else
            {
                barSucursal.Visibility = BarItemVisibility.Never;
                Datos_Globales.IdSucursal = -1;
                Datos_Globales.ID_Empresa = null;
                Datos_Globales.NombreSucursal = null;
            }

            barUsuario.Caption = "Usuario: " + Datos_Globales.Usuario;
            barLogin.Caption = "ID: " + Datos_Globales.IdLogin;
            barTC.Caption = "TC: " + OperacionesGlobal.Obtener_TC();
            barVersion.Caption = "Version: " + Datos_Globales.VersionSistemaLocal;
            //**********Parte nueva************/
            barIP.Caption = "IP: " + Datos_Globales.IPLocal;

            if (Datos_Globales.NombreSucursal != null)
                Text = "Sistema de administración, " + Datos_Globales.NombreSucursal;
            else
                Text = "Sistema de administración";
        }

        private void btnFormulario_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                AgregarAlMdi(FrmUsuarios.Instance());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnManualDeUsuarioTop_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarManualDeUsuario();
        }

        private void btnManualDeUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarManualDeUsuario();
        }

        private void btnCerrarSesion_ItemClick(object sender, ItemClickEventArgs e)
        {
            MdiChildren.ToList().ForEach(x => x.Close());

            if (!MdiChildren.Any())
            {
                Hide();

                if (new FrmLogin().ShowDialog() == DialogResult.OK)
                    try
                    {
                        UIHelper.ResetearModulo(rpModulos);

                        Show();

                        IniciarMain();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                else
                    Application.Exit();
            }
        }


        private void btnOrdenesDeCompraPorProveedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            //AgregarAlMdi(FrmReportes.Instance(FrmReportes.TipoDeReporte.OrdenDeCompraPorProveedor));
        }

        private void btnOrdenesDeCompraSinAplicar_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btndetalleDePolizaPorMes_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnImportacioneEnTransito_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnproductosCompradosYVendidosPorProveedorYSucursal_ItemClick(object sender, ItemClickEventArgs e)
        {
        }


        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (!reLogeo)
            //{
            //    Application.Exit();
            //}
        }

        private void btnAdministradorDeSistema_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                AgregarAlMdi(FrmSistemasyPantallas.Instance());
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnPermisos_ItemClick(object sender, ItemClickEventArgs e)
        {
            AgregarAlMdi(FrmAccionesyPermisos.Instance());
        }

        private void btnReporteUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            AgregarAlMdi(FrmReporteUsuarios.Instance());
        }

        private void btnTasaDeCambio_ItemClick(object sender, ItemClickEventArgs e)
        {
            AgregarAlMdi(FrmTasaDeCambio.Instance());
        }

        private void btnAccionesUsuarioReporte_ItemClick(object sender, ItemClickEventArgs e)
        {
            AgregarAlMdi(FrmReporteNavegacion.Instance());
        }

        private void btnDocumentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            AgregarAlMdi(FrmDocumentos.Instance());
        }

        private void btnInformacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarComoDialog(FrmInformacion.Instance());
        }

        private void btnBodegas_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnTipoBodega_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarComoDialog(FrmBodegas.Instance(FrmBodegas.PantallaMostrar.TipoBodega));
        }

        private void btnBodega_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarComoDialog(FrmBodegas.Instance(FrmBodegas.PantallaMostrar.Bodega));
        }

        private void btnBodegasEnDocumentos_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnControlTipoBodega_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        #endregion
    }
}