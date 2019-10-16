using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Servicios.General;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    /// <summary>
    /// Servicio acciones
    /// </summary>
    public class ServicioAcciones : ServicioBase
    {
        /// <summary>
        /// Mostrar acciones
        /// </summary>
        /// <param name="gc"></param>
        /// <param name="gv"></param>
        public void MostrarAcciones(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarTextTable("select Id, Nombre, Auditable from Accion;", null);

            gv.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// Obtener Accion
        /// </summary>
        /// <param name="idAccion"></param>
        /// <returns></returns>
        public DataRow ObtenerAccion(int idAccion)
        {
            dataTable = Coneccion.EjecutarTextTable("select * from Accion where Id = @Id", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = idAccion;

                return 0;
            });

            if (dataTable != null && dataTable.Rows.Count > 0) return dataTable.Rows[0];
            return null;
        }

        /// <summary>
        /// Esta en uso el nombre en acciones???
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EstaEnUsoNombreDeAccion(string nombre, int id)
        {
            return Convert.ToInt32(
                       Coneccion.ObterResultadoText("select count(*) from Accion where Id <> @Id and Nombre = @Nombre",
                           cmd =>
                           {
                               cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = nombre;
                               cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                               return 0;
                           }))
                   > 0;
        }
    }
}