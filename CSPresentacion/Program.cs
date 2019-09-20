using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
                
            }

            BonusSkins.Register();

            UserLookAndFeel defaultLF = UserLookAndFeel.Default;
            
            defaultLF.UseWindowsXPTheme = false;
            defaultLF.Style = LookAndFeelStyle.Skin;
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            if (Properties.Settings.Default.Recordar == true)
            {
                defaultLF.SkinName = Properties.Settings.Default.UserSkin;
                defaultLF.SetSkinStyle("The Bezier", Properties.Settings.Default.UserPalette);
            }
            else
            {
                defaultLF.SetSkinStyle("The Bezier", "The Bezier");
            }


           
            FrmLogin frm = new FrmLogin();

            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
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
}
