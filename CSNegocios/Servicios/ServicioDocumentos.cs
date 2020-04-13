using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Modelos;
using CSNegocios.Servicios.General;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    /// <summary>
    /// Servicios de documentos
    /// </summary>
    public class ServicioDocumentos : ServicioBase
    {
        /// <summary>
        /// Carga tipo de movimientos
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        public void CargarTipoMovs(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarTextTable("select IdTipoMov,TipoMov from TipoMov;");

            gv.Columns["IdTipoMov"].Width = 20;
        }

        /// <summary>
        /// Carga tipo de movimientos en un Glue
        /// </summary>
        /// <param name="glue"></param>
        public void CargarTipoMovs(GridLookUpEdit glue)
        {
            glue.Properties.DataSource = Coneccion.EjecutarTextTable("select IdTipoMov,TipoMov from TipoMov;");
            glue.Properties.DisplayMember = "TipoMov";
            glue.Properties.ValueMember = "IdTipoMov";

            glue.EditValue = glue.Properties.GetKeyValue(0);
        }

        /// <summary>
        /// Carga tipo documentos
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        public void CargarTipoDocs(GridControl gc, GridView gv)
        {
            strSql = "select t.IdTipoDoc, t.IdTipoMov, t.TipoDoc, e.Nombre as Empresa " +
                     "from TipoDoc t inner join Empresas E on t.IdEmpresa = E.IdEmpresa;";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql);

            gv.Columns["IdTipoMov"].Width = 20;
            gv.Columns["IdTipoDoc"].Width = 20;
        }

        /// <summary>
        /// Cargar cuentas del documento
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        /// <param name="idDoc"></param>
        /// <param name="idMov"></param>
        public void CargarCuentasDelDoc(GridControl gc, GridControl gv, int idDoc, int idMov)
        {
            strSql =
                "select SubTotal_D,Descuento_D,IVA_D,Retenciones_D," +
                "Total_D,SubTotal_H,Descuento_H,IVA_H,Retenciones_H," +
                "Total_H,Cuenta_D,Otras_D,Otras_H,Costos_D,Costos_H,Cuenta1_D," +
                "Cuenta2_D, Cuenta3_D from TipoDoc " +
                "where IdTipoDoc = @IdDoc and IdTipoMov = @IdMov";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql, cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdDoc", SqlDbType.Int)).Value = idDoc;
                cmd.Parameters.Add(new SqlParameter("IdMov", SqlDbType.Int)).Value = idMov;
            });
        }

        /// <summary>
        /// Cargar las brechas del tipo doc en un grid
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        public void CargarBrechasDelTipoDoc(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarSpDataTable("spObtenerBrechasDeTipoDoc");
        }

        /// <summary>
        /// Obtiene el tipo de movimeinto
        /// </summary>
        /// <param name="idTipoMov"></param>
        /// <returns></returns>
        public DataRow ObtenerTipoMov(int idTipoMov)
        {
            strSql = "select IdTipoMov, TipoMov, Afectaciones, Presupuesto " +
                     "from TipoMov where IdTipoMov = @Id;";

            dataTable = Coneccion.EjecutarTextTable(strSql,
                cmd => { cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = idTipoMov; });

            if (dataTable != null && dataTable.Rows.Count > 0) return dataTable.Rows[0];
            else return null;
        }

        /// <summary>
        /// Obtiene el tipo documento 
        /// </summary>
        /// <param name="idTipoMov"></param>
        /// <param name="idTipoDoc"></param>
        /// <returns></returns>
        public new DataRow ObtenerTipoDoc(int idTipoMov, int idTipoDoc)
        {
            strSql = "select IdTipoDoc,TipoDoc," +
                     " IdTipoMov, Comentario, NoInicial,IdEmpresa," +
                     "Contabiliza,Activo,Existencias,Cobertura_Mínima,Impresora" +
                     " from TipoDoc where IdTipoMov = @IdMov and IdTipoDoc = @IdDoc;";


            dataTable = Coneccion.EjecutarTextTable(strSql,
                cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("@IdMov", SqlDbType.Int)).Value = idTipoMov;
                    cmd.Parameters.Add(new SqlParameter("@IdDoc", SqlDbType.Int)).Value = idTipoDoc;
                });


            if (dataTable != null && dataTable.Rows.Count > 0) return dataTable.Rows[0];
            else return null;
        }

        /// <summary>
        /// Guardar tipo movimiento
        /// </summary>
        /// <param name="tipoMovimiento"></param>
        /// <param name="usuario"></param>
        public void GuardarTipoMovimiento(TipoMovimiento tipoMovimiento, string usuario)
        {
            Coneccion.EjecutarSp("spGuardarTipoMovAdmin",
                cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("@IdTipoMov", SqlDbType.Int)).Value = tipoMovimiento.IdTipoMov;
                    cmd.Parameters.Add(new SqlParameter("@TipoMov", SqlDbType.NVarChar)).Value = tipoMovimiento.TipoMov;
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.NVarChar)).Value = usuario;
                    cmd.Parameters.Add(new SqlParameter("@Afectaciones", SqlDbType.SmallInt)).Value =
                        tipoMovimiento.Afectaciones;
                    cmd.Parameters.Add(new SqlParameter("@Presupuesto", SqlDbType.Float)).Value =
                        tipoMovimiento.Presupuesto;
                });
        }

        /// <summary>
        /// Guarda los tipos de documentos
        /// </summary>
        /// <param name="tipoDocumento"></param>
        /// <param name="usuario"></param>
        public void GuardarTipoDocumento(TipoDocumento tipoDocumento, string usuario, int idLogin)
        {
            Coneccion.EjecutarSp("spGuardarTipoDocAdmin", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdTipoMov", SqlDbType.Int)).Value = tipoDocumento.IdTipoMov;
                cmd.Parameters.Add(new SqlParameter("IdTipoDoc", SqlDbType.Int)).Value = tipoDocumento.IdTipoDoc;
                cmd.Parameters.Add(new SqlParameter("NoInicial", SqlDbType.Int)).Value = tipoDocumento.NoInicial;
                cmd.Parameters.Add(new SqlParameter("TipoDoc", SqlDbType.NVarChar)).Value = tipoDocumento.TipoDoc;
                cmd.Parameters.Add(new SqlParameter("Existencias", SqlDbType.Int)).Value = tipoDocumento.Existencias;
                cmd.Parameters.Add(new SqlParameter("CoberturaMin", SqlDbType.Int)).Value =
                    tipoDocumento.Cobertura_Mínima;
                cmd.Parameters.Add(new SqlParameter("Contabiliza", SqlDbType.Bit)).Value = tipoDocumento.Contabiliza;
                cmd.Parameters.Add(new SqlParameter("Activo", SqlDbType.Bit)).Value = tipoDocumento.Activo;
                cmd.Parameters.Add(new SqlParameter("IdEmpresa", SqlDbType.Int)).Value = tipoDocumento.IdEmpresa;
                cmd.Parameters.Add(new SqlParameter("Impresora", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(tipoDocumento.Impresora);
                cmd.Parameters.Add(new SqlParameter("Comentario", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(tipoDocumento.Comentario);
                cmd.Parameters.Add(new SqlParameter("Usuario", SqlDbType.NVarChar)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("IdLogin", SqlDbType.Int)).Value = idLogin;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTipoDoc"></param>
        /// <param name="idTipoMov"></param>
        /// <returns></returns>
        public bool ElIdDelDocumentoYaEstaSiendoUsado(int idTipoDoc, int idTipoMov)
        {
            strSql = "select count(*) from TipoDoc where IdTipoMov = @TipoMov and IdTipoDoc =@TipDoc";

            return Convert.ToInt32(Coneccion.ObterResultadoText(strSql, cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@TipoMov", SqlDbType.Int)).Value = idTipoMov;
                cmd.Parameters.Add(new SqlParameter("@TipDoc", SqlDbType.Int)).Value = idTipoDoc;
            })) > 0;
        }
    }
}