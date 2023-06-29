using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEProductoBuscado
    {
        public int ProductoID { get; set; } = 0;
        public string ProductoDescripcion { get; set; } = string.Empty;
        public string ProductoPrecio { get; set; } = string.Empty;
    }
}
