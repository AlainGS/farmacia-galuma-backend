using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Utilidades.Utils;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace FarmaciaGaluma.Infraestructura.Repositorios.Implementacion
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly string _conectaDB;

        public DetalleVentaRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }
                
        public Task<RARdata<List<BEDetalleVenta>>> BusquedaDV(int idVenta)
        {
            return Task.Run(() =>
            {
                RARdata<List<BEDetalleVenta>> paqueteDatos = new RARdata<List<BEDetalleVenta>>();

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                parameter = new SqlParameter("@IdVenta", SqlDbType.Int);
                parameter.Value = idVenta;
                alParameters.Add(parameter);

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_buscarporid_detalleventa", alParameters);

                    List<BEDetalleVenta> listaDetalleVenta = new List<BEDetalleVenta>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEDetalleVenta dv = new BEDetalleVenta();
                        dv.ProductoID = int.Parse(row["IdProducto"].ToString()!);
                        dv.ProductoDescripcion = row["DescripcionProducto"].ToString()!;
                        dv.ProductoCantidad = int.Parse(row["CantidadProducto"].ToString()!);
                        dv.ProductoPrecio = decimal.Parse(row["PrecioProducto"].ToString()!);
                        dv.ProductoTotal = decimal.Parse(row["TotalProducto"].ToString()!);
                        listaDetalleVenta.Add(dv);
                    }

                    paqueteDatos.cuerpoData = listaDetalleVenta;
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
