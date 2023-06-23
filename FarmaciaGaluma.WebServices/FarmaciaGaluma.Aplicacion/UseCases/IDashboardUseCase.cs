using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface IDashboardUseCase
    {
        Task<RARdata<BEDashBoard>> EjecutarResumen();
        Task<RARdata<List<BEVentasSemana>>> EjecutarGraficoBarras();

    }
}
