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
using DevExpress.XtraEditors.Repository;
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
                           cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = id;
                           
                       })) > 0;
        }

        /// <summary>
        /// Eliminar Sistemao
        /// </summary>
        /// <param name="id">Id</param>
        public void EliminarSistemaOModulo(int id)
        {
            Coneccion.EjecutarSpText("delete SistemaOModulo where Id = @Id;", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                
            });
        }

        /// <summary>
        /// Mostrar Pantallas
        /// </summary>
        /// <param name="gc">Grid Control</param>
        /// <param name="gv">Grid View</param>
        public void MostrarPantallas(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarTextTable("select Id, Nombre, Descripcion from Pantalla", null);

            gv.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// Guardar Pantalla
        /// </summary>
        /// <param name="pantalla"></param>
        public void GuardarPantalla(Pantalla pantalla)
        {
            Coneccion.EjecutarSp("spGuardarPantalla", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = pantalla.Id;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = pantalla.Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(pantalla.Descripcion);
                cmd.Parameters.Add(new SqlParameter("@EsReporte", SqlDbType.Bit)).Value = pantalla.EsReporte;
                
            });
        }

        /// <summary>
        /// El nombre de la pantalla esta en uso?
        /// </summary>
        /// <param name="pantallaId"></param>
        /// <param name="pantallaNombre"></param>
        /// <returns></returns>
        public bool ElNombreDeLaPantallaEstaEnUso(int pantallaId, string pantallaNombre)
        {
            return Convert.ToInt32(Coneccion.ObterResultadoText(
                       "select COUNT(*) from SistemaOModulo where Id <> @Id and Nombre = @Nombre",
                       cmd =>
                       {
                           cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = pantallaId;
                           cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = pantallaNombre;
                           
                       })) > 0;
        }

        /// <summary>
        /// Eliminar pantalla
        /// </summary>
        /// <param name="pantallaId"></param>
        public void EliminarPantalla(int pantallaId)
        {
            Coneccion.EjecutarSpText("delete Pantalla where Id = @Id", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = pantallaId;
            });
        }

        /// <summary>
        /// Obtener Pantalla
        /// </summary>
        /// <param name="idPantalla"></param>
        /// <returns></returns>
        public DataRow ObtenerPantalla(int idPantalla)
        {
            dataTable = Coneccion.EjecutarTextTable("select * from Pantalla where Id = @Id", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = idPantalla;
                
            });

            if (dataTable != null && dataTable.Rows.Count > 0) return dataTable.Rows[0];
            return null;
        }

        /// <summary>
        /// Muestra todas las acciones en un Checked Combobox
        /// </summary>
        /// <param name="ckcb">Checked combobox</param>
        public void MostrarAcciones(CheckedComboBoxEdit ckcb)
        {
            ckcb.Properties.DataSource = Coneccion.EjecutarTextTable(
                "select Id, CONCAT(Nombre, IIF(Auditable = 1, ' (Auditable) ', '')) as Accion " +
                "from Accion;", null);

            ckcb.Properties.DisplayMember = "Accion";
            ckcb.Properties.ValueMember = "Id";
            ckcb.Properties.EditValueType = EditValueTypeCollection.List;
        }

        /// <summary>
        /// Obtener Acciones de la pantalla
        /// </summary>
        /// <param name="idPantalla">Id de la pantalla</param>
        /// <returns>Datatable</returns>
        public DataTable ObtenerAccionesDeLaPantalla(int idPantalla)
        {
            return Coneccion.EjecutarTextTable("select IdAccion from AccionEnPantalla where IdPantalla = @IdPantalla;",
                cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("@IdPantalla", SqlDbType.Int)).Value = idPantalla;
                   
                });
        }

        /// <summary>
        /// Guardar Acciones de pantalla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lstAcciones">Generic list acciones</param>
        public void GuardarAccioneDePantalla(int id, List<object> lstAcciones)
        {
            // Eliminamos las Acciones de pantalla
            Coneccion.EjecutarSpText("delete AccionEnPantalla where IdPantalla = @IdPantalla;", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@IdPantalla", SqlDbType.Int)).Value = id;
               
            });

            foreach (int accion in lstAcciones)
            {
                Coneccion.EjecutarSpText("insert into AccionEnPantalla (IdPantalla, IdAccion)" +
                                         " VALUES (@IdPantalla, @IdAccion)", cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("@IdPantalla", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@IdAccion", SqlDbType.Int)).Value = accion;
                    
                });
            }
        }
    }
}