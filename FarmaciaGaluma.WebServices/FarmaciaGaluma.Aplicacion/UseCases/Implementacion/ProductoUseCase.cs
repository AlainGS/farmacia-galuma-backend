using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class ProductoUseCase : IProductoUseCase
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoUseCase(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }


        public async Task<RARdata<List<BEProducto>>> EjecutarObtenerTodo()
        {
            return await _productoRepository.ObtenerTodo();
        }


        public async Task<RARdata<BEProducto>> EjecutarCreaEditaElimina(BEProducto producto, int accion)
        {
            return await _productoRepository.CreaEditaElimina(producto, accion);
        }


        public async Task<RARdata<BEProductoBuscado>> EjecutarConsultarProductoXdescripcion(string descripcion)
        {
            return await _productoRepository.ConsultarProductoXdescripcion(descripcion);
        }
    }
}
