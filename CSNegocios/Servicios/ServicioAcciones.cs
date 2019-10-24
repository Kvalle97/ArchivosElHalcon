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
                               
                           }))
                   > 0;
        }

        /// <summary>
        /// Guarda la accion
        /// </summary>
        /// <param name="accion">Modelo que contiene los datos de accion</param>
        public void GuardarAccion(Accion accion)
        {
            Coneccion.EjecutarSp("spGuardarAccion", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = accion.Id;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = accion.Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value =
                    RevisarSiEsNuloSql(accion.Descripcion);
                cmd.Parameters.Add(new SqlParameter("@Auditable", SqlDbType.Bit)).Value = accion.Auditable;
                
            });
        }

        /// <summary>
        /// Eliminar accion
        /// </summary>
        /// <param name="id">Id de la accion</param>
        public void EliminarAccion(int id)
        {
            Coneccion.EjecutarSpText("delete Accion where Id = @Id", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
               
            });
        }

        /// <summary>
        /// Mostrar roles
        /// </summary>
        /// <param name="gc">Grid control</param>
        /// <param name="gv">Grid view</param>
        public void MostrarRoles(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarTextTable("select Id, Nombre, EsSuperAdministrador from Rol;", null);

            gv.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// Mostrar acceso base
        /// </summary>
        /// <param name="gc">Grid control</param>
        /// <param name="gv">Grid view</param>
        public void MostrarAccesoBase(GridControl gc, GridView gv)
        {
            gc.DataSource = Coneccion.EjecutarSpDataTable("spAccesoBase", null);

            gv.Columns["IdPantalla"].Visible = false;
            gv.Columns["IdAccion"].Visible = false;

            gv.Columns["Pantalla"].Group();
            gv.OptionsSelection.MultiSelect = true;
            gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
        }

        /// <summary>
        /// Obtiene el rol segun id
        /// </summary>
        /// <param name="id">Id de rol</param>
        /// <returns>DataRow</returns>
        public DataRow ObtenerRol(int id)
        {
            dataTable = Coneccion.EjecutarTextTable("select * from Rol where Id = @Id", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                
            });

            if (dataTable != null && dataTable.Rows.Count > 0) return dataTable.Rows[0];
            return null;
        }

        /// <summary>
        /// Esta en uso nombre de rol
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public bool EstaEnUsoNombreDeRol(string nombre, int id)
        {
            return Convert.ToInt32(
                       Coneccion.ObterResultadoText("select COUNT(*) from Rol where Id <> @Id and Nombre = @Nombre",
                           cmd =>
                           {
                               cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                               cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = nombre;
                              
                           })
                   ) > 0;
        }

        /// <summary>
        /// Obtener acceso del rol
        /// </summary>
        /// <param name="idRol"></param>
        /// <returns></returns>
        public DataTable ObtenerAccesoDelRol(int idRol)
        {
            return Coneccion.EjecutarTextTable("select IdPantalla, IdAccion from AccesoRol where IdRol = @IdRol ",
                cmd =>
                {
                    cmd.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int)).Value = idRol;
                });
        }

        /// <summary>
        /// Guardar Rol
        /// </summary>
        /// <param name="rol"></param>
        public void GuardarRol(Rol rol)
        {
            Coneccion.EjecutarSp("spGuardarRol", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.NVarChar)).Value = rol.Id;
                cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar)).Value = rol.Nombre;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar)).Value = RevisarSiEsNuloSql(rol.Descripcion);
                cmd.Parameters.Add(new SqlParameter("EsSuperAdministrador", SqlDbType.NVarChar)).Value = rol.EsSuperAdministrador;
                
            });
        }
        /// <summary>
        /// Limpia los accesos segun el rol
        /// </summary>
        /// <param name="id">Id del rol</param>
        public void LimpiarAcceso(int id)
        {
            Coneccion.EjecutarSpText("delete AccesoRol where IdRol = @IdRol", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdRol", SqlDbType.NVarChar)).Value = id;
                

            });
        }

        /// <summary>
        /// Guardar acceso
        /// </summary>
        /// <param name="idRol"></param>
        /// <param name="idPantalla"></param>
        /// <param name="idAccion"></param>
        public void GuardarAcceso(int idRol, int idPantalla, int idAccion)
        {
            Coneccion.EjecutarSpText("insert into AccesoRol (IdRol, IdPantalla, IdAccion) " +
                                 "values (@IdRol, @IdPantalla, @IdAccion)", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("@IdRol",SqlDbType.Int)).Value = idRol;
                cmd.Parameters.Add(new SqlParameter("@IdPantalla",SqlDbType.Int)).Value = idPantalla;
                cmd.Parameters.Add(new SqlParameter("@IdAccion",SqlDbType.Int)).Value = idAccion;
                
            });
        }
    }
}