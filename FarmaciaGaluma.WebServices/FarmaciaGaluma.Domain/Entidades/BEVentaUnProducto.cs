using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEVentaUnProducto
    {
        public string TipoPago { get; set; } = string.Empty;
        public string ProductoDescripcion { get; set; } = string.Empty;
        public int ProductoCantidad { get; set; } = 0;

    }
}
