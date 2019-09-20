using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CSNegocios;
using CSPresentacion.Sistema.Administracion;
using CSPresentacion.Sistema.General;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraBars.Ribbon;

namespace CSPresentacion
{
    /// <summary>
    /// Formulario principal
    /// </summary>
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private bool preguntarSucursal = false;

        private static List<string> lstDePantallas = new List<string>()
        {
            "Usuarios",
            "Administracióndesistemas"
        };


        /// <summary>
        /// Constructor
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }


        #region Funciones

        /// <summary>
        /// Agrega al MDI el formulario correspindiente
        /// </summary>
        /// <param name="form">Formulario</param>
        private void AgregarAlMdi(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// Mostrar manual de usuario
        /// </summary>
        private void MostrarManualDeUsuario()
        {
            string path = Application.StartupPath;

            path = path + "\\manual" + "\\" + "manual.pdf";

            FrmPdfViewer frmPdfViewer = new FrmPdfViewer();

            frmPdfViewer.CargarDocumento(path);
            frmPdfViewer.WindowState = FormWindowState.Maximized;
            frmPdfViewer.Icon = this.Icon;
            frmPdfViewer.Text = "Manual de usuario";
            frmPdfViewer.ShowDialog();
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
            if (Properties.Settings.Default.Recordar == true)
            {
                Properties.Settings.Default.UserPalette = UserLookAndFeel.Default.ActiveSvgPaletteName;
                Properties.Settings.Default.Save();
            }

            OperacionesGlobal.EjecutarConsulta("update halcon.dbo.usuarios set Paleta = '" +
                                               UserLookAndFeel.Default.ActiveSvgPaletteName + "' where Usuario = '" +
                                               Datos_Globales.Usuario + "'");
        }

        private void skinPaletteRibbonGalleryBarItem1_GalleryItemClick(object sender,
            DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            if (Properties.Settings.Default.Recordar == true)
            {
                Properties.Settings.Default.UserPalette = e.Item.Value.ToString();
                Properties.Settings.Default.Save();
            }

            OperacionesGlobal.EjecutarConsulta("update halcon.dbo.usuarios set Paleta = '" + e.Item.Value.ToString() +
                                               "' where Usuario = '" + Datos_Globales.Usuario + "'");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            IniciarMain();
        }

        private void IniciarMain()
        {
            int n = OperacionesGlobal.numGet_Int("select halcon.[dbo].[fxObtenerUsuarioEmpresas]('" +
                                                 Datos_Globales.Usuario + "') AS n");

            UIHelper.ValidarPantallas(lstDePantallas, rpModulos,
                new string[] {"Reportes", "Importaciones en transito"});

            if (preguntarSucursal)
            {
                switch (n)
                {
                    case 0:
                        XtraMessageBox.Show("Este usuario no tiene Sucursales Asociadas");
                        this.Close();
                        break;

                    case 1:
                        Datos_Globales.IdSucursal = OperacionesGlobal.numGet_Int(
                            "select halcon.[dbo].[fxObtenerUsuarioIDEmpresa]('" + Datos_Globales.Usuario + "')");
                        Datos_Globales.NombreSucursal = OperacionesGlobal.strGet_String(
                            "select halcon.[dbo].[fxObtenerNombreSucursal](" + Datos_Globales.IdSucursal.ToString() +
                            ") as Sucursal", "Halcon");


                        break;

                    default:
                        FrmSucursales frm = new FrmSucursales();
                        frm.ShowDialog();
                        if (frm.DialogResult != DialogResult.OK)
                            this.Close();
                        break;
                }

                this.barSucursal.Caption = "Sucursal: " + Datos_Globales.NombreSucursal;
                this.barSucursal.Visibility = BarItemVisibility.Always;

                Datos_Globales.ID_Empresa = Datos_Globales.IdSucursal.ToString();
            }
            else
            {
                this.barSucursal.Visibility = BarItemVisibility.Never;
                Datos_Globales.IdSucursal = -1;
                Datos_Globales.ID_Empresa = null;
                Datos_Globales.NombreSucursal = null;
            }

            this.barUsuario.Caption = "Usuario: " + Datos_Globales.Usuario;
            this.barLogin.Caption = "ID: " + Datos_Globales.IdLogin.ToString();
            this.barTC.Caption = "TC: " + OperacionesGlobal.Obtener_TC();
            this.barVersion.Caption = "Version: " + Datos_Globales.VersionSistemaLocal;
            //**********Parte nueva************/
            this.barIP.Caption = "IP: " + Datos_Globales.IPLocal;

            if (Datos_Globales.NombreSucursal != null)
            {
                this.Text = "Sistema de administración, " + Datos_Globales.NombreSucursal;
            }
            else
            {
                this.Text = "Sistema de administración";
            }
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
            this.MdiChildren.ToList().ForEach(x => x.Close());

            if (!MdiChildren.Any())
            {
                this.Hide();

                if (new FrmLogin().ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        UIHelper.ResetearModulo(rpModulos);

                        this.Show();

                        IniciarMain();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                else
                {
                    Application.Exit();
                }
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
                AgregarAlMdi(FrmAdministracionDeSistema.Instance());
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }
        #endregion

    }
}