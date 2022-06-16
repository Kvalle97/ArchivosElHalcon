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

namespace CSNegocios.Servicios
{
    public class ServicioNavegacion : ServicioBase


    {
        public DataTable ObtenerNavegacion(int idUsuario, DateTime desde, DateTime hasta)
        {
            return Coneccion.EjecutarSpDataTable("spObtenerReporteNavegacion"
                , cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = idUsuario;
                    cmd.Parameters.Add(new SqlParameter("Desde", SqlDbType.Date)).Value = desde;
                    cmd.Parameters.Add(new SqlParameter("Hasta", SqlDbType.Date)).Value = hasta;
                });
        }

        public void CargarUsarios(GridLookUpEdit glue)
        {
            strSql = "select -1 as IdUsuario, 'TODOS LOS USARIOS' as Usuario" +
                     " union" +
                     " select IdUsuario,Usuario from Usuarios where Activo = 1 order by IdUsuario;";

            glue.Properties.DataSource = Coneccion.EjecutarTextTable(strSql);
            glue.Properties.DisplayMember = "Usuario";
            glue.Properties.ValueMember = "IdUsuario";

            glue.ForceInitialize();
            glue.EditValue = glue.Properties.GetKeyValue(0);
        }

         public void RegistrarLog(int idUsuario, int? noDoc, int? idTipoDoc, string comentario, string sistema,
            string pantalla, string accion)
        {
            Coneccion.EjecutarSp("spRegistrarLog", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int)).Value = idUsuario;
                cmd.Parameters.Add(new SqlParameter("NoDoc", SqlDbType.Int)).Value = RevisarSiEsNuloSql(noDoc);
                cmd.Parameters.Add(new SqlParameter("IdTipoDoc", SqlDbType.Int)).Value = RevisarSiEsNuloSql(idTipoDoc);
                cmd.Parameters.Add(new SqlParameter("Comentario", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(comentario);
                cmd.Parameters.Add(new SqlParameter("Sistema", SqlDbType.NVarChar)).Value = sistema;
                cmd.Parameters.Add(new SqlParameter("Pantalla", SqlDbType.NVarChar)).Value = pantalla;
                cmd.Parameters.Add(new SqlParameter("Accion", SqlDbType.NVarChar)).Value = accion;
            });
        }
    }
}