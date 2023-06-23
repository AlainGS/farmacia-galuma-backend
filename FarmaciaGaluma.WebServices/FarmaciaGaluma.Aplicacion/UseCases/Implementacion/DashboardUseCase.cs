using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Infraestructura.Repositorios.Implementacion;
using FarmaciaGaluma.Utilidades.Utils;
using System;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class DashboardUseCase : IDashboardUseCase
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardUseCase(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<RARdata<BEDashBoard>> EjecutarResumen()
        {
            return await _dashboardRepository.Resumen();
        }

        public async Task<RARdata<List<BEVentasSemana>>> EjecutarGraficoBarras()
        {
            return await _dashboardRepository.GraficoBarras();
        }
    
    }
}
