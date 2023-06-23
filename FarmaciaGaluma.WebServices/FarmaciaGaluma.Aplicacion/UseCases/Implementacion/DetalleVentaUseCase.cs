using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Utilidades.Utils;
using System;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class DetalleVentaUseCase : IDetalleVentaUseCase
    {
        private readonly IDetalleVentaRepository _detalleVentaRepository;
        public DetalleVentaUseCase(IDetalleVentaRepository detalleVentaRepository)
        {
            _detalleVentaRepository = detalleVentaRepository;
        }        

        public async Task<RARdata<List<BEDetalleVenta>>> EjecutarBusquedaDV(int idVenta)
        {
            return await _detalleVentaRepository.BusquedaDV(idVenta);
        }
               
    }
}
