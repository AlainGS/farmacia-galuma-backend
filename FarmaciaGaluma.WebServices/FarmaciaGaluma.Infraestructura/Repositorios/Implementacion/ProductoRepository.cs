using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace FarmaciaGaluma.Infraestructura.Repositorios.Implementacion
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _conectaDB;

        public ProductoRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }


        public Task<RARdata<List<BEProducto>>> ObtenerTodo()
        {
            return Task.Run(() =>
            {
                RARdata<List<BEProducto>> paqueteDatos = new RARdata<List<BEProducto>>();

                ArrayList alParameters = new ArrayList();

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_listado_producto", alParameters);

                    List<BEProducto> listaProductos = new List<BEProducto>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEProducto producto = new BEProducto();
                        producto.nro = int.Parse(row["nro"].ToString()!);
                        producto.ProductoID = int.Parse(row["IdProducto"].ToString()!);
                        producto.ProductoDescripcion = row["DescripcionProducto"].ToString()!;
                        producto.CategoriaID = int.Parse(row["IdCategoria"].ToString()!);
                        producto.CategoriaDescripcion = row["DescripcionCategoria"].ToString()!;
                        producto.ProductoStock = int.Parse(row["StockProducto"].ToString()!);
                        producto.ProductoPrecio = row["PrecioProducto"].ToString()!;
                        producto.FechaVencimiento = row["FechaVencimiento"].ToString()!;// +" (quedan: "+row["DiasFaltantes"].ToString()!+" dias)";
                        producto.ProductoEstado = bool.Parse(row["EstadoProducto"].ToString()!) ? 1 : 0;

                        listaProductos.Add(producto);
                    }

                    paqueteDatos.cuerpoData = listaProductos;
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

        public Task<RARdata<BEProducto>> CreaEditaElimina(BEProducto producto, int accion)
        {
            return Task.Run(() =>
            {
                RARdata<BEProducto> paqueteDatos = new RARdata<BEProducto>();
                string mensajeDesdeSQLServer = "";

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                parameter = new SqlParameter("@IdProducto", SqlDbType.Int);
                parameter.Value = producto.ProductoID;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@DescripcionProducto", SqlDbType.VarChar, 100);
                parameter.Value = producto.ProductoDescripcion;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@IdCategoria", SqlDbType.Int);
                parameter.Value = producto.CategoriaID;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@StockProducto", SqlDbType.Int);
                parameter.Value = producto.ProductoStock;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@PrecioProducto", SqlDbType.VarChar, 100);
                parameter.Value = producto.ProductoPrecio;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@FechaVencimiento", SqlDbType.VarChar, 100);
                parameter.Value = producto.FechaVencimiento;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@EstadoProducto", SqlDbType.Bit);
                parameter.Value = producto.ProductoEstado;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@User", SqlDbType.VarChar, 100);
                parameter.Value = producto.user;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@Pc", SqlDbType.VarChar, 100);
                parameter.Value = producto.pc;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@Accion", SqlDbType.Int);
                parameter.Value = accion;
                alParameters.Add(parameter);
                                
                try
                {
                    paqueteDatos.estadoData = SqlComandos.executeReaderSP(_conectaDB, "usp_app_crea_edita_elimina_producto", alParameters, out mensajeDesdeSQLServer) ? 1 : 0;
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

    }
}
