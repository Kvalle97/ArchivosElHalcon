namespace CSPresentacion.Sistema.Administracion
{
    partial class FrmAccionesyPermisos
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.ckbAuditable = new DevExpress.XtraEditors.CheckEdit();
            this.gcAcciones = new DevExpress.XtraGrid.GridControl();
            this.gvAcciones = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.meDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAuditable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAcciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnNuevo);
            this.groupControl2.Controls.Add(this.btnQuitar);
            this.groupControl2.Controls.Add(this.btnGuardar);
            this.groupControl2.Controls.Add(this.ckbAuditable);
            this.groupControl2.Controls.Add(this.gcAcciones);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.meDescripcion);
            this.groupControl2.Controls.Add(this.txtNombre);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Location = new System.Drawing.Point(12, 11);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(498, 473);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Acciones";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(87, 200);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(64, 23);
            this.btnNuevo.TabIndex = 24;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(157, 200);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(64, 23);
            this.btnQuitar.TabIndex = 23;
            this.btnQuitar.Text = "Quitar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(17, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(64, 23);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ckbAuditable
            // 
            this.ckbAuditable.Location = new System.Drawing.Point(17, 83);
            this.ckbAuditable.Name = "ckbAuditable";
            this.ckbAuditable.Properties.Caption = "Auditable";
            this.ckbAuditable.Size = new System.Drawing.Size(75, 20);
            this.ckbAuditable.TabIndex = 21;
            // 
            // gcAcciones
            // 
            this.gcAcciones.Location = new System.Drawing.Point(17, 259);
            this.gcAcciones.MainView = this.gvAcciones;
            this.gcAcciones.Name = "gcAcciones";
            this.gcAcciones.Size = new System.Drawing.Size(464, 195);
            this.gcAcciones.TabIndex = 18;
            this.gcAcciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAcciones});
            // 
            // gvAcciones
            // 
            this.gvAcciones.GridControl = this.gcAcciones;
            this.gvAcciones.Name = "gvAcciones";
            this.gvAcciones.OptionsBehavior.Editable = false;
            this.gvAcciones.OptionsCustomization.AllowGroup = false;
            this.gvAcciones.OptionsView.ShowAutoFilterRow = true;
            this.gvAcciones.OptionsView.ShowGroupPanel = false;
            this.gvAcciones.ViewCaption = "Sistemas o modulos";
            this.gvAcciones.DoubleClick += new System.EventHandler(this.gvAcciones_DoubleClick);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(237, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 13);
            this.labelControl6.TabIndex = 15;
            this.labelControl6.Text = "Descripción";
            // 
            // meDescripcion
            // 
            this.meDescripcion.Location = new System.Drawing.Point(237, 54);
            this.meDescripcion.Name = "meDescripcion";
            this.meDescripcion.Properties.MaxLength = 250;
            this.meDescripcion.Size = new System.Drawing.Size(244, 184);
            this.meDescripcion.TabIndex = 14;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(17, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Properties.Mask.EditMask = "\\S*";
            this.txtNombre.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtNombre.Size = new System.Drawing.Size(214, 20);
            this.txtNombre.TabIndex = 11;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(17, 34);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(41, 13);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "Nombre";
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // FrmAccionesyPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 503);
            this.Controls.Add(this.groupControl2);
            this.Name = "FrmAccionesyPermisos";
            this.Text = "Acciones y permisos";
            this.Load += new System.EventHandler(this.FrmAccionesyPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAuditable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAcciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnNuevo;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.CheckEdit ckbAuditable;
        private DevExpress.XtraGrid.GridControl gcAcciones;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAcciones;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit meDescripcion;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
    }
}