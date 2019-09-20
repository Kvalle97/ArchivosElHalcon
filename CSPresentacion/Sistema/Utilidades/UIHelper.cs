using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CSNegocios;
using CSNegocios.Global;
using CSPresentacion.Properties;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.General.Buscador;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;

namespace CSPresentacion.Sistema.Utilidades
{
    /// <summary>
    /// Clase de ayuda para el control de UI
    /// </summary>
    public class UIHelper
    {
        private static bool enviarCorreo = false;

        /// <summary>
        /// Iniciar Spin Edit
        /// </summary>
        /// <param name="edits"></param>
        public static void InciarSpinEdits(params SpinEdit[] edits)
        {
            foreach (SpinEdit spin in edits)
            {
                spin.Value = 0;
            }
        }

        /// <summary>
        /// Validar Spin Edit
        /// </summary>
        /// <param name="dxErrorProvider"></param>
        /// <param name="edits"></param>
        /// <returns></returns>
        public static bool ValidarSpinEdits(DXErrorProvider dxErrorProvider, params SpinEdit[] edits)
        {
            foreach (SpinEdit spin in edits)
            {
                if (spin.Value <= 0)
                {
                    UIHelper.AlertarDeError(dxErrorProvider, spin, "El dato no es valido");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Guarda un archivo de invio de correo, con problemas u errores ocurridos
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
                    binaryWriter.Write(System.Text.Encoding.UTF8.GetBytes("X-Unsent: 1" + Environment.NewLine));
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
                    new object[] {mailWriter, true, true}, null);

                // Finally get reflection info for Close() method on our MailWriter
                var closeMethod = mailWriter.GetType()
                    .GetMethod("Close", BindingFlags.Instance | BindingFlags.NonPublic);

                // Call close method
                closeMethod.Invoke(mailWriter, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { },
                    null);
            }
        }

        /// <summary>
        /// Envia un correo de notificacion, con el archivo tipo correo guardado.
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

            mailMessage.Subject = "Error en el sistema de importaciones, " + tiempo;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<span style='font-size: 12pt; color: red;'>Error del sistema: </span>" + mensajeCorto +
                               "<br/><br/><span style='font-weight: bold; color: black;'>Correo generado por el sistema </span>";

            mailMessage.Attachments.Add(new Attachment(log));
            mailMessage.Attachments.Add(new Attachment(captura));

            string direcotorio = "C:\\HalconLogs\\Importaciones\\Correos\\";

            if (!Directory.Exists(direcotorio))
            {
                Directory.CreateDirectory(direcotorio);
            }

            string filename = direcotorio + "reporte.eml";

            //save the MailMessage to the filesystem
            GuardarCorreoDeReporteDeProblema(mailMessage, filename);

            //Open the file with the default associated application registered on the local machine
            Process.Start(filename);
        }

        /// <summary>
        /// Muestra la excepción al usuario.
        /// </summary>
        /// <param name="e"></param>
        public static void MostrarError(Exception e)
        {
            string folder = "C:\\HalconLogs\\"+ Datos_Globales.Sistema + "\\";

            string tiempo = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            string tiempoFileName = DateTime.Now.ToFileTime().ToString();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string nombreDelArchivo =
                folder + "log_" + tiempoFileName + ".txt";

            string[] lineas =
            {
                "Message:" + e.Message,
                "Source:" + e.Source,
                "Stack Trace:" + e.StackTrace,
                "Time:" + tiempo,
                "Computadora: " + Datos_Globales.PC,
                "IdLogin: " + Datos_Globales.IdLogin.ToString(),
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
                        "Ocurrio el siguiente error: '" + e.ToString() + "', " +
                        "<color=red>¿ Desea enviar un correo para notificarlo ? </color>",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button2, DefaultBoolean.True
                    ) == DialogResult.Yes)
                {
                    EnviarCorreoDeNotificacion(tiempo, nombreDelArchivo, captura, e.Message);
                }
            }
            else
            {
                string mensaje = "";

                if (e is SqlException)
                {
                    mensaje = e.Message;
                }
                else
                {
                    mensaje = e.ToString();
                }


                AlertarDeError("Ocurrio el siguiente error: '" + mensaje + "', notifique al administrador.");
            }
        }

        /// <summary>
        /// Obtener Periodo Actual
        /// </summary>
        /// <returns></returns>
        public static int ObtenerPeriodoActual()
        {
            DateTime now = DateTime.Now;

            //return 2013 * 12 + 8;
            return now.Year * 12 + now.Month;
        }

        /// <summary>
        /// Obtener Periodo Actual
        /// </summary>
        /// <param name="dateTime">Fecha</param>
        /// <returns></returns>
        public static int ObtenerPeriodo(DateTime dateTime)
        {
            return dateTime.Year * 12 + dateTime.Month;
        }

        /// <summary>
        /// Enable Components
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="components"></param>
        public static void EnableComponents(bool enable, params Control[] components)
        {
            foreach (Control control in components)
            {
                control.Enabled = enable;
            }
        }

        /// <summary>
        /// Show Components
        /// </summary>
        /// <param name="show"></param>
        /// <param name="components"></param>
        public static void ShowComponents(bool show, params Control[] components)
        {
            foreach (Control control in components)
            {
                control.Visible = show;
            }
        }

        /// <summary>
        /// Obtener Imagen
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
        /// Obtener Imagen O Archivo
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
        /// Agregar Imagen
        /// </summary>
        /// <param name="pictureEdit"></param>
        /// <param name="image"></param>
        public static void AgregarImagen(PictureEdit pictureEdit, byte[] image)
        {
            if (image == null)
            {
                pictureEdit.Image = Resources.LOGO_en_BMP;
            }
            else
            {
                MemoryStream memorySteStream = new MemoryStream(image);

                pictureEdit.Image = Image.FromStream(memorySteStream);
            }
        }

        /// <summary>
        /// Alerta de error
        /// </summary>
        /// <param name="errorProvider"></param>
        /// <param name="control"></param>
        /// <param name="mensaje"></param>
        public static void AlertarDeError(DXErrorProvider errorProvider, Control control, string mensaje)
        {
            errorProvider.SetError(control, mensaje);

            XtraMessageBox.Show(mensaje, "",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            control.Select();
        }

        /// <summary>
        /// Alerta de error
        /// </summary>
        /// <param name="errorProvider"></param>
        /// <param name="control"></param>
        /// <param name="mensaje"></param>
        public static DialogResult AlertarDeErrorConfirm(DXErrorProvider errorProvider, Control control, string mensaje)
        {
            errorProvider.SetError(control, mensaje);

            control.Select();

            return XtraMessageBox.Show(mensaje, "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Alerta al  usuario de errores de validacion
        /// </summary>
        /// <param name="errorProvider"></param>
        /// <param name="lstErrores"></param>
        public static void AlertarDeError(DXErrorProvider errorProvider, List<Error> lstErrores)
        {
            string mensaje = "Ocurrieron los siguientes errores: \n\n";

            int flag = 1;

            foreach (Error error in lstErrores)
            {
                if (error.ControlAlertar != null)
                {
                    errorProvider.SetError(error.ControlAlertar, error.DescripcionDelError);
                }

                mensaje += Convert.ToString(flag)
                           + " ) " + error.DescripcionDelError + "\n";
                flag++;
            }

            XtraMessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Alerta de error
        /// </summary>
        /// <param name="mensaje"></param>
        public static void AlertarDeError(string mensaje)
        {
            XtraMessageBox.Show(mensaje, "",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Trunca el decimal dado a la precision especifica.
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
        /// Obtiene el peso del archivo.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ObtenerPesoDeArchivo(string fileName)
        {
            string peso = String.Empty;
            decimal pesoDecimal = 0;

            FileInfo fileInfo = new FileInfo(fileName);

            if (fileInfo.Exists)
            {
                if ((fileInfo.Length / 1024) > 1024)
                {
                    pesoDecimal = (Convert.ToDecimal(fileInfo.Length) / 1024) / 1024;

                    pesoDecimal = TruncarDecimal(pesoDecimal, 2);

                    if (pesoDecimal < 10)
                    {
                        peso = "Mayor";
                    }
                    else
                    {
                        peso = pesoDecimal.ToString() + " Mb";
                    }
                }
                else
                {
                    pesoDecimal = (Convert.ToDecimal(fileInfo.Length) / 1024);

                    pesoDecimal = TruncarDecimal(pesoDecimal, 2);

                    return pesoDecimal.ToString() + " Kb";
                }
            }

            return peso;
        }

        /// <summary>
        /// Esta El Archivo Usandose ?
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
                {
                    fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
            }
            catch (Exception e)
            {
                MostrarError(e);
                return true;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return false;
        }

        /// <summary>
        /// Crea un evento que dirige al siguiente control al presionar la tecla enter.
        /// </summary>
        /// <param name="seItems"></param>
        public static void IrAlSiguienteControl(params SpinEdit[] seItems)
        {
            foreach (SpinEdit se in seItems)
            {
                se.KeyUp += (sender, args) =>
                {
                    if (args.KeyCode == Keys.Enter)
                    {
                        SendKeys.Send("{TAB}");
                    }
                };
            }
        }

        /// <summary>
        /// Crea un evento que dirige al siguiente control al presionar la tecla enter.
        /// </summary>
        /// <param name="teItems"></param>
        public static void IrAlSiguienteControl(params TextEdit[] teItems)
        {
            foreach (TextEdit te in teItems)
            {
                te.KeyUp += (sender, args) =>
                {
                    if (args.KeyCode == Keys.Enter)
                    {
                        if (!String.IsNullOrWhiteSpace(te.Text))
                        {
                            SendKeys.Send("{TAB}");
                        }
                    }
                };
            }
        }

        /// <summary>
        /// Convierte un datepicker a periodo, deja seleccionar unicamente el mes y año.
        /// </summary>
        /// <param name="dp"></param>
        public static void ConvertirDatePickerAPeriodPicker(DateEdit dp)
        {
            dp.Properties.VistaCalendarInitialViewStyle =
                DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            dp.Properties.VistaCalendarViewStyle =
                DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            dp.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;

            dp.Properties.Mask.EditMask = "MMMM año yyyy";
            dp.Properties.Mask.MaskType = MaskType.DateTime;
            dp.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        /// <summary>
        /// Validar Pantallas
        /// </summary>
        /// <param name="lstDePantallas">Diccionario de pantallas</param>
        /// <param name="rpModulo">Ribbon Page que tine las pantallas del modulo</param>
        /// <param name="excepciones">Excepciones aplicadas</param>
        public static void ValidarPantallas(List<string> lstDePantallas, RibbonPage rpModulo,
            string[] excepciones = null)
        {
            foreach (RibbonPageGroup rpg in rpModulo.Groups)
            {
                QuitarSiNoTienePermiso(rpg, excepciones, lstDePantallas);
            }
        }

        /// <summary>
        /// Validar Pantallas
        /// </summary>
        /// <param name="lstDePantallas"></param>
        /// <param name="excepciones"></param>
        /// <param name="rpgGroups"></param>
        public static void ValidarPantallas(List<string> lstDePantallas, string[] excepciones = null,
            params RibbonPageGroup[] rpgGroups)
        {
            foreach (RibbonPageGroup rpg in rpgGroups)
            {
                QuitarSiNoTienePermiso(rpg, excepciones, lstDePantallas);
            }
        }

        /// <summary>
        /// Quitar si no tiene permiso
        /// </summary>
        /// <param name="rpg"></param>
        /// <param name="excepciones"></param>
        /// <param name="lstDePantallas"></param>
        private static void QuitarSiNoTienePermiso(RibbonPageGroup rpg, string[] excepciones,
            List<string> lstDePantallas)
        {
            foreach (Object item in rpg.ItemLinks)
            {
                if (item.GetType() == typeof(BarButtonItemLink))
                {
                    BarButtonItemLink btn = item as BarButtonItemLink;

                    if (btn != null)
                    {
                        if (excepciones != null)
                        {
                            if (excepciones.Contains(btn.Caption))
                            {
                                continue;
                            }
                        }

                        if (!lstDePantallas.Contains(SinEspacionEnBlanco(btn.Caption)))
                        {
                            btn.Item.Enabled = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Resetear modulos
        /// </summary>
        /// <param name="rp"></param>
        public static void ResetearModulo(RibbonPage rp)
        {
            foreach (RibbonPageGroup rpg in rp.Groups)
            {
                ResetBotones(rpg);
            }
        }

        /// <summary>
        /// Resetear modulos
        /// </summary>
        /// <param name="coleccion"></param>
        public static void ResetearModulo(params RibbonPageGroup[] coleccion)
        {
            foreach (RibbonPageGroup rpg in coleccion)
            {
                ResetBotones(rpg);
            }
        }

        /// <summary>
        /// Resetea el boton
        /// </summary>
        /// <param name="rpg"></param>
        private static void ResetBotones(RibbonPageGroup rpg)
        {
            List<BarButtonItemLink> aQuitar = new List<BarButtonItemLink>();

            foreach (Object item in rpg.ItemLinks)
            {
                if (item.GetType() == typeof(BarButtonItemLink))
                {
                    BarButtonItemLink btn = item as BarButtonItemLink;

                    if (btn != null)
                    {
                        btn.Item.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sin Espacios en blanco
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string SinEspacionEnBlanco(string original)
        {
            return Regex.Replace(original, @"\s+", "");
        }
    }
}