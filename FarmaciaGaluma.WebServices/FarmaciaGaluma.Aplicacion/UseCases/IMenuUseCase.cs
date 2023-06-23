using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface IMenuUseCase
    {
        Task<RARdata<List<BEMenu>>> EjecutarListadoMenu(int idUsuario);

    }
}
