using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CSPresentacion.Properties;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using ActualizadorHalcon;

namespace CSPresentacion.Sistema.Utilidades
{
    /// <summary>
    ///     Clase de ayuda para el control de UI
    /// </summary>
    public class UIHelper
    {
        private static readonly bool enviarCorreo = false;

        /// <summary>
        ///     Habilita el mostrar cuando no hay actualizaciones nuevas
        /// </summary>
        public static bool MostrarNoHayNuevasActualizaciones { get; set; }

        /// <summary>
        ///     Iniciar Spin Edit
        /// </summary>
        /// <param name="edits"></param>
        public static void InciarSpinEdits(params SpinEdit[] edits)
        {
            foreach (SpinEdit spin in edits) spin.Value = 0;
        }

        /// <summary>
        ///     Validar Spin Edit
        /// </summary>
        /// <param name="dxErrorProvider"></param>
        /// <param name="edits"></param>
        /// <returns></returns>
        public static bool ValidarSpinEdits(DXErrorProvider dxErrorProvider, params SpinEdit[] edits)
        {
            foreach (SpinEdit spin in edits)
                if (spin.Value <= 0)
                {
                    AlertarDeError(dxErrorProvider, spin, "El dato no es valido");
                    return false;
                }

            return true;
        }

        /// <summary>
        ///     Guarda un archivo de invio de correo, con problemas u errores ocurridos
        /// </summary>
        /// <param name="message"></param>
        /// <param name="filename"></param>
        /// <param name="addUnsentHeader"></param>
        private static void GuardarCorreoDeReporteDeProblema(MailMessage message, string filename,
            bool addUnsentHeader = true)
        {
            using (var filestream = File.Open(filename, FileMode.Create))
            {
                if (addUnsentHeader)
                {
                    var binaryWriter = new BinaryWriter(filestream);
                    //Write the Unsent header to the file so the mail client knows this mail must be presented in "New message" mode
                    binaryWriter.Write(Encoding.UTF8.GetBytes("X-Unsent: 1" + Environment.NewLine));
                }

                var assembly = typeof(SmtpClient).Assembly;
                var mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");

                // Get reflection info for MailWriter contructor
                var mailWriterContructor = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                    null, new[] {typeof(Stream)}, null);

                // Construct MailWriter object with our FileStream
                var mailWriter = mailWriterContructor.Invoke(new object[] {filestream});

                // Get reflection info for Send() method on MailMessage
                var sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);

                sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null,
                    new[] {mailWriter, true, true}, null);

                // Finally get reflection info for Close() method on our MailWriter
                var closeMethod = mailWriter.GetType()
                    .GetMethod("Close", BindingFlags.Instance | BindingFlags.NonPublic);

                // Call close method
                closeMethod.Invoke(mailWriter, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { },
                    null);
            }
        }

        /// <summary>
        ///     Envia un correo de notificacion, con el archivo tipo correo guardado.
        /// </summary>
        /// <param name="tiempo"></param>
        /// <param name="log"></param>
        /// <param name="captura"></param>
        /// <param name="mensajeCorto"></param>
        private static void EnviarCorreoDeNotificacion(string tiempo, string log, string captura, string mensajeCorto)
        {
            MailMessage mailMessage = new MailMessage(Datos_Globales.Correo,
                "agaitan@elhalcon.com.ni");

            mailMessage.To.Add("informatica@elhalcon.com.ni");

            mailMessage.Subject = "Error en el sistema de administracion, " + tiempo;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<span style='font-size: 12pt; color: red;'>Error del sistema: </span>" + mensajeCorto +
                               "<br/><br/><span style='font-weight: bold; color: black;'>Correo generado por el sistema </span>";

            mailMessage.Attachments.Add(new Attachment(log));
            mailMessage.Attachments.Add(new Attachment(captura));

            string direcotorio = "C:\\HalconLogs\\Administracion\\Correos\\";

            if (!Directory.Exists(direcotorio)) Directory.CreateDirectory(direcotorio);

            string filename = direcotorio + "reporte.eml";

            //save the MailMessage to the filesystem
            GuardarCorreoDeReporteDeProblema(mailMessage, filename);

            //Open the file with the default associated application registered on the local machine
            Process.Start(filename);
        }

        /// <summary>
        ///     Muestra la excepción al usuario.
        /// </summary>
        /// <param name="e"></param>
        public static void MostrarError(Exception e)
        {
            string folder = "C:\\HalconLogs\\Administracion\\";

            string tiempo = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            string tiempoFileName = DateTime.Now.ToFileTime().ToString();
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string nombreDelArchivo =
                folder + "log_" + tiempoFileName + ".txt";

            string[] lineas =
            {
                "Message:" + e.Message,
                "Source:" + e.Source,
                "Stack Trace:" + e.StackTrace,
                "Time:" + tiempo,
                "Computadora: " + Datos_Globales.PC,
                "IdLogin: " + Datos_Globales.IdLogin,
                "Usuario: " + Datos_Globales.Usuario,
                "Versión del sistema: " + Datos_Globales.VersionSistemaLocal,
                "Ip: " + Datos_Globales.IPLocal
            };

            File.WriteAllLines(nombreDelArchivo, lineas);

            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();

            string captura = folder + "capture_" + tiempoFileName + ".png";

            sc.CaptureScreenToFile(captura, ImageFormat.Png);

            if (Datos_Globales.Correo != null && enviarCorreo)
            {
                if (XtraMessageBox.Show(
                        "Ocurrio el siguiente error: '" + e + "', " +
                        "<color=red>¿ Desea enviar un correo para notificarlo ? </color>",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button2, DefaultBoolean.True
                    ) == DialogResult.Yes)
                    EnviarCorreoDeNotificacion(tiempo, nombreDelArchivo, captura, e.Message);
            }
            else
            {
                string mensaje = "";

                if (e is SqlException)
                    mensaje = e.Message;
                else
                    mensaje = e.ToString();


                AlertarDeError("Ocurrio el siguiente error: '" + mensaje + "', notifique al administrador.");
            }
        }

        /// <summary>
        ///     Obtener Periodo Actual
        /// </summary>
        /// <returns></returns>
        public static int ObtenerPeriodoActual()
        {
            DateTime now = DateTime.Now;

            //return 2013 * 12 + 8;
            return now.Year * 12 + now.Month;
        }

        /// <summary>
        ///     Obtener Periodo Actual
        /// </summary>
        /// <param name="dateTime">Fecha</param>
        /// <returns></returns>
        public static int ObtenerPeriodo(DateTime dateTime)
        {
            return dateTime.Year * 12 + dateTime.Month;
        }

        /// <summary>
        ///     Enable Components
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="components"></param>
        public static void EnableComponents(bool enable, params Control[] components)
        {
            foreach (Control control in components) control.Enabled = enable;
        }

        /// <summary>
        ///     Show Components
        /// </summary>
        /// <param name="show"></param>
        /// <param name="components"></param>
        public static void ShowComponents(bool show, params Control[] components)
        {
            foreach (Control control in components) control.Visible = show;
        }

        /// <summary>
        ///     Obtener Imagen
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ObtenerImagen(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, image.RawFormat);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        ///     Obtener Imagen O Archivo
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static byte[] ObtenerImagenOArchivo(string file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (FileStream fileStream =
                    new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    memoryStream.SetLength(fileStream.Length);
                    fileStream.Read(memoryStream.GetBuffer(), 0, (int) fileStream.Length);

                    byte[] image = memoryStream.GetBuffer();

                    memoryStream.Flush();
                    fileStream.Close();

                    return image;
                }
            }
        }

        /// <summary>
        ///     Agregar Imagen
        /// </summary>
        /// <param name="pictureEdit"></param>
        /// <param name="image"></param>
        public static void AgregarImagen(PictureEdit pictureEdit, byte[] image)
        {
            if (image == null)
            {
                pictureEdit.Image = null;
            }
            else
            {
                MemoryStream memorySteStream = new MemoryStream(image);

                pictureEdit.Image = Image.FromStream(memorySteStream);
            }
        }

        /// <summary>
        ///     Alerta de error
        /// </summary>
        /// <param name="errorProvider"></param>
        /// <param name="control"></param>
        /// <param name="mensaje"></param>
        public static void AlertarDeError(DXErrorProvider errorProvider, Control control, string mensaje)
        {
            errorProvider.SetError(control, mensaje);

            XtraMessageBox.Show(mensaje, "",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            control.Select();
        }

        /// <summary>
        ///     Alerta de error
        /// </summary>
        /// <param name="errorProvider"></param>
        /// <param name="control"></param>
        /// <param name="mensaje"></param>
        public static DialogResult AlertarDeErrorConfirm(DXErrorProvider errorProvider, Control control, string mensaje)
        {
            errorProvider.SetError(control, mensaje);

            control.Select();

            return XtraMessageBox.Show(mensaje, "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        /// <summary>
        ///     Alerta al  usuario de errores de validacion
        /// </summary>
        /// <param name="errorProvider"></param>
        /// <param name="lstErrores"></param>
        public static void AlertarDeError(DXErrorProvider errorProvider, List<Error> lstErrores)
        {
            string mensaje = "Ocurrieron los siguientes problemas: \n\n";

            int flag = 1;

            foreach (Error error in lstErrores)
            {
                if (error.ControlAlertar != null)
                    errorProvider.SetError(error.ControlAlertar, error.DescripcionDelError);

                mensaje += Convert.ToString(flag)
                           + " ) " + error.DescripcionDelError + "\n";
                flag++;
            }

            XtraMessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        ///     Alerta de error
        /// </summary>
        /// <param name="mensaje"></param>
        public static void AlertarDeError(string mensaje)
        {
            XtraMessageBox.Show(mensaje, "",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        /// <summary>
        ///     Trunca el decimal dado a la precision especifica.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static decimal TruncarDecimal(decimal value, int precision)
        {
            decimal step = (decimal) Math.Pow(10, precision);
            int tmp = (int) Math.Truncate(step * value);
            return tmp / step;
        }

        /// <summary>
        ///     Obtiene el peso del archivo.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ObtenerPesoDeArchivo(string fileName)
        {
            string peso = string.Empty;
            decimal pesoDecimal = 0;

            FileInfo fileInfo = new FileInfo(fileName);

            if (fileInfo.Exists)
            {
                if (fileInfo.Length / 1024 > 1024)
                {
                    pesoDecimal = Convert.ToDecimal(fileInfo.Length) / 1024 / 1024;

                    pesoDecimal = TruncarDecimal(pesoDecimal, 2);

                    if (pesoDecimal < 10)
                        peso = "Mayor";
                    else
                        peso = pesoDecimal.ToString(CultureInfo.InvariantCulture) + " Mb";
                }
                else
                {
                    pesoDecimal = Convert.ToDecimal(fileInfo.Length) / 1024;

                    pesoDecimal = TruncarDecimal(pesoDecimal, 2);

                    return pesoDecimal + " Kb";
                }
            }

            return peso;
        }

        /// <summary>
        ///     Esta El Archivo Usandose ?
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool EstaElArchivoUsandose(string path)
        {
            FileStream fileStream = null;

            try
            {
                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Exists)
                    fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (Exception e)
            {
                MostrarError(e);
                return true;
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
            }

            return false;
        }

        /// <summary>
        ///     Crea un evento que dirige al siguiente control al presionar la tecla enter.
        /// </summary>
        /// <param name="seItems"></param>
        public static void IrAlSiguienteControl(params SpinEdit[] seItems)
        {
            foreach (SpinEdit se in seItems)
                se.KeyUp += (sender, args) =>
                {
                    if (args.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
                };
        }

        /// <summary>
        ///     Crea un evento que dirige al siguiente control al presionar la tecla enter.
        /// </summary>
        /// <param name="teItems"></param>
        public static void IrAlSiguienteControl(params TextEdit[] teItems)
        {
            foreach (TextEdit te in teItems)
                te.KeyUp += (sender, args) =>
                {
                    if (args.KeyCode == Keys.Enter)
                        if (!string.IsNullOrWhiteSpace(te.Text))
                            SendKeys.Send("{TAB}");
                };
        }

        /// <summary>
        ///     Convierte un datepicker a periodo, deja seleccionar unicamente el mes y año.
        /// </summary>
        /// <param name="dp"></param>
        public static void ConvertirDatePickerAPeriodPicker(DateEdit dp)
        {
            dp.Properties.VistaCalendarInitialViewStyle =
                VistaCalendarInitialViewStyle.YearView;
            dp.Properties.VistaCalendarViewStyle =
                VistaCalendarViewStyle.YearView;
            dp.Properties.VistaDisplayMode = DefaultBoolean.True;

            dp.Properties.Mask.EditMask = "MMMM año yyyy";
            dp.Properties.Mask.MaskType = MaskType.DateTime;
            dp.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        /// <summary>
        ///     Regresa una descripcion del periodo
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ObtenerDescripcionDelPeriodo(DateTime dt)
        {
            return dt.ToString("MMMM yyyy").ToUpper();
        }

        /// <summary>
        ///     Validar Pantallas
        /// </summary>
        /// <param name="lstDePantallas">Diccionario de pantallas</param>
        /// <param name="rpModulo">Ribbon Page que tine las pantallas del modulo</param>
        /// <param name="excepciones">Excepciones aplicadas</param>
        public static void ValidarPantallas(List<string> lstDePantallas, RibbonPage rpModulo,
            string[] excepciones = null)
        {
            foreach (RibbonPageGroup rpg in rpModulo.Groups) QuitarSiNoTienePermiso(rpg, excepciones, lstDePantallas);
        }

        /// <summary>
        ///     Validar Pantallas
        /// </summary>
        /// <param name="lstDePantallas"></param>
        /// <param name="excepciones"></param>
        /// <param name="rpgGroups"></param>
        public static void ValidarPantallas(List<string> lstDePantallas, string[] excepciones = null,
            params RibbonPageGroup[] rpgGroups)
        {
            foreach (RibbonPageGroup rpg in rpgGroups) QuitarSiNoTienePermiso(rpg, excepciones, lstDePantallas);
        }

        /// <summary>
        ///     Quitar si no tiene permiso
        /// </summary>
        /// <param name="rpg"></param>
        /// <param name="excepciones"></param>
        /// <param name="lstDePantallas"></param>
        private static void QuitarSiNoTienePermiso(RibbonPageGroup rpg, string[] excepciones,
            List<string> lstDePantallas)
        {
            foreach (object item in rpg.ItemLinks)
                if (item.GetType() == typeof(BarButtonItemLink))
                {
                    BarButtonItemLink btn = item as BarButtonItemLink;

                    if (btn != null)
                    {
                        if (excepciones != null)
                            if (excepciones.Contains(btn.Caption))
                                continue;

                        if (!lstDePantallas.Contains(SinEspacionEnBlanco(btn.Caption), StringComparer.OrdinalIgnoreCase)
                        ) btn.Item.Enabled = false;
                    }
                }
        }

        /// <summary>
        ///     Resetear modulos
        /// </summary>
        /// <param name="rp"></param>
        public static void ResetearModulo(RibbonPage rp)
        {
            foreach (RibbonPageGroup rpg in rp.Groups) ResetBotones(rpg);
        }

        /// <summary>
        ///     Resetear modulos
        /// </summary>
        /// <param name="coleccion"></param>
        public static void ResetearModulo(params RibbonPageGroup[] coleccion)
        {
            foreach (RibbonPageGroup rpg in coleccion) ResetBotones(rpg);
        }

        /// <summary>
        ///     Resetea el boton
        /// </summary>
        /// <param name="rpg"></param>
        private static void ResetBotones(RibbonPageGroup rpg)
        {
            List<BarButtonItemLink> aQuitar = new List<BarButtonItemLink>();

            foreach (object item in rpg.ItemLinks)
                if (item.GetType() == typeof(BarButtonItemLink))
                {
                    BarButtonItemLink btn = item as BarButtonItemLink;

                    if (btn != null) btn.Item.Enabled = true;
                }
        }

        /// <summary>
        ///     Sin Espacios en blanco
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string SinEspacionEnBlanco(string original)
        {
            return Regex.Replace(original, @"\s+", "");
        }

        /// <summary>
        ///     Crea el evento para ver las actualizaciones
        /// </summary>
        public static void CrearEventoDeActualizacion()
        {
            AutoUpdater.CheckForUpdateEvent += args =>
            {
                if (args != null)
                {
                    if (args.IsUpdateAvailable)
                    {
                        DialogResult dialogResult;
                        if (args.Mandatory)
                            dialogResult =
                                XtraMessageBox.Show(
                                    $@"Hay una nueva versión del sistema disponible ({args.CurrentVersion}). Usted está usando la versión ({args.InstalledVersion}). Presiona OK para actualizar.",
                                    @"Actualización disponible",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        else
                            dialogResult =
                                XtraMessageBox.Show(
                                    $@"Hay una nueva versión del sistema disponible ({args.CurrentVersion}). 
Usted está usando la versión ({args.InstalledVersion}). ¿ Quiere actualizar ahora ?",
                                    @"Actualización disponible",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information);

                        // Uncomment the following line if you want to show standard update dialog instead.
                        // AutoUpdater.ShowUpdateForm();

                        if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                            try
                            {
                                AutoUpdater.DownloadUpdate();
                                Application.Exit();
                            }
                            catch (Exception exception)
                            {
                                XtraMessageBox.Show(exception.Message, exception.GetType().ToString(),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                    }
                    else if (MostrarNoHayNuevasActualizaciones)
                    {
                        XtraMessageBox.Show(@"No hay ninguna actualización disponible",
                            @"No hay actualizaciones nuevas.",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MostrarNoHayNuevasActualizaciones = false;
                    }
                }
                else
                {
                    XtraMessageBox.Show(
                        @"No hemos podido buscar actualizaciones, revisa tu conección a internet e intetalo de nuevo más tarde",
                        @"Fallo en busqueda de actualizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        /// <summary>
        ///     Buscar actualizaciones
        /// </summary>
        public static void BuscarActualizaciones()
        {
            AutoUpdater.Start("https://gitlab.com/sistemas-halc-n/archivos-json/raw/master/Administracion.xml");
        }

        /// <summary>
        ///     Realiza una pregunta con respuesta de si o no
        /// </summary>
        /// <param name="pregunta"></param>
        /// <returns></returns>
        public static DialogResult PreguntarSn(string pregunta)
        {
            return XtraMessageBox.Show(pregunta, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        ///     Convertir Data Table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertirDataTable<T>(DataTable dt)
        {
            return (from DataRow row in dt.Rows select ObtenerItem<T>(row)).ToList();
        }

        /// <summary>
        /// Convertir DataTable A Lista Simple
        /// </summary>
        /// <typeparam name="T">Tipo de dato</typeparam>
        /// <param name="dt">Data table</param>
        /// <param name="nombreDeColumna">Nombre de la columna a cambiar</param>
        /// <returns></returns>
        public static List<T> ConvertirDataTableAListaSimple<T>(DataTable dt, string nombreDeColumna)
        {
            if (!typeof(T).IsPrimitive) throw new Exception("Solo datos primitivos :)");
            return dt.Rows.OfType<DataRow>().Select(dr => dr.Field<T>(nombreDeColumna)).ToList();
        }

        /// <summary>
        ///     Obtener item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ObtenerItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            if (dr == null) return obj;

            foreach (DataColumn column in dr.Table.Columns)
            {
                PropertyInfo prop = temp.GetProperties()
                    .FirstOrDefault(x => string.Equals(x.Name, SinEspacionEnBlanco(column.ColumnName),
                        StringComparison.CurrentCultureIgnoreCase));

                if (prop == null) continue;
                prop.SetValue(obj, dr[column.ColumnName] is DBNull ? null : dr[column.ColumnName], null);
            }

            return obj;
        }
        /// <summary>
        /// Crea una contrasenia
        /// </summary>
        /// <param name="largo"></param>
        /// <returns></returns>
        public static string CrearContrasenia(int largo)
        {
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@$?";
            Byte[] randomBytes = new Byte[largo];
            char[] chars = new char[largo];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < largo; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }
    }
}