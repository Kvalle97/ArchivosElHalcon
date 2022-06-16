using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace CSPresentacion.Sistema.General.Buscador
{
    partial class FrmBuscador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscador));
            this.groupParametros = new DevExpress.XtraEditors.GroupControl();
            this.xscParametros = new DevExpress.XtraEditors.XtraScrollableControl();
            this.dp2 = new DevExpress.XtraEditors.DateEdit();
            this.dp3 = new DevExpress.XtraEditors.DateEdit();
            this.dp1 = new DevExpress.XtraEditors.DateEdit();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtFiltro3 = new DevExpress.XtraEditors.TextEdit();
            this.lueFiltro3 = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFiltro3 = new System.Windows.Forms.Label();
            this.txtFiltro2 = new DevExpress.XtraEditors.TextEdit();
            this.txtFiltro1 = new DevExpress.XtraEditors.TextEdit();
            this.lueDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSucursal = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcBuscador = new DevExpress.XtraGrid.GridControl();
            this.gvBuscador = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupParametros)).BeginInit();
            this.groupParametros.SuspendLayout();
            this.xscParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dp2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp3.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltro3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFiltro3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltro2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltro1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSucursal.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBuscador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBuscador)).BeginInit();
            this.SuspendLayout();
            // 
            // groupParametros
            // 
            this.groupParametros.Controls.Add(this.xscParametros);
            this.groupParametros.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupParametros.Location = new System.Drawing.Point(0, 0);
            this.groupParametros.Name = "groupParametros";
            this.groupParametros.Size = new System.Drawing.Size(690, 102);
            this.groupParametros.TabIndex = 0;
            this.groupParametros.Text = "Parametros";
            this.groupParametros.Visible = false;
            // 
            // xscParametros
            // 
            this.xscParametros.Controls.Add(this.dp2);
            this.xscParametros.Controls.Add(this.dp3);
            this.xscParametros.Controls.Add(this.dp1);
            this.xscParametros.Controls.Add(this.btnLimpiar);
            this.xscParametros.Controls.Add(this.btnBuscar);
            this.xscParametros.Controls.Add(this.txtFiltro3);
            this.xscParametros.Controls.Add(this.lueFiltro3);
            this.xscParametros.Controls.Add(this.lblFiltro3);
            this.xscParametros.Controls.Add(this.txtFiltro2);
            this.xscParametros.Controls.Add(this.txtFiltro1);
            this.xscParametros.Controls.Add(this.lueDocumento);
            this.xscParametros.Controls.Add(this.lueSucursal);
            this.xscParametros.Controls.Add(this.lblDocumento);
            this.xscParametros.Controls.Add(this.lblSucursal);
            this.xscParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscParametros.Location = new System.Drawing.Point(2, 27);
            this.xscParametros.Name = "xscParametros";
            this.xscParametros.Size = new System.Drawing.Size(686, 73);
            this.xscParametros.TabIndex = 0;
            // 
            // dp2
            // 
            this.dp2.EditValue = null;
            this.dp2.Location = new System.Drawing.Point(326, 27);
            this.dp2.Name = "dp2";
            this.dp2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dp2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dp2.Size = new System.Drawing.Size(150, 20);
            this.dp2.TabIndex = 15;
            this.dp2.Visible = false;
            // 
            // dp3
            // 
            this.dp3.EditValue = null;
            this.dp3.Location = new System.Drawing.Point(14, 27);
            this.dp3.Name = "dp3";
            this.dp3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dp3.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dp3.Size = new System.Drawing.Size(150, 20);
            this.dp3.TabIndex = 14;
            this.dp3.Visible = false;
            // 
            // dp1
            // 
            this.dp1.EditValue = null;
            this.dp1.Location = new System.Drawing.Point(170, 28);
            this.dp1.Name = "dp1";
            this.dp1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dp1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dp1.Size = new System.Drawing.Size(150, 20);
            this.dp1.TabIndex = 14;
            this.dp1.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLimpiar.ImageOptions.SvgImage")));
            this.btnLimpiar.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnLimpiar.Location = new System.Drawing.Point(521, 41);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(111, 24);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBuscar.ImageOptions.SvgImage")));
            this.btnBuscar.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBuscar.Location = new System.Drawing.Point(521, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 24);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Visible = false;
            // 
            // txtFiltro3
            // 
            this.txtFiltro3.Location = new System.Drawing.Point(326, 28);
            this.txtFiltro3.Name = "txtFiltro3";
            this.txtFiltro3.Properties.EditValueChangedDelay = 500;
            this.txtFiltro3.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtFiltro3.Size = new System.Drawing.Size(150, 20);
            this.txtFiltro3.TabIndex = 8;
            this.txtFiltro3.Visible = false;
            // 
            // lueFiltro3
            // 
            this.lueFiltro3.Location = new System.Drawing.Point(326, 28);
            this.lueFiltro3.Name = "lueFiltro3";
            this.lueFiltro3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFiltro3.Size = new System.Drawing.Size(150, 20);
            this.lueFiltro3.TabIndex = 7;
            this.lueFiltro3.Visible = false;
            // 
            // lblFiltro3
            // 
            this.lblFiltro3.AutoSize = true;
            this.lblFiltro3.Location = new System.Drawing.Point(323, 11);
            this.lblFiltro3.Name = "lblFiltro3";
            this.lblFiltro3.Size = new System.Drawing.Size(67, 13);
            this.lblFiltro3.TabIndex = 6;
            this.lblFiltro3.Text = "Documento";
            this.lblFiltro3.Visible = false;
            // 
            // txtFiltro2
            // 
            this.txtFiltro2.Location = new System.Drawing.Point(170, 28);
            this.txtFiltro2.Name = "txtFiltro2";
            this.txtFiltro2.Properties.EditValueChangedDelay = 500;
            this.txtFiltro2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtFiltro2.Size = new System.Drawing.Size(150, 20);
            this.txtFiltro2.TabIndex = 5;
            this.txtFiltro2.Visible = false;
            // 
            // txtFiltro1
            // 
            this.txtFiltro1.Location = new System.Drawing.Point(14, 28);
            this.txtFiltro1.Name = "txtFiltro1";
            this.txtFiltro1.Properties.EditValueChangedDelay = 500;
            this.txtFiltro1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtFiltro1.Size = new System.Drawing.Size(150, 20);
            this.txtFiltro1.TabIndex = 4;
            this.txtFiltro1.Visible = false;
            // 
            // lueDocumento
            // 
            this.lueDocumento.Location = new System.Drawing.Point(170, 28);
            this.lueDocumento.Name = "lueDocumento";
            this.lueDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDocumento.Size = new System.Drawing.Size(150, 20);
            this.lueDocumento.TabIndex = 3;
            this.lueDocumento.Visible = false;
            // 
            // lueSucursal
            // 
            this.lueSucursal.Location = new System.Drawing.Point(13, 28);
            this.lueSucursal.Name = "lueSucursal";
            this.lueSucursal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSucursal.Size = new System.Drawing.Size(150, 20);
            this.lueSucursal.TabIndex = 2;
            this.lueSucursal.Visible = false;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(167, 11);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(67, 13);
            this.lblDocumento.TabIndex = 1;
            this.lblDocumento.Text = "Documento";
            this.lblDocumento.Visible = false;
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(10, 11);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(50, 13);
            this.lblSucursal.TabIndex = 0;
            this.lblSucursal.Text = "Sucursal";
            this.lblSucursal.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 58);
            this.panel1.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(454, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 32);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(569, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 32);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gcBuscador);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 102);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(690, 355);
            this.panelControl1.TabIndex = 4;
            // 
            // gcBuscador
            // 
            this.gcBuscador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBuscador.Location = new System.Drawing.Point(0, 0);
            this.gcBuscador.MainView = this.gvBuscador;
            this.gcBuscador.Name = "gcBuscador";
            this.gcBuscador.Size = new System.Drawing.Size(690, 355);
            this.gcBuscador.TabIndex = 0;
            this.gcBuscador.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBuscador});
            this.gcBuscador.DoubleClick += new System.EventHandler(this.gcBuscador_DoubleClick);
            this.gcBuscador.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gcBuscador_KeyUp);
            // 
            // gvBuscador
            // 
            this.gvBuscador.GridControl = this.gcBuscador;
            this.gvBuscador.Name = "gvBuscador";
            this.gvBuscador.OptionsBehavior.Editable = false;
            this.gvBuscador.OptionsView.ShowAutoFilterRow = true;
            this.gvBuscador.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvBuscador.OptionsView.ShowGroupPanel = false;
            this.gvBuscador.OptionsView.ShowViewCaption = true;
            // 
            // FrmBuscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 515);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupParametros);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmBuscador.IconOptions.Icon")));
            this.Name = "FrmBuscador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscador";
            this.Load += new System.EventHandler(this.frmBuscador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupParametros)).EndInit();
            this.groupParametros.ResumeLayout(false);
            this.xscParametros.ResumeLayout(false);
            this.xscParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dp2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp3.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltro3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFiltro3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltro2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiltro1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSucursal.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBuscador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBuscador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupParametros;
        private DevExpress.XtraEditors.XtraScrollableControl xscParametros;
        private DevExpress.XtraEditors.LookUpEdit lueDocumento;
        private DevExpress.XtraEditors.LookUpEdit lueSucursal;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gcBuscador;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBuscador;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtFiltro3;
        private DevExpress.XtraEditors.LookUpEdit lueFiltro3;
        private Label lblFiltro3;
        private DevExpress.XtraEditors.TextEdit txtFiltro2;
        private DevExpress.XtraEditors.TextEdit txtFiltro1;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DateEdit dp2;
        private DateEdit dp1;
        private DateEdit dp3;
    }
}