using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Infraestructura.Repositorios
{
    public interface IProductoRepository
    {
        Task<RARdata<List<BEProducto>>> ObtenerTodo();
        Task<RARdata<BEProducto>> CreaEditaElimina(BEProducto producto, int accion);
        Task<RARdata<BEProductoBuscado>> ConsultarProductoXdescripcion(string descripcion);

    }
}
