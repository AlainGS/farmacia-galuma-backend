using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Utilidades.Utils;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace FarmaciaGaluma.Infraestructura.Repositorios.Implementacion
{
    public class VentaRepository : IVentaRepository
    {
        private readonly string _conectaDB;

        public VentaRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }


        public Task<RARdata<List<BEVenta>>> ObtenerTodo()
        {
            return Task.Run(() =>
            {
                RARdata<List<BEVenta>> paqueteDatos = new RARdata<List<BEVenta>>();

                ArrayList alParameters = new ArrayList();

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_listado_venta", alParameters);

                    List<BEVenta> listaVenta = new List<BEVenta>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEVenta venta = new BEVenta();
                        venta.nro = int.Parse(row["nro"].ToString()!);
                        venta.VentaID = int.Parse(row["IdVenta"].ToString()!);
                        venta.NumeroBoleta = row["NumeroBoleta"].ToString()!;
                        venta.TipoPago = row["TipoPago"].ToString()!;
                        venta.VentaTotal = row["Total"].ToString()!;
                        venta.FechaRegistro = row["FechaRegistro"].ToString()!;
                        listaVenta.Add(venta);
                    }

                    paqueteDatos.cuerpoData = listaVenta;
                    paqueteDatos.estadoData = 1;
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_LIST + ex.Message;
                }

                return paqueteDatos;
            });
        }

        public Task<RARdata<List<BEVentaDetallado>>> ObtenerTodoDetallado()
        {
            return Task.Run(() =>
            {
                RARdata<List<BEVentaDetallado>> paqueteDatos = new RARdata<List<BEVentaDetallado>>();

                ArrayList alParameters = new ArrayList();

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_listado_venta_detallado", alParameters);

                    List<BEVentaDetallado> listaVentaDetallado = new List<BEVentaDetallado>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEVentaDetallado ventaDetallada = new BEVentaDetallado();
                        ventaDetallada.FechaRegistro = row["FechaRegistro"].ToString()!;
                        ventaDetallada.NumeroBoleta = row["NumeroBoleta"].ToString()!;
                        ventaDetallada.TipoPago = row["TipoPago"].ToString()!;
                        ventaDetallada.VentaTotal = row["Total"].ToString()!;
                        ventaDetallada.ProductoDescripcion = row["DescripcionProducto"].ToString()!;
                        ventaDetallada.ProductoCantidad = int.Parse(row["CantidadProducto"].ToString()!);
                        ventaDetallada.ProductoPrecio = decimal.Parse(row["PrecioProducto"].ToString()!);
                        ventaDetallada.ProductoTotal = decimal.Parse(row["TotalProducto"].ToString()!);

                        listaVentaDetallado.Add(ventaDetallada);
                    }

                    paqueteDatos.cuerpoData = listaVentaDetallado;
                    paqueteDatos.estadoData = 1;
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_LIST + ex.Message;
                }

                return paqueteDatos;
            });
        }


        public Task<RARdata<BEVenta>> Registrar(BEVenta venta, int accion)
        {
            return Task.Run(() =>
            {
                RARdata<BEVenta> paqueteDatos = new RARdata<BEVenta>();
                string mensajeDesdeSQLServer = "";

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                parameter = new SqlParameter("@IdVenta", SqlDbType.Int);
                parameter.Value = venta.VentaID;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@NumeroBoleta", SqlDbType.VarChar, 100);
                parameter.Value = venta.NumeroBoleta;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@TipoPago", SqlDbType.VarChar, 100);
                parameter.Value = venta.TipoPago;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@VentaTotal", SqlDbType.VarChar, 100);
                parameter.Value = venta.VentaTotal;
                alParameters.Add(parameter);

                ListToDataTable convertidor = new ListToDataTable();
                DataTable dtDetalleVenta = convertidor.ToDataTable(venta.DetalleVenta);

                parameter = new SqlParameter("@DetalleVenta", SqlDbType.Structured);
                parameter.Value = dtDetalleVenta;
                alParameters.Add(parameter);


                parameter = new SqlParameter("@User", SqlDbType.VarChar, 100);
                parameter.Value = venta.user;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@Pc", SqlDbType.VarChar, 100);
                parameter.Value = venta.pc;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@Accion", SqlDbType.Int);
                parameter.Value = accion;
                alParameters.Add(parameter);
                                
                try
                {
                    paqueteDatos.estadoData = SqlComandos.executeReaderSP(_conectaDB, "usp_app_registra_venta", alParameters, out mensajeDesdeSQLServer) ? 1 : 0;
                    paqueteDatos.mensajeData = mensajeDesdeSQLServer;
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_SAVE_UPDATE + ex.Message;
                }

                return paqueteDatos;
            });
        }



        public Task<RARdata<List<BEVenta>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            return Task.Run(() =>
            {
                RARdata<List<BEVenta>> paqueteDatos = new RARdata<List<BEVenta>>();

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                //parameter = new SqlParameter("@Correo", SqlDbType.VarChar, 40);
                //parameter.Value = correo;
                //alParameters.Add(parameter);

                //parameter = new SqlParameter("@Clave", SqlDbType.VarChar, 40);
                //parameter.Value = clave;
                //alParameters.Add(parameter);

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_historial_venta", alParameters);

                    List<BEVenta> listaVenta = new List<BEVenta>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEVenta venta = new BEVenta();
                        //venta.UsuarioID = int.Parse(row["IdUsuario"].ToString()!);
                        //venta.UsuarioNombre = row["NombreUsuario"].ToString()!;
                        //venta.RolID = int.Parse(row["IdRol"].ToString()!);
                        //venta.RolNombre = row["NombreRol"].ToString()!;
                        //venta.UsuarioCorreo = row["CorreoUsuario"].ToString()!;
                        //venta.UsuarioClave = row["ClaveUsuario"].ToString()!;
                        //venta.UsuarioEstado = bool.Parse(row["EstadoUsuario"].ToString()!) ? 1 : 0;
                        listaVenta.Add(venta);
                    }

                    paqueteDatos.cuerpoData = listaVenta;
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



        public Task<RARdata<BEReporte>> Reporte(string fechaInicio, string fechaFin)
        {
            return Task.Run(() =>
            {
                RARdata<BEReporte> paqueteDatos = new RARdata<BEReporte>();

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                //parameter = new SqlParameter("@Correo", SqlDbType.VarChar, 40);
                //parameter.Value = correo;
                //alParameters.Add(parameter);

                //parameter = new SqlParameter("@Clave", SqlDbType.VarChar, 40);
                //parameter.Value = clave;
                //alParameters.Add(parameter);

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_reporte_venta", alParameters);

                    BEReporte reporte = new BEReporte();
                    foreach (DataRow row in dt.Rows)
                    {
                        //venta.UsuarioID = int.Parse(row["IdUsuario"].ToString()!);
                        //venta.UsuarioNombre = row["NombreUsuario"].ToString()!;
                        //venta.RolID = int.Parse(row["IdRol"].ToString()!);
                        //venta.RolNombre = row["NombreRol"].ToString()!;
                        //venta.UsuarioCorreo = row["CorreoUsuario"].ToString()!;
                        //venta.UsuarioClave = row["ClaveUsuario"].ToString()!;
                        //venta.UsuarioEstado = bool.Parse(row["EstadoUsuario"].ToString()!) ? 1 : 0;
                    }

                    paqueteDatos.cuerpoData = reporte;
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

        //public DataTable ToDataTable<T>(List<BEDetalleVenta> listaProductos)
        //{
        //    DataTable dataTable = new DataTable(typeof(BEDetalleVenta).Name);

        //    Get all the properties
        //    PropertyInfo[] Props = typeof(BEDetalleVenta).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in Props)
        //    {
        //        Setting column names as Property names
        //        dataTable.Columns.Add(prop.Name);
        //    }
        //    foreach (BEDetalleVenta producto in listaProductos)
        //    {
        //        var values = new object[Props.Length];
        //        for (int i = 0; i < Props.Length; i++)
        //        {
        //            inserting property values to datatable rows
        //            values[i] = Props[i].GetValue(producto, null);
        //        }
        //        dataTable.Rows.Add(values);
        //    }
        //    put a breakpoint here and check datatable
        //    return dataTable;
        //}


    }
}
