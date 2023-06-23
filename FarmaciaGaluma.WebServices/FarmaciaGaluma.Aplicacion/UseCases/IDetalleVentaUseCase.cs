using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface IDetalleVentaUseCase
    {
        Task<RARdata<List<BEDetalleVenta>>> EjecutarBusquedaDV(int id);

    }
}
