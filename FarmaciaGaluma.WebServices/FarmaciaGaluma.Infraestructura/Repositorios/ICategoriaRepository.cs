using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Infraestructura.Repositorios
{
    public interface ICategoriaRepository
    {
        Task<RARdata<List<BECategoria>>> ObtenerTodo();
        Task<RARdata<BECategoria>> CreaEditaElimina(BECategoria categoria, int accion);
    }
}
