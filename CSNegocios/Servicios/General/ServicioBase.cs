using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios.General
{
    /// <summary>
    /// Ofrece la funcionalidad base de un servicio.
    /// </summary>
    public class ServicioBase
    {
        /// <summary>
        /// Obtjeto data set de uso común entre los servicios.
        /// </summary>
        protected DataSet dataSet = new DataSet();

        /// <summary>
        /// Error Gw
        /// </summary>
        protected string errorGw;

        /// <summary>
        /// Obtjeto data table de uso común entre los servicios.
        /// </summary>
        protected DataTable dataTable = new DataTable();

        /// <summary>
        /// String sql, de uso  común entre los servicios
        /// </summary>
        protected string strSql;

        /// <summary>
        /// Usar esta funcion para insertar nulo cuando se necesite
        /// </summary>
        /// <param name="objeto">Objeto</param>
        /// <returns></returns>
        protected object RevisarSiEsNuloSql(Object objeto)
        {
            if (objeto != null)
            {
                if (objeto is string)
                {
                    if (String.IsNullOrWhiteSpace((string) objeto))
                    {
                        return DBNull.Value;
                    }
                }

                return objeto;
            }
            else
            {
                return DBNull.Value;
            }
        }

        /// <summary>
        /// Cargar Data Table.
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        protected DataTable CargarDataTable(string consulta)
        {
            try
            {
                this.dataSet = new DataSet();

                this.dataSet = Coneccion.LlenarDataSet_II(consulta, ref errorGw);

                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.ToString();
                throw;
            }
        }

        /// <summary>
        /// Cargar Data Set
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        protected DataSet CargarDataSet(string consulta)
        {
            try
            {
                this.dataSet = new DataSet();

                this.dataSet = Coneccion.LlenarDataSet_II(consulta, ref errorGw);

                return dataSet;
            }
            catch (Exception ex)
            {
                Personalizar.Mensaje_Error = ex.ToString();
                throw;
            }
        }

        /// <summary>
        /// Cargar Grupo O Linea
        /// </summary>
        /// <param name="lue"></param>
        public void CargarGrupoOLinea(LookUpEdit lue)
        {
            lue.Properties.DataSource = Coneccion.EjecutarSpDataTable("spGrupoOLinea", null);

            lue.Properties.ValueMember = "Id";
            lue.Properties.DisplayMember = "GrupoOLinea";

            lue.ItemIndex = 0;
        }

        /// <summary>
        /// Agregar Documento referencia
        /// </summary>
        /// <param name="referencias"></param>
        /// <param name="idLogin"></param>
        /// <param name="agregar"></param>
        /// <returns></returns>
        public int AgregarDocumentoReferencia(DataTable referencias, int idLogin, bool agregar)
        {
            return Coneccion.EjecutarSP("spAgregarDocumentoReferencia", cmd =>
            {
                SqlParameter tblParameter = cmd.Parameters.AddWithValue("@Pack", referencias);

                tblParameter.SqlDbType = SqlDbType.Structured;
                tblParameter.TypeName = "DOCUMENTOREFERENCIAPACK";

                cmd.Parameters.Add(new SqlParameter("@IdLogin", SqlDbType.Int)).Value = idLogin;
                cmd.Parameters.Add(new SqlParameter("@Agregar", SqlDbType.Bit)).Value = agregar;

                return 0;
            });
        }

        /// <summary>
        /// Cargar sucursales.
        /// </summary>
        /// <param name="lue"></param>
        public void CargarSucursales(LookUpEdit lue, bool incluirTodas)
        {
            strSql = "exec SpInvCargarSucursales";

            dataTable = CargarDataTable(strSql);

            if (incluirTodas)
            {
                DataRow dr = dataTable.NewRow();

                dr["IdEmpresa"] = 99;
                dr["Empresa"] = "Todas las sucursales";

                dataTable.Rows.Add(dr);
            }

            lue.Properties.DataSource = dataTable;
            lue.Properties.ValueMember = "IdEmpresa";
            lue.Properties.DisplayMember = "Empresa";

            lue.Properties.ForceInitialize();

            lue.ItemIndex = 0;
        }

        /// <summary>
        /// Guardar Documento
        /// </summary>
        /// <param name="noDoc"></param>
        /// <param name="idTipoDoc"></param>
        /// <param name="fechaDoc"></param>
        /// <param name="idCliente"></param>
        /// <param name="cliente"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="fax"></param>
        /// <param name="email"></param>
        /// <param name="cerrado"></param>
        /// <param name="referecnia"></param>
        /// <param name="subtotal"></param>
        /// <param name="iva"></param>
        /// <param name="total"></param>
        /// <param name="autorizacionDgi"></param>
        /// <param name="idLogin"></param>
        /// <param name="formaDePago"></param>
        /// <param name="descuento"></param>
        /// <param name="exonerado"></param>
        /// <param name="saldo"></param>
        /// <param name="idEstado"></param>
        /// <param name="impreso"></param>
        /// <param name="costos"></param>
        /// <param name="efectivo"></param>
        /// <param name="cheque"></param>
        /// <param name="mn"></param>
        /// <param name="me"></param>
        /// <param name="noCheque"></param>
        /// <param name="banco"></param>
        /// <param name="version"></param>
        /// <param name="vendedor"></param>
        /// <param name="sucursalDestino"></param>
        /// <param name="retenciones"></param>
        /// <param name="montoDeRetencion"></param>
        /// <param name="comentarios"></param>
        /// <param name="tarjeta"></param>
        /// <returns></returns>
        protected int GuardarDocumento(int noDoc, int idTipoDoc, DateTime fechaDoc,
            string idCliente, string cliente, string direccion, string telefono,
            string fax, string email, bool cerrado,
            string referecnia, decimal subtotal, decimal iva,
            decimal total, string autorizacionDgi, int idLogin,
            int formaDePago, decimal descuento, bool exonerado,
            decimal saldo, int idEstado, bool impreso,
            decimal costos, bool efectivo, bool cheque,
            bool mn, bool me, string noCheque,
            string banco, int version, string vendedor,
            int sucursalDestino, string retenciones, decimal montoDeRetencion,
            string comentarios, bool tarjeta)
        {
            return Coneccion.EjecutarSP("SP_GUARDAR_DOCUMENTO", command =>
            {
                command.Parameters.Add(new SqlParameter("NoDoc", SqlDbType.Int)).Value = noDoc;
                command.Parameters.Add(new SqlParameter("IdTipoDoc", SqlDbType.Int)).Value = idTipoDoc;
                command.Parameters.Add(new SqlParameter("FechaDoc", SqlDbType.DateTime)).Value = fechaDoc;
                command.Parameters.Add(new SqlParameter("IdCliente", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(idCliente);
                command.Parameters.Add(new SqlParameter("Cliente", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(cliente);
                command.Parameters.Add(new SqlParameter("Dirección", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(direccion);
                command.Parameters.Add(new SqlParameter("Teléfono", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(telefono);
                command.Parameters.Add(new SqlParameter("Fax", SqlDbType.NVarChar)).Value = RevisarSiEsNuloSql(fax);
                command.Parameters.Add(new SqlParameter("email", SqlDbType.NVarChar)).Value = RevisarSiEsNuloSql(email);
                command.Parameters.Add(new SqlParameter("cerrado", SqlDbType.Bit)).Value = cerrado;
                command.Parameters.Add(new SqlParameter("Referencia", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(referecnia);
                command.Parameters.Add(new SqlParameter("SubTotal", SqlDbType.Float)).Value = subtotal;
                command.Parameters.Add(new SqlParameter("IVA", SqlDbType.Float)).Value = iva;
                command.Parameters.Add(new SqlParameter("Total", SqlDbType.Float)).Value = total;
                command.Parameters.Add(new SqlParameter("AutorizaciónDGI", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(autorizacionDgi);
                command.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.Int)).Value = idLogin;
                command.Parameters.Add(new SqlParameter("IdFormaPago", SqlDbType.SmallInt)).Value = formaDePago;
                command.Parameters.Add(new SqlParameter("Descuento", SqlDbType.Float)).Value = descuento;
                command.Parameters.Add(new SqlParameter("Exonerado", SqlDbType.Bit)).Value = exonerado;
                command.Parameters.Add(new SqlParameter("Saldo", SqlDbType.Float)).Value = saldo;
                command.Parameters.Add(new SqlParameter("IdEstado", SqlDbType.Int)).Value = idEstado;
                command.Parameters.Add(new SqlParameter("Impreso", SqlDbType.Bit)).Value = impreso;
                command.Parameters.Add(new SqlParameter("Costos", SqlDbType.Float)).Value = costos;
                command.Parameters.Add(new SqlParameter("Efectivo", SqlDbType.Bit)).Value = efectivo;
                command.Parameters.Add(new SqlParameter("Cheque", SqlDbType.Bit)).Value = cheque;
                command.Parameters.Add(new SqlParameter("MN", SqlDbType.Bit)).Value = mn;
                command.Parameters.Add(new SqlParameter("ME", SqlDbType.Bit)).Value = me;
                command.Parameters.Add(new SqlParameter("NoCheque", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(noCheque);
                command.Parameters.Add(new SqlParameter("Banco", SqlDbType.NVarChar)).Value = RevisarSiEsNuloSql(banco);
                command.Parameters.Add(new SqlParameter("Version", SqlDbType.Int)).Value = version;
                command.Parameters.Add(new SqlParameter("Vendedor", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(vendedor);
                command.Parameters.Add(new SqlParameter("SucursalDestino", SqlDbType.Int)).Value = sucursalDestino;
                command.Parameters.Add(new SqlParameter("Retenciones", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(retenciones);
                command.Parameters.Add(new SqlParameter("MontoRetencion", SqlDbType.Float)).Value =
                    montoDeRetencion;
                command.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(comentarios);
                command.Parameters.Add(new SqlParameter("Tarjeta", SqlDbType.Bit)).Value =
                    tarjeta;

                return 0;
            });
        }

        /// <summary>
        /// Obtener tipo Documento
        /// </summary>
        /// <param name="movimiento"></param>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public int? ObtenerTipoDoc(int movimiento, int empresa)
        {
            dataTable = null;
            dataTable = Coneccion.EjecutarSpDataTable("spObtenerTipoDocSegunEmpresa", command =>
            {
                command.Parameters.Add(new SqlParameter("TipoMov", SqlDbType.Int)).Value = movimiento;
                command.Parameters.Add(new SqlParameter("Empresa", SqlDbType.Int)).Value = empresa;

                return 0;
            });

            if (dataTable.Rows.Count > 0)
            {
                return Int32.Parse(dataTable.Rows[0][0].ToString());
            }

            return null;
        }

        /// <summary>
        /// Obtener documento referencia.
        /// </summary>
        /// <param name="noDoc"></param>
        /// <param name="idTipoDoc"></param>
        /// <returns></returns>
        public DataTable ObtenerDocumentoReferencia(int noDoc, int idTipoDoc)
        {
            return Coneccion.EjecutarSpDataTable("spObtenerDocumentoReferencia", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("NoDoc", SqlDbType.Int)).Value = noDoc;
                cmd.Parameters.Add(new SqlParameter("IdTipoDoc", SqlDbType.Int)).Value = idTipoDoc;

                return 0;
            });
        }
    }
}