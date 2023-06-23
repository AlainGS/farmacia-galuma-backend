using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface ICategoriaUseCase
    {
        Task<RARdata<List<BECategoria>>> EjecutarObtenerTodo();
        Task<RARdata<BECategoria>> EjecutarCreaEditaElimina(BECategoria categoria, int accion);
    }
}
