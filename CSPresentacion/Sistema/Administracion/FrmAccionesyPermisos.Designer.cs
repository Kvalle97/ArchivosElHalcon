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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcAcceso = new DevExpress.XtraGrid.GridControl();
            this.gvAcceso = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnNuevoRol = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuitarRol = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuardarRol = new DevExpress.XtraEditors.SimpleButton();
            this.ckbEsSuperAdministrador = new DevExpress.XtraEditors.CheckEdit();
            this.gcRoles = new DevExpress.XtraGrid.GridControl();
            this.gvRoles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.meDescripcionRol = new DevExpress.XtraEditors.MemoEdit();
            this.txtNombreRol = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAuditable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAcciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAcceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbEsSuperAdministrador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescripcionRol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreRol.Properties)).BeginInit();
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
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
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
            this.gvAcciones.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvAcciones_KeyUp);
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.gcAcceso);
            this.groupControl1.Controls.Add(this.btnNuevoRol);
            this.groupControl1.Controls.Add(this.btnQuitarRol);
            this.groupControl1.Controls.Add(this.btnGuardarRol);
            this.groupControl1.Controls.Add(this.ckbEsSuperAdministrador);
            this.groupControl1.Controls.Add(this.gcRoles);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.meDescripcionRol);
            this.groupControl1.Controls.Add(this.txtNombreRol);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(516, 11);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(639, 473);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Roles";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(237, 36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(83, 13);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = "Puede acceder a";
            // 
            // gcAcceso
            // 
            this.gcAcceso.Enabled = false;
            this.gcAcceso.Location = new System.Drawing.Point(237, 55);
            this.gcAcceso.MainView = this.gvAcceso;
            this.gcAcceso.Name = "gcAcceso";
            this.gcAcceso.Size = new System.Drawing.Size(397, 227);
            this.gcAcceso.TabIndex = 25;
            this.gcAcceso.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAcceso});
            // 
            // gvAcceso
            // 
            this.gvAcceso.GridControl = this.gcAcceso;
            this.gvAcceso.Name = "gvAcceso";
            this.gvAcceso.OptionsBehavior.Editable = false;
            this.gvAcceso.OptionsCustomization.AllowGroup = false;
            this.gvAcceso.OptionsView.ShowAutoFilterRow = true;
            this.gvAcceso.OptionsView.ShowGroupPanel = false;
            this.gvAcceso.ViewCaption = "Sistemas o modulos";
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.Location = new System.Drawing.Point(90, 259);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(64, 23);
            this.btnNuevoRol.TabIndex = 24;
            this.btnNuevoRol.Text = "Nuevo";
            this.btnNuevoRol.Click += new System.EventHandler(this.btnNuevoRol_Click);
            // 
            // btnQuitarRol
            // 
            this.btnQuitarRol.Location = new System.Drawing.Point(160, 259);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(64, 23);
            this.btnQuitarRol.TabIndex = 23;
            this.btnQuitarRol.Text = "Quitar";
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.Location = new System.Drawing.Point(20, 259);
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Size = new System.Drawing.Size(64, 23);
            this.btnGuardarRol.TabIndex = 22;
            this.btnGuardarRol.Text = "Guardar";
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // ckbEsSuperAdministrador
            // 
            this.ckbEsSuperAdministrador.Location = new System.Drawing.Point(17, 83);
            this.ckbEsSuperAdministrador.Name = "ckbEsSuperAdministrador";
            this.ckbEsSuperAdministrador.Properties.Caption = "Es super administrador";
            this.ckbEsSuperAdministrador.Size = new System.Drawing.Size(162, 20);
            this.ckbEsSuperAdministrador.TabIndex = 21;
            // 
            // gcRoles
            // 
            this.gcRoles.Location = new System.Drawing.Point(17, 292);
            this.gcRoles.MainView = this.gvRoles;
            this.gcRoles.Name = "gcRoles";
            this.gcRoles.Size = new System.Drawing.Size(617, 162);
            this.gcRoles.TabIndex = 18;
            this.gcRoles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRoles});
            // 
            // gvRoles
            // 
            this.gvRoles.GridControl = this.gcRoles;
            this.gvRoles.Name = "gvRoles";
            this.gvRoles.OptionsBehavior.Editable = false;
            this.gvRoles.OptionsCustomization.AllowGroup = false;
            this.gvRoles.OptionsView.ShowAutoFilterRow = true;
            this.gvRoles.OptionsView.ShowGroupPanel = false;
            this.gvRoles.ViewCaption = "Sistemas o modulos";
            this.gvRoles.DoubleClick += new System.EventHandler(this.gvRoles_DoubleClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 113);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Descripción";
            // 
            // meDescripcionRol
            // 
            this.meDescripcionRol.Location = new System.Drawing.Point(17, 133);
            this.meDescripcionRol.Name = "meDescripcionRol";
            this.meDescripcionRol.Properties.MaxLength = 250;
            this.meDescripcionRol.Size = new System.Drawing.Size(214, 105);
            this.meDescripcionRol.TabIndex = 14;
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(17, 53);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreRol.Properties.Mask.EditMask = "\\S*";
            this.txtNombreRol.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtNombreRol.Size = new System.Drawing.Size(214, 20);
            this.txtNombreRol.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Nombre";
            // 
            // FrmAccionesyPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 503);
            this.Controls.Add(this.groupControl1);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAcceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbEsSuperAdministrador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescripcionRol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreRol.Properties)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnNuevoRol;
        private DevExpress.XtraEditors.SimpleButton btnQuitarRol;
        private DevExpress.XtraEditors.SimpleButton btnGuardarRol;
        private DevExpress.XtraEditors.CheckEdit ckbEsSuperAdministrador;
        private DevExpress.XtraGrid.GridControl gcRoles;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRoles;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit meDescripcionRol;
        private DevExpress.XtraEditors.TextEdit txtNombreRol;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gcAcceso;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAcceso;
    }
}