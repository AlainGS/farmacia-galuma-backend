using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BESesion
    {
        public int UsuarioID { get; set; } = 0;
        public string UsuarioNombre { get; set; } = string.Empty;
        public string UsuarioCorreo { get; set; } = string.Empty;
        public string RolNombre { get; set; } = string.Empty;        
    }
}
