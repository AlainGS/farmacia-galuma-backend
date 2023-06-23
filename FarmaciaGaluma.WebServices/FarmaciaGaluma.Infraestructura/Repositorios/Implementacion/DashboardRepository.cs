using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Utilidades.Utils;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace FarmaciaGaluma.Infraestructura.Repositorios.Implementacion
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly string _conectaDB;

        public DashboardRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }
                
        public Task<RARdata<BEDashBoard>> Resumen()
        {
            return Task.Run(() =>
            {
                RARdata<BEDashBoard> paqueteDatos = new RARdata<BEDashBoard>();

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_resumen_dashboard", alParameters);

                    BEDashBoard dashboard = new BEDashBoard();
                    foreach (DataRow row in dt.Rows)
                    {
                        dashboard.TotalIngresos = row["TotalIngresos"].ToString()!;
                        dashboard.TotalVentas = int.Parse(row["TotalVentas"].ToString()!);
                        dashboard.TotalProductos = int.Parse(row["TotalProductos"].ToString()!);                   
                    }
                    paqueteDatos.cuerpoData = dashboard;
                    paqueteDatos.estadoData = 1;
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_GET + ex.Message;
                }

                return paqueteDatos;
            });
        }

        public Task<RARdata<List<BEVentasSemana>>> GraficoBarras()
        {
            return Task.Run(() =>
            {
                RARdata<List<BEVentasSemana>> paqueteDatos = new RARdata<List<BEVentasSemana>>();

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_grafico_barras", alParameters);

                    List<BEVentasSemana> barras = new List<BEVentasSemana>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEVentasSemana semana = new BEVentasSemana();
                        semana.Fecha = row["Fechas"].ToString()!;
                        semana.Total = int.Parse(row["Totales"].ToString()!);
                        barras.Add(semana); 
                    }
                    paqueteDatos.cuerpoData = barras;
                    paqueteDatos.estadoData = 1;
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_GET + ex.Message;
                }

                return paqueteDatos;
            });
        }


    }
}
