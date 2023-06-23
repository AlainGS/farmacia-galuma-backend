using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface IUsuarioUseCase
    {
        Task<RARdata<BESesion>> EjecutarValidarCredenciales(string correo, string clave);
        Task<RARdata<List<BEUsuario>>> EjecutarObtenerTodo();
        Task<RARdata<BEUsuario>> EjecutarCreaEditaElimina(BEUsuario usuario, int accion);
    }
}
