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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    /// <summary>
    /// Servicios sistemas y pantallas
    /// </summary>
    public class ServicioSistemasyPantallas : ServicioBase
    {
        /// <summary>
        /// Muestra los sistemas guardados
        /// </summary>
        /// <param name="gc">Grid control</param>
        /// <param name="gv">Grid view</param>
        public void MostrarSistemas(GridControl gc, GridView gv)
        {
            gc.DataSource =
                Coneccion.EjecutarTextTable(
                    "select Id, Nombre, NombreAMostrar as [Nombre a mostrar] from SistemaOModulo;", null);

            gv.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// Obtener sistema o modulo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataRow ObtenerSistemaOModulo(int id)
        {
            dataTable = Coneccion.EjecutarTextTable("select * from SistemaOModulo where Id = @Id", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                return 0;
            });

            if (dataTable != null && dataTable.Rows.Count > 0) return dataTable.Rows[0];
            return null;
        }

        /// <summary>
        /// Guarda el elemento
        /// </summary>
        /// <param name="sistemaOModulo">Modelo sistema o modulo</param>
        public void GuardarSistemaOModulo(SistemaOModulo sistemaOModulo)
        {
            Coneccion.EjecutarSp("spGuardarSistemaOModulo",
                cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = sistemaOModulo.Id;
                    cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = sistemaOModulo.Nombre;
                    cmd.Parameters.Add(new SqlParameter("@NombreAMostrar", SqlDbType.NVarChar)).Value =
                        RevisarSiEsNuloSql(sistemaOModulo.NombreAMostrar);
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value =
                        RevisarSiEsNuloSql(sistemaOModulo.Descripcion);
                    cmd.Parameters.Add(new SqlParameter("@UrlActualizador", SqlDbType.NVarChar)).Value =
                        RevisarSiEsNuloSql(sistemaOModulo.UrlActualizador);

                    return 0;
                });
        }

        /// <summary>
        /// Indica si el nombre esta en uso.
        /// </summary>
        /// <param name="id">Revisa todos menos el id</param>
        /// <param name="nombre">Revisa todos menos el id</param>
        /// <returns></returns>
        public bool ElNombreDelSistemaEstaEnUso(int id, string nombre)
        {
            return Convert.ToInt32(Coneccion.ObterResultadoText(
                       "select COUNT(*) from SistemaOModulo where Id <> @Id and Nombre = @Nombre",
                       cmd =>
                       {
                           cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                           cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.Int)).Value = id;

                           return 0;
                       })) > 0;
        }

        /// <summary>
        /// Eliminar Sistemao
        /// </summary>
        /// <param name="id"></param>
        public void EliminarSistemaOModulo(int id)
        {
            Coneccion.EjecutarSpText("delete SistemaOModulo where Id = @Id;", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                return 0;
            });
        }
    }
}