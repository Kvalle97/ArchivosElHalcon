using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Modelos;
using CSNegocios.Properties;
using CSNegocios.Servicios.General;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using SqlParameter = System.Data.SqlClient.SqlParameter;

namespace CSNegocios.Servicios
{
    public class ServicioOrdenesDeCompra : ServicioBase
    {

        public void ObtenerProveedores(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarSpDataTable("spListarProveedoresinformatica", null);
        }


        public void ObtenerContacto(LookUpEdit lue, int codigo)
        {
            dataTable = Coneccion.EjecutarSpDataTable("spObtenerContacto", cmd =>
             {
                 cmd.Parameters.Add(new SqlParameter("Idproveedor", SqlDbType.Int)).Value = codigo;

             });


            lue.Properties.DataSource = dataTable;
            lue.Properties.ValueMember = "Contacto";
            lue.Properties.DisplayMember = "Contacto";
            lue.ItemIndex = 0;

        }

        public int GuardarOrdendeCompra(ModeloOrdendeCompra OrdendeCompra, int idLogin, string usuario)
        {
            return Coneccion.EjecutarSp("spGuardarOrdenDeCompraInformatica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdOrden", SqlDbType.Int)).Value = OrdendeCompra.IdOrden;
                cmd.Parameters.Add(new SqlParameter("Sucursal", SqlDbType.NVarChar)).Value = OrdendeCompra.Sucursal;
                cmd.Parameters.Add(new SqlParameter("IdProveedor", SqlDbType.NVarChar)).Value = OrdendeCompra.ProveedorCodigo;
                cmd.Parameters.Add(new SqlParameter("DolarizarOrdenDeCompra", SqlDbType.Bit)).Value = OrdendeCompra.DolarizarOrdenDeCompra;
                cmd.Parameters.Add(new SqlParameter("ExoneradoDeIVa", SqlDbType.Bit)).Value = OrdendeCompra.ExoneradoDeIVa;
                cmd.Parameters.Add(new SqlParameter("SubTotal", SqlDbType.Decimal)).Value = OrdendeCompra.SubTotal;
                cmd.Parameters.Add(new SqlParameter("Iva", SqlDbType.Decimal)).Value = OrdendeCompra.Iva;
                cmd.Parameters.Add(new SqlParameter("Descuento", SqlDbType.Decimal)).Value = OrdendeCompra.DescuentoTotal;
                cmd.Parameters.Add(new SqlParameter("Total", SqlDbType.Decimal)).Value = OrdendeCompra.CostoTotalOrden;
                cmd.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.Int)).Value = idLogin;
                cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("Comentario", SqlDbType.NVarChar)).Value = OrdendeCompra.Comentario;
                cmd.Parameters.Add(new SqlParameter("FechaDelDocumento", SqlDbType.DateTime)).Value = OrdendeCompra.FechaDelDocumento;
                cmd.Parameters.Add(new SqlParameter("Contacto", SqlDbType.NVarChar)).Value = OrdendeCompra.Contacto;

            });

        }

        public int EliminarOrden(int IdOrden)
        {
            return Coneccion.EjecutarSp("spEliminarOrdenInformatica", command =>
            {
                command.Parameters.Add(new SqlParameter("IdOrden", SqlDbType.Int)).Value = IdOrden;
            });
        }

        public int AgregarProdutctoATemporal(string codigo, decimal cantidad, decimal costo, string descripcion, int idLogin)
        {
            return Coneccion.EjecutarSp("spAgregarATemporalOrdenesDeCompraInformatica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("CodigoProducto", SqlDbType.NVarChar)).Value = codigo;
                cmd.Parameters.Add(new SqlParameter("Cantidad", SqlDbType.Decimal)).Value = cantidad;
                cmd.Parameters.Add(new SqlParameter("Costo", SqlDbType.Decimal)).Value = costo;
                cmd.Parameters.Add(new SqlParameter("DescripcionProducto ", SqlDbType.NVarChar)).Value = descripcion;
                cmd.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.NVarChar)).Value = idLogin;
            });
        }

        public void ObtnerProductosDeLaOrden(GridControl gce, GridView gve, int idLogin, bool dolar)
        {
            gve.Columns.Clear();

            gce.DataSource = Coneccion.EjecutarSpDataTable("spObtenerOrdenesDeCompraInformaticaTemporal",
                cmd => { cmd.Parameters.Add(new SqlParameter("idLogin", SqlDbType.Int)).Value = idLogin; });

            gve.Columns["Código"].Width = 50;
            gve.Columns["Descripción"].Width = 500;
            gve.Columns["Cantidad"].Width = 60;
            gve.Columns["Precio_Unitario"].Width = 80;
            gve.Columns["Total"].Width = 80;
            gve.CustomColumnDisplayText += (sender, args) =>
            {
                if (args.Column.FieldName == "Total")
                {
                    decimal costo = dolar
                        ? Convert.ToDecimal(args.Value)
                        : Convert.ToDecimal(args.Value);

                    args.DisplayText = costo.ToString("c2", new CultureInfo(dolar ? "en-US" : "es-NI", false));
                }

                if (args.Column.FieldName == "Precio_Unitario") /*esta condicion me funciona para indicar al valor que esta en el*/
                {                                               /*datagrid que me salgan 6 0 y se cambie dolar o corba*/

                    decimal costo = dolar
                         ? Convert.ToDecimal(args.Value)
                         : Convert.ToDecimal(args.Value);

                    args.DisplayText = costo.ToString("c2", new CultureInfo(dolar ? "en-US" : "es-NI", false));
                }

            };

            /* gve.BestFitColumns(); *//*se utiliza para que se acomode automaticamenten en el datgb*/

        }

        public DataTable ObtenerDatosDeLaOrden(int idLogin)
        {
            return Coneccion.EjecutarSpDataTable("spObtenerDatosDeLaOrdenDeComprainformatica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.Int)).Value = idLogin;

            });
        }


        public string Obtenerultimoregistro(int IdOrden)
        {
            return Convert.ToString(Coneccion.ObterResultadoText("SELECT TOP (1) IdOrden + 1  FROM OrdendeCompraInformatica order by FechaDelDocumento desc;",
               cmd =>
               {
                   cmd.Parameters.Add(new SqlParameter("IdOrden", SqlDbType.Int)).Value = IdOrden;

               }));
        }



        public int LimpiarOrdenDeCompraTemporal(int idLogin, string codigo)
        {
            return Coneccion.EjecutarSp("spLimpiarTemporalOrdenesDeCompraInformatica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.Int)).Value = idLogin;
                cmd.Parameters.Add(new SqlParameter("CodigoProducto", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(codigo);

            });
        }

        public ModeloOrdendeCompra ObtenerUltimaOrdendeCompra()
        {
            ModeloOrdendeCompra Ordendecompra = new ModeloOrdendeCompra();


            dataTable = null;


            dataTable = Coneccion.EjecutarSpDataTable("spObtenerUltimaOrdenDeCompraInformatica", null);


            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Ordendecompra.IdOrden = Convert.ToInt32(dataTable.Rows[0]["IdOrden"]);

            }
            else
            {
                throw new Exception("No se encontro la ultima orden de compra");
            }

            return Ordendecompra;


        }

        public void CargarATemporalOrdenesDeCompra(int idOrden, int idLogin)
        {
            Coneccion.EjecutarSp("spCargarEnTemporalOrdenDeCompraInformatica", cmd =>
            {

                cmd.Parameters.Add(new SqlParameter("IdOrden", SqlDbType.Int)).Value = idOrden;
                cmd.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.Int)).Value = idLogin;
            });
        }

        public ModeloOrdendeCompra ObtenerOrdenDeCompra(int IdOrden)
        {
            dataTable = null;

            dataTable = Coneccion.EjecutarSpDataTable("spObtenerOrdenDeCompraInformatica", cmd =>
            {

                cmd.Parameters.Add("IdOrden", SqlDbType.Int).Value = IdOrden;
            });


            if (dataTable != null && dataTable.Rows.Count > 0)
            {

                ModeloOrdendeCompra ordenDeCompra = new ModeloOrdendeCompra();

                ordenDeCompra.IdOrden = IdOrden;
                ordenDeCompra.Sucursal = Convert.ToString(dataTable.Rows[0]["Sucursal"]);
                ordenDeCompra.ProveedorCodigo = Convert.ToInt32(dataTable.Rows[0]["Código_Proveedor"]);
                ordenDeCompra.ProveedorDescripcion = Convert.ToString(dataTable.Rows[0]["Descripcion_Proveedor"]);
                ordenDeCompra.FechaDelDocumento = Convert.ToDateTime(dataTable.Rows[0]["FechaDelDocumento"]);
                ordenDeCompra.Contacto = Convert.ToString(dataTable.Rows[0]["Contacto"]);
                ordenDeCompra.Cerrado = Convert.ToBoolean(dataTable.Rows[0]["Cerrado"]);
                ordenDeCompra.DolarizarOrdenDeCompra = Convert.ToBoolean(dataTable.Rows[0]["DolarizarOrdenDeCompra"]);
                ordenDeCompra.ExoneradoDeIVa = Convert.ToBoolean(dataTable.Rows[0]["ExoneradoDeIva"]);
                ordenDeCompra.Comentario = dataTable.Rows[0]["Comentario"] != DBNull.Value
                ? Convert.ToString(dataTable.Rows[0]["Comentario"])
                : null;
                ordenDeCompra.Tc = Convert.ToDecimal(dataTable.Rows[0]["Tc"]);

                return ordenDeCompra;
            }

            return null;
        }

        public void ObtenerOrdenesDeCompra(GridControl gc, GridView gv, DateTime desde,
          DateTime hasta)
        {
            gc.DataSource = Coneccion.EjecutarSpDataTable("spObtenerOrdenesDeCompraInformatica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("Desde", SqlDbType.Date)).Value = desde;
                cmd.Parameters.Add(new SqlParameter("Hasta", SqlDbType.Date)).Value = hasta;
            });



            gv.Columns["Total"].DisplayFormat.FormatType = FormatType.Numeric;
            gv.Columns["Total"].DisplayFormat.FormatString = "N2";




        }


        public DataTable ReporteOrdenDeCompra(int Idorden)
        {
            return Coneccion.EjecutarSpDataTable("spReporteOrdenDeCompraInformatica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdOrden", SqlDbType.Int)).Value = Idorden;

            });
        }

        public int AplicarOrdenDeCompra(int IdOrden)
        {
            return Coneccion.EjecutarSp("spAplicarOrdenDeCompraInformatica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdOrden", SqlDbType.Int)).Value = IdOrden;

            });
        }


        public int RevertirAplicar(int IdOrden)
        {
            return Coneccion.EjecutarSp("spRevertirAplicarOrdenDeCompraInformatica", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@IdOrden", SqlDbType.Int)).Value = IdOrden;
            });
        }


        public void CargarContacto(LookUpEdit lue, int IdOrden)
        {
            dataTable = Coneccion.EjecutarSpDataTable("spCargarContacto", cmd =>
             {
                 cmd.Parameters.Add(new SqlParameter("IdOrden", SqlDbType.Int)).Value = IdOrden;

             });
            lue.Properties.DataSource = dataTable;
            lue.Properties.ValueMember = "Contacto";
            lue.Properties.DisplayMember = "Contacto";
            lue.ItemIndex = 0;

        }



    }

}



