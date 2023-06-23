using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEVentaDetallado
    {
        public string FechaRegistro { get; set; } = string.Empty;
        public string NumeroBoleta { get; set; } = string.Empty;
        public string TipoPago { get; set; } = string.Empty;
        public string VentaTotal { get; set; } = string.Empty;
        public string ProductoDescripcion { get; set; } = string.Empty;
        public int ProductoCantidad { get; set; } = 0;
        public decimal ProductoPrecio { get; set; }
        public decimal ProductoTotal { get; set; }

    }
}
