using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;

namespace CSPresentacion
{
    public class ConfiguracionDialogos : Localizer
    {
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.XtraMessageBoxYesButtonText:
                    return "Buscar en la base de datos";

                //case StringId.XtraMessageBoxOkButtonText:
                //    return "My OK Button";

                case StringId.XtraMessageBoxNoButtonText:
                    return "Buscar en el dispositivo";

                //case StringId.XtraMessageBoxCancelButtonText:
                //    return "Cerrar";

                default:
                    return base.GetLocalizedString(id);
            } //End the switch() statement            
        }
    }
}