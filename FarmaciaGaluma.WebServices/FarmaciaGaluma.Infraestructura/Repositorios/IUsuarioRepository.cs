using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Infraestructura.Repositorios
{
    public interface IUsuarioRepository
    {
        Task<RARdata<BESesion>> ValidarCredenciales(string correo, string clave);
        Task<RARdata<List<BEUsuario>>> ObtenerTodo();
        Task<RARdata<BEUsuario>> CreaEditaElimina(BEUsuario usuario, int accion);
    }
}
