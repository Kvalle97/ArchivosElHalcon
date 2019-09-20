using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Servicios.General;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    /// <summary>
    /// Servicio Usuarioss
    /// </summary>
    public class ServicioUsuarios : ServicioBase
    {
        /// <summary>
        /// Cargar usuarios
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        public void CargarUsuarios(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarSpDataTable("spObtenerTodosLosUsuarios", null);

            if (gc.DataSource != null)
            {
                gv.ActiveFilterString = "[Activo] == true";
            }
        }

        /// <summary>
        /// Cargar Niveles
        /// </summary>
        /// <param name="lue"></param>
        public void CargarNiveles(LookUpEdit lue)
        {
            lue.Properties.DataSource = Coneccion.EjecutarTextTable("select * from NIVELES order by IDNIVEL", null);

            lue.Properties.ValueMember = "IDNIVEL";
            lue.Properties.DisplayMember = "NIVEL";
            
            lue.Properties.ForceInitialize();

            lue.ItemIndex = 0;
        }
    }
}