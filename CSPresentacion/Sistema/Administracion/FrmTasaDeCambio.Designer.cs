namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmTasaDeCambio
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
            this.gcTasas = new DevExpress.XtraGrid.GridControl();
            this.gvTasas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.seTc = new DevExpress.XtraEditors.SpinEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.seTcGerencial = new DevExpress.XtraEditors.SpinEdit();
            this.dpFecha = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCargarExcel = new DevExpress.XtraEditors.SimpleButton();
            this.rgContableOHalcon = new DevExpress.XtraEditors.RadioGroup();
            this.ckSobreeEscribir = new DevExpress.XtraEditors.CheckEdit();
            this.btnObtenerTasaDelaFecha = new DevExpress.XtraEditors.SimpleButton();
            this.btnTodoElMesFecha = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcTasas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTcGerencial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgContableOHalcon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckSobreeEscribir.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTasas
            // 
            this.gcTasas.Location = new System.Drawing.Point(12, 129);
            this.gcTasas.MainView = this.gvTasas;
            this.gcTasas.Name = "gcTasas";
            this.gcTasas.Size = new System.Drawing.Size(777, 276);
            this.gcTasas.TabIndex = 4;
            this.gcTasas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTasas});
            // 
            // gvTasas
            // 
            this.gvTasas.GridControl = this.gcTasas;
            this.gvTasas.Name = "gvTasas";
            this.gvTasas.OptionsBehavior.Editable = false;
            this.gvTasas.OptionsView.ShowAutoFilterRow = true;
            this.gvTasas.OptionsView.ShowGroupPanel = false;
            this.gvTasas.ViewCaption = "Tasas de cambio";
            // 
            // seTc
            // 
            this.seTc.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTc.Location = new System.Drawing.Point(12, 72);
            this.seTc.Name = "seTc";
            this.seTc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTc.Size = new System.Drawing.Size(140, 20);
            this.seTc.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tasa de cambio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tasas de cambio gerencial";
            // 
            // seTcGerencial
            // 
            this.seTcGerencial.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTcGerencial.Location = new System.Drawing.Point(158, 72);
            this.seTcGerencial.Name = "seTcGerencial";
            this.seTcGerencial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTcGerencial.Size = new System.Drawing.Size(140, 20);
            this.seTcGerencial.TabIndex = 7;
            // 
            // dpFecha
            // 
            this.dpFecha.EditValue = null;
            this.dpFecha.Location = new System.Drawing.Point(304, 72);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFecha.Size = new System.Drawing.Size(140, 20);
            this.dpFecha.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fecha";
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.Location = new System.Drawing.Point(459, 68);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.Size = new System.Drawing.Size(172, 27);
            this.btnCargarExcel.TabIndex = 11;
            this.btnCargarExcel.Text = "Insertar con un archivo excel";
            this.btnCargarExcel.Click += new System.EventHandler(this.btnCargarExcel_Click);
            // 
            // rgContableOHalcon
            // 
            this.rgContableOHalcon.Location = new System.Drawing.Point(15, 98);
            this.rgContableOHalcon.Name = "rgContableOHalcon";
            this.rgContableOHalcon.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Contable"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Halcon")});
            this.rgContableOHalcon.Size = new System.Drawing.Size(283, 25);
            this.rgContableOHalcon.TabIndex = 12;
            this.rgContableOHalcon.SelectedIndexChanged += new System.EventHandler(this.rgContableOHalcon_SelectedIndexChanged);
            // 
            // ckSobreeEscribir
            // 
            this.ckSobreeEscribir.Location = new System.Drawing.Point(304, 101);
            this.ckSobreeEscribir.Name = "ckSobreeEscribir";
            this.ckSobreeEscribir.Properties.Caption = "Sobre escribir si ya existe";
            this.ckSobreeEscribir.Size = new System.Drawing.Size(162, 20);
            this.ckSobreeEscribir.TabIndex = 13;
            // 
            // btnObtenerTasaDelaFecha
            // 
            this.btnObtenerTasaDelaFecha.Location = new System.Drawing.Point(459, 97);
            this.btnObtenerTasaDelaFecha.Name = "btnObtenerTasaDelaFecha";
            this.btnObtenerTasaDelaFecha.Size = new System.Drawing.Size(172, 27);
            this.btnObtenerTasaDelaFecha.TabIndex = 14;
            this.btnObtenerTasaDelaFecha.Text = "Obtener tasa de la fecha";
            this.btnObtenerTasaDelaFecha.Click += new System.EventHandler(this.btnObtenerTasaDelaFecha_Click);
            // 
            // btnTodoElMesFecha
            // 
            this.btnTodoElMesFecha.Location = new System.Drawing.Point(637, 68);
            this.btnTodoElMesFecha.Name = "btnTodoElMesFecha";
            this.btnTodoElMesFecha.Size = new System.Drawing.Size(152, 27);
            this.btnTodoElMesFecha.TabIndex = 15;
            this.btnTodoElMesFecha.Text = "Todo el mes de fecha";
            this.btnTodoElMesFecha.Click += new System.EventHandler(this.btnTodoElMesFecha_Click);
            // 
            // FrmTasaDeCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 417);
            this.Controls.Add(this.btnTodoElMesFecha);
            this.Controls.Add(this.btnObtenerTasaDelaFecha);
            this.Controls.Add(this.ckSobreeEscribir);
            this.Controls.Add(this.rgContableOHalcon);
            this.Controls.Add(this.btnCargarExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seTcGerencial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seTc);
            this.Controls.Add(this.gcTasas);
            this.Name = "FrmTasaDeCambio";
            this.Text = "Tasa de cambio";
            this.Load += new System.EventHandler(this.FrmTasaDeCambio_Load);
            this.Controls.SetChildIndex(this.gcTasas, 0);
            this.Controls.SetChildIndex(this.seTc, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.seTcGerencial, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dpFecha, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnCargarExcel, 0);
            this.Controls.SetChildIndex(this.rgContableOHalcon, 0);
            this.Controls.SetChildIndex(this.ckSobreeEscribir, 0);
            this.Controls.SetChildIndex(this.btnObtenerTasaDelaFecha, 0);
            this.Controls.SetChildIndex(this.btnTodoElMesFecha, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcTasas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTasas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTcGerencial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgContableOHalcon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckSobreeEscribir.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTasas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTasas;
        private DevExpress.XtraEditors.SpinEdit seTc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SpinEdit seTcGerencial;
        private DevExpress.XtraEditors.DateEdit dpFecha;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnCargarExcel;
        private DevExpress.XtraEditors.RadioGroup rgContableOHalcon;
        private DevExpress.XtraEditors.CheckEdit ckSobreeEscribir;
        private DevExpress.XtraEditors.SimpleButton btnObtenerTasaDelaFecha;
        private DevExpress.XtraEditors.SimpleButton btnTodoElMesFecha;
    }
}