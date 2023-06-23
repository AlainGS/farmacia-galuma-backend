using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEProducto : BEMaster
    {
        public int ProductoID { get; set; } = 0;
        public string ProductoDescripcion { get; set; } = string.Empty;
        public int CategoriaID { get; set; } = 0;
        public string CategoriaDescripcion { get; set; } = string.Empty;
        public int ProductoStock { get; set; } = 0;        
        public string ProductoPrecio { get; set; } = string.Empty;
        public string FechaVencimiento { get; set; } = string.Empty;
        public int ProductoEstado { get; set; } = 0;

    }
}
