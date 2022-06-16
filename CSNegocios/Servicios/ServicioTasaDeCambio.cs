using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using CSDatos;
using CSNegocios.Modelos;
using CSNegocios.ni.gob.bcn.servicios;
using CSNegocios.Servicios.General;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace CSNegocios.Servicios
{
    public class ServicioTasaDeCambio : ServicioBase
    {
        public void CargarTasaDeCambioHalcon(GridControl gc, GridView gv)
        {
            gv.Columns.Clear();

            strSql = "select Fecha, Tc, TC_GERENCIA from halcon.dbo.TC order by Fecha desc;";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql, null);
        }

        public void CargarTasaDeCambioContable(GridControl gc, GridView gv)
        {
            gv.Columns.Clear();

            strSql = "select Fecha, Tc from Contabilidad.dbo.TC order by Fecha desc;";

            gc.DataSource = Coneccion.EjecutarTextTable(strSql, null);
        }

        public decimal ConsultarTcDelDia(DateTime fecha)
        {
            Tipo_Cambio_BCN objService = new Tipo_Cambio_BCN();

            return Convert.ToDecimal(
                objService.RecuperaTC_Dia(fecha.Year, fecha.Month, fecha.Day));
        }

        public void InsertarTcDelMes(DateTime fecha, bool sobreEscribir, string usuario)
        {
            Tipo_Cambio_BCN objService = new Tipo_Cambio_BCN();

            var nodeList = objService.RecuperaTC_Mes(fecha.Year, fecha.Month).ChildNodes;

            List<TasaDeCambioM> lstTasaDeCambio = new List<TasaDeCambioM>();

            if (nodeList.Count <= 0) throw new Exception("El servicio no devolvio nada :)");

            foreach (XmlNode node in nodeList)
            {
                lstTasaDeCambio.Add(new TasaDeCambioM()
                {
                    Fecha =
                        Convert.ToDateTime(node.ChildNodes[0].InnerText),
                    TasaDeCambio =
                        Convert.ToDecimal(
                            node.ChildNodes[1].InnerText)
                });
            }

            decimal gerencial = lstTasaDeCambio.OrderByDescending(x => x.Fecha).First().TasaDeCambio;

            lstTasaDeCambio.ForEach(x => { GuardarTc(x, usuario, gerencial, sobreEscribir); });

        }




        //Función 

        public void Insertartcgerencial(DateTime fecha, bool sobreEscribir, bool cktcgerencial, string usuario, decimal spingerencial)
        {
            Tipo_Cambio_BCN objService = new Tipo_Cambio_BCN();

            var nodeList = objService.RecuperaTC_Mes(fecha.Year, fecha.Month).ChildNodes;

            List<TasaDeCambioM> lstTasaDeCambio = new List<TasaDeCambioM>();

            if (nodeList.Count <= 0) throw new Exception("El servicio no devolvio nada :)");

            foreach (XmlNode node in nodeList)
            {
                lstTasaDeCambio.Add(new TasaDeCambioM()
                {
                    Fecha =
                        Convert.ToDateTime(node.ChildNodes[0].InnerText),
                    TasaDeCambio =
                        Convert.ToDecimal(
                            node.ChildNodes[1].InnerText)
                });
            }

            decimal gerencial;

            if (cktcgerencial == true)
            {
                gerencial = spingerencial;
            }
            else
            {
                gerencial = lstTasaDeCambio.OrderByDescending(x => x.Fecha).First().TasaDeCambio;
            }

            lstTasaDeCambio.ForEach(x => { GuardarTc(x, usuario, gerencial, sobreEscribir); });

        }




        public void GuardarTc(TasaDeCambioM t, string usuario, decimal tcGerencia, bool sobreeEscribir)
        {
            Coneccion.EjecutarSp("spGuardarTc", cmd =>
            {
                cmd.Parameters.Add("Fecha", SqlDbType.DateTime).Value = t.Fecha.Date;
                cmd.Parameters.Add("Tc", SqlDbType.Money).Value = t.TasaDeCambio;
                cmd.Parameters.Add("TcGerencia", SqlDbType.Money).Value = tcGerencia;
                cmd.Parameters.Add("Usuario", SqlDbType.NVarChar).Value = usuario;
                cmd.Parameters.Add("SobreEscribir", SqlDbType.Bit).Value = sobreeEscribir;
            });
        }
    }
}