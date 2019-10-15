using System;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CSPresentacion
{
    /// <summary>
    ///     Global
    /// </summary>
    public static class Global
    {
        /// <summary>
        ///     Nueva password
        /// </summary>
        public static string NuevaPassword { get; set; }

        /// <summary>
        ///     Nombre de la compania
        /// </summary>
        public static string NombreCompany { get; set; }


        //*******************************************Reembolso*****************
        /// <summary>
        ///     Fecha inicial
        /// </summary>
        public static DateEdit FechaFinal { get; set; }

        /// <summary>
        ///     Habilitar
        /// </summary>
        public static bool Habilitar { get; set; }

        /// <summary>
        ///     Gerencia
        /// </summary>
        public static string Gerencia { get; set; }

        /// <summary>
        ///     Usuario Reporte
        /// </summary>
        public static string UsuarioReporte { get; set; }

        /// <summary>
        ///     Reembolso contabilidad
        /// </summary>
        public static bool ReembolsoContabilidad { get; set; }

        /// <summary>
        ///     Mostrar todas las sucursales
        /// </summary>
        public static bool MostrarTodasLasSucursales { get; set; }

        /// <summary>
        ///     Usuario busqueda
        /// </summary>
        public static string UsuarioBusqueda { get; set; }

        /// <summary>
        ///     Documento  aplicado
        /// </summary>
        public static bool DocumentoAplicado { get; set; }

        /// <summary>
        ///     Id Empresa reporte
        /// </summary>
        public static string IdEmpresaReporte { get; set; }

        /// <summary>
        ///     Oritentacion pagina
        /// </summary>
        public static bool OrientacionPagina { get; set; }

        /// <summary>
        ///     Id Pendientes
        /// </summary>
        public static string IDPendientes { get; set; }

        /// <summary>
        ///     Opcion cheque
        /// </summary>
        public static int OpcionCheque { get; set; }


        //*********************************************************************
        /// <summary>
        ///     NOmbre de la sucursal
        /// </summary>
        public static string NombreSucursal { get; set; }

        /// <summary>
        ///     Nombre de la empresa
        /// </summary>
        public static string NombreEmpresa { get; set; }

        /// <summary>
        ///     Id Login
        /// </summary>
        public static int IDLoguin { get; set; }

        /// <summary>
        ///     Computadora
        /// </summary>
        public static string PC { get; set; }

        /// <summary>
        ///     Version sistema local
        /// </summary>
        public static string VersionSistemaLocal { get; set; }

        /// <summary>
        ///     Usuario
        /// </summary>
        public static string User { get; set; }

        /// <summary>
        ///     Doble click
        /// </summary>
        public static bool DoubleClick { get; set; }

        /// <summary>
        ///     Doble click pendiente
        /// </summary>
        public static bool DoubleClickPendiente { get; set; }

        /// <summary>
        ///     Ip publico
        /// </summary>
        public static string IPPublico { get; set; }

        /// <summary>
        ///     Ip local
        /// </summary>
        public static string IPLocal { get; set; }

        /// <summary>
        ///     Nombre de la ip
        /// </summary>
        public static string Nombre_IP { get; set; }

        /// <summary>
        ///     Id empresa
        /// </summary>
        public static string ID_Empresa { get; set; }

        /// <summary>
        ///     Estado del servidor
        /// </summary>
        public static string EstadoServidor { get; set; }

        /// <summary>
        ///     Nombre Archivo INi
        /// </summary>
        public static string NombreArchivoIni { get; set; }

        /// <summary>
        ///     Nombre Skin
        /// </summary>
        public static string NombreSkin { get; set; }

        /// <summary>
        ///     Quitar Comillas
        /// </summary>
        /// <param name="Valor"></param>
        /// <returns></returns>
        public static string QuitarComillas(string Valor)
        {
            return Valor.Replace("'", " ").Replace('"', ' ');
        }

        /// <summary>
        ///     Sql Date hasta
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string sqlDateHasta(DateEdit dt)
        {
            //string functionReturnValue = null;
            try
            {
                dt.Properties.DisplayFormat.FormatType = FormatType.DateTime;
                dt.Properties.DisplayFormat.FormatString = "yyyy";

                string año = dt.Text;

                dt.Properties.DisplayFormat.FormatType = FormatType.DateTime;
                dt.Properties.DisplayFormat.FormatString = "MM";

                string mes = dt.Text;

                dt.Properties.DisplayFormat.FormatType = FormatType.DateTime;
                dt.Properties.DisplayFormat.FormatString = "dd";

                string dia = dt.Text;

                return "'" + año + "-" + mes + "-" + dia + " " + "23:59:59'";

                //functionReturnValue = "'" +   DateAndTime.Year(dt) + "-" + DateAndTime.Month(dt) + "-" + DateAndTime.Day(dt) + " " + "23:59:59'";
            }
            catch (Exception)
            {
                return "";
            }

            //return functionReturnValue;
        }

        /// <summary>
        ///     Sql Date
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string sqlDate(DateEdit dt)
        {
            try
            {
                dt.Properties.DisplayFormat.FormatType = FormatType.DateTime;
                dt.Properties.DisplayFormat.FormatString = "yyyy";

                string año = dt.Text;

                dt.Properties.DisplayFormat.FormatType = FormatType.DateTime;
                dt.Properties.DisplayFormat.FormatString = "MM";

                string mes = dt.Text;

                dt.Properties.DisplayFormat.FormatType = FormatType.DateTime;
                dt.Properties.DisplayFormat.FormatString = "dd";

                string dia = dt.Text;

                return "'" + año + "-" + mes + "-" + dia + "'";

                //2016-06-20 11:05:34
                //return "'" + dt.Properties.Mask.EditMask = "YYYY" + "-" + dt.Properties.Mask.EditMask = "MMMM" +"-" + DateAndTime.Day(dt) + "'";
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        ///     Array to String
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ArrayToString(int[] arr)
        {
            string text = "";
            if (arr == null)
                text = "Empty...";
            else
                for (int i = 0; i <= arr.Length - 1; i++)
                {
                    int num = arr[i];
                    text = text + (string.IsNullOrEmpty(text) ? "" : ";") + num;
                }

            return text;
        }
    }
}