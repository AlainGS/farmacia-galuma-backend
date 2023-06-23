using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Aplicacion.UseCases.Implementacion
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<RARdata<BESesion>> EjecutarValidarCredenciales(string correo, string clave)
        {
            return await _usuarioRepository.ValidarCredenciales(correo, clave);
        }


        public async Task<RARdata<List<BEUsuario>>> EjecutarObtenerTodo()
        {
            return await _usuarioRepository.ObtenerTodo();
        }


        public async Task<RARdata<BEUsuario>> EjecutarCreaEditaElimina(BEUsuario usuario, int accion)
        {
            return await _usuarioRepository.CreaEditaElimina(usuario, accion);
        }
    }
}
