namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmFormatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.SuspendLayout();
            // 
            // FrmFormatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 379);
            this.Name = "FrmFormatos";
            this.Text = "FrmFormatos";
            this.Load += new System.EventHandler(this.FrmFormatos_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
    }
}