using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPresentacion.Sistema.Utilidades
{
    public class ParametroPorDefecto
    {
        public object Valor { get; set; }
        public string Nombre { get; set; }

        public ParametroPorDefecto()
        {
        }

        public ParametroPorDefecto(object valor, string nombre)
        {
            this.Valor = valor;
            this.Nombre = nombre;
        }
    }
}