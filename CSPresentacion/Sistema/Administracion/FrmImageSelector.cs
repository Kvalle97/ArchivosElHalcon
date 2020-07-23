using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.DashboardExport.Map;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace CSPresentacion.Sistema.Administracion
{
    public partial class FrmImageSelector : XtraForm
    {
        public FrmImageSelector()
        {
            InitializeComponent();
        }

        private void FrmImageSelector_Load(object sender, EventArgs e)
        {
            var group = new GalleryItemGroup() {Caption = "SVG"};
            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ImageSize = new Size(120, 90);
            galleryControl1.Gallery.ShowItemText = true;

            foreach (var image in
                DevExpress.Images.XAFImageList.SvgImages)
            {
                Image img = new DxImageUri(image.ResourceKey) {SvgImageSize = new Size(120, 90)}.GetImage();

                group.Items.Add(new GalleryItem(img, image.Name, image.Group));
            }

            galleryControl1.Gallery.Groups.Add(group);
        }
    }
}