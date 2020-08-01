using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSNegocios.Servicios;

namespace CSPresentacion.Sistema.Utilidades
{
    public class SubDashboard
    {
        private readonly ServicioDashboard seviciServicioDashboard = new ServicioDashboard();
        public string ItemName { get; set; }
        public int SubDashboarId { get; set; }
        public List<string> ParametrosHeradadosList { get; set; } = new List<string>();
        public string ParamName { get; set; }

        public SubDashboard(string itemName, int subDashboardId, string paramName)
        {
            this.ItemName = itemName;
            this.SubDashboarId = subDashboardId;
            this.ParamName = paramName;
               
        }
    }
}