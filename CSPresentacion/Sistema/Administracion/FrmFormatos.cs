using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSNegocios.Servicios;
using CSPresentacion.Properties;
using CSPresentacion.Sistema.General;
using CSPresentacion.Sistema.Utilidades;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    /// <summary>
    /// Formulario de formatos
    /// </summary>
    public partial class FrmFormatos : XtraForm
    {
        private readonly ServicioFormatos servicio = new ServicioFormatos();

        /// <summary>
        /// Contructor
        /// </summary>
        public FrmFormatos()
        {
            InitializeComponent();
        }

        private void EnviarCorreo()
        {
            try
            {
                MailMessage correo = new MailMessage();
                SmtpClient servidor = new SmtpClient("192.168.0.9");

                servidor.Port = 25;

                correo.From = new MailAddress("admin@elhalcon.com.ni");

                correo.To.Add("agaitan@elhalcon.com.ni");
                correo.Subject = "Cumpleañeros";
                //correo.CC.Add("informatica@elhalcon.com.ni");

                string cuerpo = servicio.ObtenerFormato();

                correo.Body = cuerpo;
                correo.IsBodyHtml = true;

                servidor.Credentials = new NetworkCredential("admin@elhalcon.com.ni", "e8ad1bHjr");
                servidor.EnableSsl = false;

                servidor.SendAsync(correo, null);

                servidor.SendCompleted += (s, args) =>
                {
                    alertControl.Show(this, "Correo enviado con exito", "Se envió el correo al destinatario",
                        Resources.adjuntar);
                };
            }
            catch (Exception ex)
            {
                UIHelper.MostrarError(ex);
            }
        }

        private void MostrarFelicitacion()
        {
            string nombreDelArchivo = Path.GetTempPath() + "Felicidades.html";

            File.WriteAllText(nombreDelArchivo,servicio.ObtenerFormato());

            System.Diagnostics.Process.Start(nombreDelArchivo);

            //webBrowser1.DocumentText = servicio.ObtenerFormato();
        }

        private void FrmFormatos_Load(object sender, EventArgs e)
        {
            MostrarFelicitacion();
        }
    }
}