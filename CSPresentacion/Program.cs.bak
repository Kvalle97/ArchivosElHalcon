using System;
using System.Windows.Forms;
using CSPresentacion.Properties;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;

namespace CSPresentacion
{
    internal static class Program
    {
        /// <summary>
        ///     Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            BonusSkins.Register();

            UserLookAndFeel defaultLF = UserLookAndFeel.Default;

            defaultLF.UseWindowsXPTheme = false;
            defaultLF.Style = LookAndFeelStyle.Skin;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (Settings.Default.Recordar)
            {
                defaultLF.SkinName = Settings.Default.UserSkin;
                defaultLF.SetSkinStyle("The Bezier", Settings.Default.UserPalette);
            }
            else
            {
                defaultLF.SetSkinStyle("The Bezier", "The Bezier");
            }


            FrmLogin frm = new FrmLogin();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
                try
                {
                    Application.Run(new FrmMain());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }
    }
}