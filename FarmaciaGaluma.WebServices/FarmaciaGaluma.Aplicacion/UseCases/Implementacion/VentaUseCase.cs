using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Utilidades.Utils;
using System;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class VentaUseCase : IVentaUseCase
    {
        private readonly IVentaRepository _ventaRepository;
        public VentaUseCase(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }
        

        public async Task<RARdata<List<BEVenta>>> EjecutarObtenerTodo()
        {
            return await _ventaRepository.ObtenerTodo();
        }

        public async Task<RARdata<List<BEVentaDetallado>>> EjecutarObtenerTodoDetallado()
        {
            return await _ventaRepository.ObtenerTodoDetallado();
        }

        public async Task<RARdata<BEVenta>> EjecutarRegistrar(BEVenta venta, int accion)
        {
            return await _ventaRepository.Registrar(venta, accion);
        }

        public async Task<RARdata<List<BEVenta>>> EjecutarHistorial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            return await _ventaRepository.Historial(buscarPor, numeroVenta,fechaInicio,fechaFin);
        }

        public async Task<RARdata<BEReporte>> EjecutarReporte(string fechaInicio, string fechaFin)
        {
            return await _ventaRepository.Reporte(fechaInicio, fechaFin);
        }
    }
}
