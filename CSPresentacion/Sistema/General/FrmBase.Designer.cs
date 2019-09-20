namespace CSPresentacion.Sistema.General
{
    partial class FrmBase
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
            DevExpress.XtraBars.Bar bar1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBase));
            this.btnIrAlUltimoRegistro = new DevExpress.XtraBars.BarButtonItem();
            this.btnIrAlRegistroAnterior = new DevExpress.XtraBars.BarButtonItem();
            this.btnIrAlSiguienteRegistro = new DevExpress.XtraBars.BarButtonItem();
            this.btnIrAlPrimerRegistro = new DevExpress.XtraBars.BarButtonItem();
            this.btnNuevo = new DevExpress.XtraBars.BarButtonItem();
            this.btnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.btnAplicar = new DevExpress.XtraBars.BarButtonItem();
            this.btnBuscar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.btnRevertirAnular = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            bar1.BarName = "Herramientas";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.FloatSize = new System.Drawing.Size(0, 10);
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIrAlUltimoRegistro),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIrAlRegistroAnterior),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIrAlSiguienteRegistro),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIrAlPrimerRegistro),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNuevo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGuardar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAnular),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAplicar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBuscar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEliminar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimir),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSalir),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRevertirAnular)});
            bar1.OptionsBar.AllowQuickCustomization = false;
            bar1.Text = "Herramientas";
            // 
            // btnIrAlUltimoRegistro
            // 
            this.btnIrAlUltimoRegistro.Caption = "Último";
            this.btnIrAlUltimoRegistro.Hint = "Ir al primer registro (control  + abajo)";
            this.btnIrAlUltimoRegistro.Id = 0;
            this.btnIrAlUltimoRegistro.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIrAlUltimoRegistro.ImageOptions.Image")));
            this.btnIrAlUltimoRegistro.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnIrAlUltimoRegistro.ImageOptions.LargeImage")));
            this.btnIrAlUltimoRegistro.Name = "btnIrAlUltimoRegistro";
            this.btnIrAlUltimoRegistro.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnIrAlUltimoRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnIrAlUltimoRegistro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIrAlUltimoRegistro_ItemClick);
            // 
            // btnIrAlRegistroAnterior
            // 
            this.btnIrAlRegistroAnterior.Caption = "Anterior";
            this.btnIrAlRegistroAnterior.Hint = "Ir al registro Anterior (control + izquierda)";
            this.btnIrAlRegistroAnterior.Id = 1;
            this.btnIrAlRegistroAnterior.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIrAlRegistroAnterior.ImageOptions.Image")));
            this.btnIrAlRegistroAnterior.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnIrAlRegistroAnterior.ImageOptions.LargeImage")));
            this.btnIrAlRegistroAnterior.Name = "btnIrAlRegistroAnterior";
            this.btnIrAlRegistroAnterior.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnIrAlRegistroAnterior.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnIrAlRegistroAnterior.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIrAlRegistroAnterior_ItemClick);
            // 
            // btnIrAlSiguienteRegistro
            // 
            this.btnIrAlSiguienteRegistro.Caption = "Siguiente";
            this.btnIrAlSiguienteRegistro.Hint = "Ir al registro Siguiente (control  + derecha)";
            this.btnIrAlSiguienteRegistro.Id = 2;
            this.btnIrAlSiguienteRegistro.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIrAlSiguienteRegistro.ImageOptions.Image")));
            this.btnIrAlSiguienteRegistro.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnIrAlSiguienteRegistro.ImageOptions.LargeImage")));
            this.btnIrAlSiguienteRegistro.Name = "btnIrAlSiguienteRegistro";
            this.btnIrAlSiguienteRegistro.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnIrAlSiguienteRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnIrAlSiguienteRegistro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIrAlSiguienteRegistro_ItemClick);
            // 
            // btnIrAlPrimerRegistro
            // 
            this.btnIrAlPrimerRegistro.Caption = "Primero";
            this.btnIrAlPrimerRegistro.Hint = "Ir al primer registro (control  + arriba)";
            this.btnIrAlPrimerRegistro.Id = 3;
            this.btnIrAlPrimerRegistro.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIrAlPrimerRegistro.ImageOptions.Image")));
            this.btnIrAlPrimerRegistro.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnIrAlPrimerRegistro.ImageOptions.LargeImage")));
            this.btnIrAlPrimerRegistro.Name = "btnIrAlPrimerRegistro";
            this.btnIrAlPrimerRegistro.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnIrAlPrimerRegistro.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnIrAlPrimerRegistro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIrAlPrimerRegistro_ItemClick);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Caption = "Nuevo";
            this.btnNuevo.Hint = "Limpiar la pantalla para un registro nuevo (control  + N)";
            this.btnNuevo.Id = 4;
            this.btnNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.ImageOptions.Image")));
            this.btnNuevo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.ImageOptions.LargeImage")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnNuevo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNuevo_ItemClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "Guardar";
            this.btnGuardar.Hint = "Guarda el registro actual (control  + G)";
            this.btnGuardar.Id = 5;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.LargeImage")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnGuardar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // btnAnular
            // 
            this.btnAnular.Caption = "Anular";
            this.btnAnular.Hint = "Anula el registro actual (control  + delete)";
            this.btnAnular.Id = 11;
            this.btnAnular.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.ImageOptions.Image")));
            this.btnAnular.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.ImageOptions.LargeImage")));
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAnular.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAnular_ItemClick);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Caption = "Aplicar";
            this.btnAplicar.Hint = "Aplica el registro actual (control  + F11)";
            this.btnAplicar.Id = 12;
            this.btnAplicar.ImageOptions.Image = global::CSPresentacion.Properties.Resources.applyicon;
            this.btnAplicar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAplicar.ImageOptions.LargeImage")));
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAplicar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnAplicar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAplicar_ItemClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Caption = "Buscar";
            this.btnBuscar.Hint = "Haga click aquí para Buscar un registro (control  + B)";
            this.btnBuscar.Id = 6;
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.LargeImage")));
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnBuscar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBuscar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuscar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Hint = "Eliminar el elemento actual (control  + E)";
            this.btnEliminar.Id = 7;
            this.btnEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.Image")));
            this.btnEliminar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.LargeImage")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Hint = "Impimir (control  + I)";
            this.btnImprimir.Id = 8;
            this.btnImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.Image")));
            this.btnImprimir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.LargeImage")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnImprimir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Hint = "Salir (control  + S)";
            this.btnSalir.Id = 10;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.LargeImage")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSalir.Size = new System.Drawing.Size(0, 20);
            this.btnSalir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalir_ItemClick);
            // 
            // btnRevertirAnular
            // 
            this.btnRevertirAnular.Caption = "Revertir aplicar";
            this.btnRevertirAnular.Hint = "Revertir aplicar";
            this.btnRevertirAnular.Id = 13;
            this.btnRevertirAnular.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRevertirAnular.ImageOptions.Image")));
            this.btnRevertirAnular.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRevertirAnular.ImageOptions.LargeImage")));
            this.btnRevertirAnular.Name = "btnRevertirAnular";
            this.btnRevertirAnular.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRevertirAnular.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRevertirAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRevertirAnular_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnIrAlUltimoRegistro,
            this.btnIrAlRegistroAnterior,
            this.btnIrAlSiguienteRegistro,
            this.btnIrAlPrimerRegistro,
            this.btnNuevo,
            this.btnGuardar,
            this.btnBuscar,
            this.btnEliminar,
            this.btnImprimir,
            this.btnSalir,
            this.btnAnular,
            this.btnAplicar,
            this.btnRevertirAnular});
            this.barManager1.MaxItemId = 14;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1137, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 497);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1137, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 469);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1137, 28);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 469);
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 497);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmBase";
            this.Text = "FormularioBase";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnIrAlUltimoRegistro;
        private DevExpress.XtraBars.BarButtonItem btnIrAlRegistroAnterior;
        private DevExpress.XtraBars.BarButtonItem btnIrAlSiguienteRegistro;
        private DevExpress.XtraBars.BarButtonItem btnIrAlPrimerRegistro;
        private DevExpress.XtraBars.BarButtonItem btnNuevo;
        private DevExpress.XtraBars.BarButtonItem btnGuardar;
        private DevExpress.XtraBars.BarButtonItem btnBuscar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.BarButtonItem btnSalir;
        private DevExpress.XtraBars.BarButtonItem btnAnular;
        private DevExpress.XtraBars.BarButtonItem btnAplicar;
        private DevExpress.XtraBars.BarButtonItem btnRevertirAnular;
    }
}