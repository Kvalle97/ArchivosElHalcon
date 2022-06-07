using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSDatos;
using CSNegocios.Modelos;
using CSNegocios.Servicios.General;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    public class ServicioProveedorinformatica : ServicioBase
    {



        //public DataRow Cargarproveedoresdatable(int IdProveedor)
        //{
        //    dataTable = Coneccion.EjecutarSpDataTable("spObtenerProveedorInformatica",
        //        cmd => { cmd.Parameters.Add(new SqlParameter("IdProveedor", SqlDbType.Int)).Value = IdProveedor; });

        //    return dataTable != null && dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        //}

        public DataRow Obtenercontactosdatable(int idproveedor, GridControl gc, GridView gv)
        {

            gv.Columns.Clear();
            gc.DataSource = Coneccion.EjecutarSpDataTable("spObtenerProveedorContactoinformatica",
                cmd => { cmd.Parameters.Add(new SqlParameter("IdProveedor", SqlDbType.Int)).Value = idproveedor; });

            gv.Columns["Idproveedor"].Visible = false;
            gv.Columns["IdContacto"].Visible = false;
            gv.Columns["Contacto"].Width = 20;
            gv.Columns["Correo"].Width = 30;
            gv.Columns["Cargo"].Width = 10;
            gv.Columns["Celular"].Width = 10;
            return dataTable != null && dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

        }

        public void CargarContactos(GridControl gce, GridView gve)
        {

            gce.DataSource = Coneccion.EjecutarSpDataTable("spObtenerContactos", null);
            gve.Columns["Idproveedor"].Width = 10;
            gve.Columns["IdContacto"].Visible = false;
            gve.Columns["Contacto"].Width = 10;
            gve.Columns["Correo"].Width = 10;
            gve.Columns["Cargo"].Width = 10;
            gve.Columns["Celular"].Width = 10;

            //gve.BestFitColumns();
        }



        public int EliminarProveedor(int IdProveedor)
        {
            return Coneccion.EjecutarSp("spEliminarProveedorinformatica", command =>
            {
                command.Parameters.Add(new SqlParameter("IdProveedor", SqlDbType.Int)).Value = IdProveedor;
            });
        }


        public Modeloproveedorinformatica ObtenerProveedorinf(int IdProveedor)      /*ojo con esto */
        {
            dataTable = null;
            dataTable = Coneccion.EjecutarSpDataTable("spObtenerProveedorInformatica",
                command =>
                {
                    command.Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.Int)).Value = IdProveedor;
                });

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Modeloproveedorinformatica modeloproveedorinformatica = new Modeloproveedorinformatica();
                DataRow row = dataTable.Rows[0];

                modeloproveedorinformatica.IdProveedor = int.Parse(row["Codigo"].ToString());
                modeloproveedorinformatica.Descripcion = (string)row["Descripcion"];


                modeloproveedorinformatica.Contacto = dataTable.Rows[0]["Contacto"] != DBNull.Value
                ? Convert.ToString(dataTable.Rows[0]["Contacto"])
                : null;

                modeloproveedorinformatica.NoContacto = dataTable.Rows[0]["NoContacto"] != DBNull.Value
                ? Convert.ToString(dataTable.Rows[0]["NoContacto"])
                : null;

                return modeloproveedorinformatica;
            }

            return null;

        }

        public int GuardarProveedor(Modeloproveedorinformatica proveedorinformatica, int login)
        {
            return Coneccion.EjecutarSp("spGuardarProveedoresInformatica", command =>
            {
                command.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.NVarChar)).Value =
                   RevisarSiEsNuloSql(proveedorinformatica.Descripcion);
                command.Parameters.Add(new SqlParameter("Dirección", SqlDbType.NVarChar)).Value =
                RevisarSiEsNuloSql(proveedorinformatica.Dirección);
                command.Parameters.Add(new SqlParameter("NoRuc", SqlDbType.NVarChar)).Value =
                RevisarSiEsNuloSql(proveedorinformatica.NoRuc);
                command.Parameters.Add(new SqlParameter("Sucursal", SqlDbType.NVarChar)).Value = proveedorinformatica.Sucursal;
                command.Parameters.Add(new SqlParameter("Correo", SqlDbType.NVarChar)).Value =
                RevisarSiEsNuloSql(proveedorinformatica.Correo);
                command.Parameters.Add(new SqlParameter("Teléfono", SqlDbType.NVarChar)).Value =
                RevisarSiEsNuloSql(proveedorinformatica.Teléfono);
                command.Parameters.Add(new SqlParameter("Nombre_Contacto", SqlDbType.NVarChar)).Value =
                   RevisarSiEsNuloSql(proveedorinformatica.Contacto);
                command.Parameters.Add(new SqlParameter("Celular", SqlDbType.NVarChar)).Value =
                RevisarSiEsNuloSql(proveedorinformatica.NoContacto);
                command.Parameters.Add(new SqlParameter("Correo_Contacto", SqlDbType.NVarChar)).Value = proveedorinformatica.Correo_Contacto;
                command.Parameters.Add(new SqlParameter("Cargo", SqlDbType.NVarChar)).Value = proveedorinformatica.Cargo;
                command.Parameters.Add(new SqlParameter("idLogin", SqlDbType.NVarChar)).Value = login;


            });

        }

        public string Obtenerultimoregistro(int IdProveedor)
        {
            return Convert.ToString(Coneccion.ObterResultadoText("SELECT TOP (1) IdProveedor + 1  FROM ProveedoresInformatica order by IdProveedor desc;",
               cmd =>
               {
                   cmd.Parameters.Add(new SqlParameter("IdProveedor", SqlDbType.Int)).Value = IdProveedor;

               }));
        }

        public int Agregarnuevocontacto(string idcontacto, string idproveedor, string nombre, string celular, string correo, string cargo)
        {

            return Coneccion.EjecutarSp("spAgregarcontacto", command =>
            {
                command.Parameters.Add(new SqlParameter("IdContacto", SqlDbType.NVarChar)).Value = idcontacto;
                command.Parameters.Add(new SqlParameter("IdProveedor", SqlDbType.NVarChar)).Value = idproveedor;
                command.Parameters.Add(new SqlParameter("Nombre_Contacto", SqlDbType.NVarChar)).Value = nombre;
                command.Parameters.Add(new SqlParameter("Celular", SqlDbType.NVarChar)).Value = celular;
                command.Parameters.Add(new SqlParameter("Correo_Contacto", SqlDbType.NVarChar)).Value = correo;
                command.Parameters.Add(new SqlParameter("Cargo", SqlDbType.NVarChar)).Value = cargo;
            });
        }


        public void ObtenerProveedores(GridControl gce, GridView gve)
        {

            gce.DataSource = Coneccion.EjecutarSpDataTable("spObtenerProveedoresInformatica", null);
            gve.Columns["IdProveedor"].Width = 10;
            gve.Columns["Proveedor"].Width = 100;
            gve.Columns["Dirección"].Width = 100;
            gve.Columns["NoRuc"].Width = 50;
            gve.Columns["Correo"].Width = 100;
            gve.Columns["Teléfono"].Width = 50;
            //gve.Columns["Teléfono"].Visible=false;
            //gve.BestFitColumns();
        }


        public Modeloproveedorinformatica Obtenerproveedorinformatica(int idproveedor)
        {
            dataTable = null;
            dataTable = Coneccion.EjecutarSpDataTable("spCargarProveedorInformatica", cmd =>
           {

               cmd.Parameters.Add("Idproveedor", SqlDbType.Int).Value = idproveedor;
           });

            if (dataTable != null && dataTable.Rows.Count > 0)
            {

                Modeloproveedorinformatica proveedorinformatica = new Modeloproveedorinformatica();

                proveedorinformatica.IdProveedor = idproveedor;
                proveedorinformatica.Descripcion = Convert.ToString(dataTable.Rows[0]["Proveedor"]);
                proveedorinformatica.Dirección = Convert.ToString(dataTable.Rows[0]["Dirección"]);
                proveedorinformatica.NoRuc = Convert.ToString(dataTable.Rows[0]["NoRuc"]);
                proveedorinformatica.Sucursal = Convert.ToString(dataTable.Rows[0]["Sucursal"]);
                proveedorinformatica.Correo = Convert.ToString(dataTable.Rows[0]["Correo"]);
                proveedorinformatica.Teléfono = Convert.ToString(dataTable.Rows[0]["Teléfono"]);

                return proveedorinformatica;

            }
            return null;
        }

        public int Eliminar_Contacto(int codigo)
        {
            return Coneccion.EjecutarSp("spEliminarContacto", cmd =>
            {
                cmd.Parameters.Add(new SqlParameter("IdContacto", SqlDbType.Int)).Value =
                RevisarSiEsNuloSql(codigo);
            });
        }
    }

}

