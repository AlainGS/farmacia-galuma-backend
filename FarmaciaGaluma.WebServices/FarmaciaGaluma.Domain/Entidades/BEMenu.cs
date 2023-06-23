using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEMenu 
    {
        public int MenuID { get; set; } = 0;
        public string MenuDescripcion { get; set; } = string.Empty;
        public string MenuIcono { get; set; } = string.Empty;
        public string MenuUrl { get; set; } = string.Empty;
    }
}
