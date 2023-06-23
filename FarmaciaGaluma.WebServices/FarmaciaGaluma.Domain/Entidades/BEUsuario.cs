using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEUsuario : BEMaster
    {
        public int UsuarioID { get; set; } = 0;
        public string UsuarioNombre { get; set; } = string.Empty;
        public int RolID { get; set; } = 0;
        public string RolNombre { get; set; } = string.Empty;
        public string UsuarioCorreo { get; set; } = string.Empty;
        public string UsuarioClave { get; set; } = string.Empty;
        public int UsuarioEstado { get; set; } = 0;
    }
}
