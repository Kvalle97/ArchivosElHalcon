using CSPresentacion.Sistema.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using CSNegocios.Modelos;
using CSNegocios.Servicios;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.DataAccess.Native.Excel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario tasa de cambio
    /// </summary>
    public partial class FrmTasaDeCambio : FrmBase
    {
        // ReSharper disable once InconsistentNaming
        private static FrmTasaDeCambio childInstance;
        private readonly ServicioTasaDeCambio servicioTasaDeCambio = new ServicioTasaDeCambio();

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmTasaDeCambio()
        {
            InitializeComponent();
        }

        #region Metodos

        /// <summary>
        /// Nueva instancia
        /// </summary>
        /// <returns></returns>
        public static FrmTasaDeCambio Instance()
        {
            if (childInstance == null || childInstance.IsDisposed)
            {
                childInstance = new FrmTasaDeCambio();

                childInstance.MostrarBotones(true, Opciones.Guardar, Opciones.Nuevo);
            }

            childInstance.BringToFront();

            return childInstance;
        }

        private void CargarTasa()
        {
            try
            {
                if (rgContableOHalcon.SelectedIndex == 1)
                    servicioTasaDeCambio.CargarTasaDeCambioHalcon(gcTasas, gvTasas);
                else
                    servicioTasaDeCambio.CargarTasaDeCambioContable(gcTasas, gvTasas);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void Limpiar()
        {
            seTc.Value = decimal.Zero;
            seTcGerencial.Value = decimal.Zero;
            dpFecha.DateTime = DateTime.Now.Date;
        }

        private void AbrirExcel(string fileName)
        {
            Excel.Application xlApp = new Excel.Application();

            Excel.Workbook xlWorkbook =
                xlApp.Workbooks.Open(fileName);

            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];

            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            if (colCount != 2)
            {
                throw new Exception("El excel de tasa de cambio tiene solo dos columnas");
            }

            List<TasaDeCambioM> lstTasaDeCambio = new List<TasaDeCambioM>();

            // En excel comienza en uno
            // pero agregamos un salto para que omita el encabezado
            for (int filas = 1; filas < rowCount + 1; filas++)
            {
                // Fecha esta en uno
                string fecha = Convert.ToString(xlRange.Cells[filas, 1].Value);
                string tasa = Convert.ToString(xlRange.Cells[filas, 2].Value);


                if (string.IsNullOrWhiteSpace(fecha) || string.IsNullOrWhiteSpace(tasa)) continue;

                decimal.TryParse(tasa, out var tasaVal);

                if (tasaVal == decimal.Zero) continue;

                Console.WriteLine($@"Tasa: {tasaVal}, Fecha: {fecha}");

                DateTime fechaVal = DateTime.Now;

                bool success = DateTime.TryParseExact(fecha, "d/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal, out fechaVal);

                if (!success)
                {
                    DateTime.TryParseExact(fecha, "d/M/yyyy hh:mm:ss", CultureInfo.InvariantCulture,
                        DateTimeStyles.AdjustToUniversal, out fechaVal);
                }

                lstTasaDeCambio.Add(new TasaDeCambioM() {Fecha = fechaVal, TasaDeCambio = tasaVal});
            }

            decimal gerencial =
                lstTasaDeCambio.OrderByDescending(x => x.Fecha).First().TasaDeCambio;

            lstTasaDeCambio.ForEach(x =>
            {
                servicioTasaDeCambio.GuardarTc(x, Datos_Globales.Usuario, gerencial, ckSobreeEscribir.Checked);
            });

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        #endregion

        #region Sobre cargas

        /// <inheritdoc />
        protected override void NuevoEvent()
        {
            Limpiar();
        }

        /// <inheritdoc />
        protected override void GuardarEvent()
        {
            try
            {
                servicioTasaDeCambio.GuardarTc(new TasaDeCambioM()
                    {
                        Fecha = dpFecha.DateTime.Date,
                        TasaDeCambio = seTc.Value
                    }, Datos_Globales.Usuario, seTcGerencial.Value,
                    ckSobreeEscribir.Checked);

                XtraMessageBox.Show("Guardado");
            }
            catch (Exception e)
            {
                UIHelper.MostrarError(e);
            }
        }

        #endregion

        #region Eventos

        private void FrmTasaDeCambio_Load(object sender, EventArgs e)
        {
            CargarTasa();

            Limpiar();
        }

        private void rgContableOHalcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTasa();
        }


        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                // ReSharper disable once LocalizableElement
                Filter = "Excel files(*.xls; *.xlsx;)|*.xls; *.xlsx;"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string avisoDeSobreEscritura = ckSobreeEscribir.Checked ? "se sobreescribira" : "se ignorara";

                if (
                    UIHelper.PreguntarSn(
                        "Está apunto de insertar las tasas" +
                        $" de cambio que hay en el Excel. Si hay una repetida {avisoDeSobreEscritura} ¿ Desea continuar ?") ==
                    DialogResult.Yes)
                {
                    WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Guardando");

                    wait.Show();

                    try
                    {
                        AbrirExcel(openFileDialog.FileName);

                        wait.Close();

                        XtraMessageBox.Show("Listo :)");
                    }
                    catch (Exception exception)
                    {
                        if (!wait.IsDisposed) wait.Close();
                        UIHelper.MostrarError(exception);
                    }
                }
            }
        }

        private void btnObtenerTasaDelaFecha_Click(object sender, EventArgs e)
        {
            try
            {
                seTc.Value = servicioTasaDeCambio.ConsultarTcDelDia(dpFecha.DateTime);
            }
            catch (Exception exception)
            {
                UIHelper.MostrarError(exception);
            }
        }

        private void btnTodoElMesFecha_Click(object sender, EventArgs e)
        {
            string avisoDeSobreEscritura = ckSobreeEscribir.Checked ? "se sobreescribira" : "se ignorara";

            if (
                UIHelper.PreguntarSn(
                    "Está apunto de insertar las tasas" +
                    $" que se obtengan del servicio del banco central. Si hay una repetida {avisoDeSobreEscritura} ¿ Desea continuar ?") ==
                DialogResult.Yes)
            {
                WaitDialogForm wait = new WaitDialogForm("Por favor espere...", "Guardando tasas de cambio");

                wait.Show();

                try
                {
                    servicioTasaDeCambio.InsertarTcDelMes(dpFecha.DateTime, ckSobreeEscribir.Checked,
                        Datos_Globales.Usuario);

                    wait.Close();

                    XtraMessageBox.Show("Listo :)");
                }
                catch (Exception exception)
                {
                    if (!wait.IsDisposed) wait.Close();
                    UIHelper.MostrarError(exception);
                }
            }
        }

        #endregion
    }
}