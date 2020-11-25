using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Servicios.General;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    public class ServicioProducto : ServicioBase
    {
        public void ActualizarMargenYDescuentoMaximo(decimal margenMinimo, decimal descuentoMaximo, string codigo,
            int empresa)
        {
            strSql = "update Productos_Empresas " +
                     "set MargenMinimo = @margen , DescuentoMaximo = @descuento " +
                     "where Código_Compuesto = @codigo " +
                     "  and IdEmpresa = @empresa ";

            Coneccion.EjecutarSpText(strSql,
                cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("@margen", SqlDbType.Decimal)).Value = margenMinimo;
                    cmd.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Decimal)).Value = descuentoMaximo;
                    cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.NVarChar)).Value = codigo;
                    cmd.Parameters.Add(new SqlParameter("@empresa", SqlDbType.Int)).Value = empresa;
                });
        }

        public void MostrarProductos(GridControl gc, GridView gv)
        {
            strSql = "select p.Código_Compuesto     as Codigo, " +
                     "       p.Descripción_Producto as Producto, " +
                     "p.Inactivo " +
                     "from " +
                     " Productos p " +
                     "order by p.Descripción_Producto; ";

            gc.DataSource = Coneccion.EjecutarTextDataTable(strSql);


            gv.Columns["Codigo"].Width = 100;
            gv.Columns["Producto"].Width = 300;
        }

        public void MostrarSucursalesPorProduct(CheckedComboBoxEdit ckCombo, string codigo)
        {
            strSql = "select distinct e.IdEmpresa as IdSucursal, E.NombreCorto as Sucursal " +
                     "from Productos_Empresas pe " +
                     "         inner join Empresas E on pe.IdEmpresa = E.IdEmpresa " +
                     $"where pe.Código_Compuesto = '{codigo}'; ";
            
            ckCombo.Properties.ValueMember = "IdSucursal";
            ckCombo.Properties.DisplayMember = "Sucursal";
            ckCombo.Properties.EditValueType = EditValueTypeCollection.List;
            ckCombo.Properties.DataSource = Coneccion.EjecutarTextDataTable(strSql);

            ckCombo.RefreshEditValue();
        }
    }
}