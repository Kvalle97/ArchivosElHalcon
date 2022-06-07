using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace CSPresentacion.Sistema.Administracion.OpcionCatalogo.Reporte
{
    public partial class rptOrdenDeCompracs : DevExpress.XtraReports.UI.XtraReport
    {
        public rptOrdenDeCompracs(bool dolar)
        {
            InitializeComponent();

            if (dolar == true)
            {

                xrSubTotal.TextFormatString = "US$ {0:n2}";
                xrIva.TextFormatString = "US$ {0:n2}";
                xrDescuento.TextFormatString = "US$ {0:n2}";
                xrTotal.TextFormatString = "US$ {0:n2}";

                xrTableCosto.TextFormatString = "US$ {0:n2}";
                xrTableCantidad.TextFormatString = "{0:n2}";
                xrTableSubtotalU.TextFormatString = "US$ {0:n2}";
                xrTableDesc.TextFormatString = "US$ {0:n2}";
            }
            else
            {
                xrSubTotal.TextFormatString = "C$ {0:n2}";
                xrIva.TextFormatString = "C$ {0:n2}";
                xrDescuento.TextFormatString = "C$ {0:n2}";
                xrTotal.TextFormatString = "C$ {0:n2}";

                xrTableCosto.TextFormatString = "C$ {0:n2}";
                xrTableCantidad.TextFormatString = "{0:n2}";
                xrTableSubtotalU.TextFormatString = "C$ {0:n2}";
                xrTableDesc.TextFormatString = "C$ {0:n2}";


            }


        }
    }
}
