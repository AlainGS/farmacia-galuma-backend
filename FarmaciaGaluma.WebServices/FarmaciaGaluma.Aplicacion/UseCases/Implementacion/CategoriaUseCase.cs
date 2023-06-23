using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class CategoriaUseCase : ICategoriaUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaUseCase(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        
        public async Task<RARdata<List<BECategoria>>> EjecutarObtenerTodo()
        {
            return await _categoriaRepository.ObtenerTodo();
        }


        public async Task<RARdata<BECategoria>> EjecutarCreaEditaElimina(BECategoria categoria, int accion)
        {
            return await _categoriaRepository.CreaEditaElimina(categoria, accion);
        }
    }
}
