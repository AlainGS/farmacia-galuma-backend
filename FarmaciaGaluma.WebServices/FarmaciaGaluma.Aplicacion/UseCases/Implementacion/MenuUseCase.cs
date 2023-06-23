using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Utilidades.Utils;
using System;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class MenuUseCase : IMenuUseCase
    {
        private readonly IMenuRepository _menuRepository;
        public MenuUseCase(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }        

        public async Task<RARdata<List<BEMenu>>> EjecutarListadoMenu(int idUsuario)
        {
            return await _menuRepository.ListadoMenu(idUsuario);
        }
               
    }
}
