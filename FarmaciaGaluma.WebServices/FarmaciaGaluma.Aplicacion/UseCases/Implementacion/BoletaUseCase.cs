using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class BoletaUseCase : IBoletaUseCase
    {
        private readonly IBoletaRepository _boletaRepository;
        public BoletaUseCase(IBoletaRepository boletaRepository)
        {
            _boletaRepository = boletaRepository;
        }
                
        public async Task<RARdata<BEBoleta>> EjecutarObtenerUltimoNumeroDoc()
        {
            return await _boletaRepository.UltimoNumeroDoc();
        }        
    }
}
