using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class RolUseCase : IRolUseCase
    {
        private readonly IRolRepository _rolRepository;
        public RolUseCase(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }
                
        public async Task<RARdata<List<BERol>>> EjecutarObtenerTodo()
        {
            return await _rolRepository.ObtenerTodo();
        }        
    }
}
