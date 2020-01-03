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

namespace CSNegocios.Servicios
{
    public class ServicioInformacion : ServicioBase
    {
        public void ActualizarInformacion(Informacion informacion)
        {
            strSql = "update información " +
                     "set Compañía       = @comp, " +
                     "    RUC            = @ruc, " +
                     "    Logo           = @log, " +
                     "    DatosGenerales = @dg " +
                     "where ID = 1; ";

            Coneccion.EjecutarSpText(strSql, cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@comp", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(informacion.Compania);
                cmd.Parameters.Add(new SqlParameter("@ruc", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(informacion.Ruc);
                cmd.Parameters.Add(new SqlParameter("@log", SqlDbType.Image)).Value =
                    RevisarSiEsNuloSql(informacion.Logo);
                cmd.Parameters.Add(new SqlParameter("@dg", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(informacion.Direccion);
            });
        }

        /// <summary>
        /// Obtiene la informacion
        /// </summary>
        /// <returns></returns>
        public Informacion ObtenerInformacion()
        {
            Informacion informacion = new Informacion();

            strSql = "select Compañía, RUC, Logo, DatosGenerales from información where Id = 1;";

            dataTable = Coneccion.EjecutarTextTable(strSql);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];

                informacion.Compania = dr["Compañía"] != DBNull.Value ? Convert.ToString(dr["Compañía"]) : string.Empty;
                informacion.Ruc = dr["RUC"] != DBNull.Value ? Convert.ToString(dr["RUC"]) : string.Empty;
                informacion.Direccion = dr["DatosGenerales"] != DBNull.Value
                    ? Convert.ToString(dr["DatosGenerales"])
                    : string.Empty;

                informacion.Logo = dr["Logo"] != DBNull.Value
                    ? (byte[]) dr["Logo"]
                    : null;
            }

            return informacion;
        }
    }
}