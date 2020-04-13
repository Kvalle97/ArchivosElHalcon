using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Servicios.General;

namespace CSNegocios.Servicios
{
    public class ServicioFormatos : ServicioBase
    {
        public string ObtenerFormato()
        {
            return Convert.ToString(Coneccion.ObterResultadoText("select top 1 Texto from Formatos order by NEWID()  ;"));
        }
    }
}