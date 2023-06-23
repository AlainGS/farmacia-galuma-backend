using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface IProductoUseCase
    {
        Task<RARdata<List<BEProducto>>> EjecutarObtenerTodo();
        Task<RARdata<BEProducto>> EjecutarCreaEditaElimina(BEProducto producto, int accion);
    }
}
