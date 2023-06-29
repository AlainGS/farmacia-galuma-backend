using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEVenta
    {
        public int VentaID { get; set; } = 0;
        public string NumeroBoleta { get; set; } = string.Empty;
        public string TipoPago { get; set; } = string.Empty;
        public string VentaTotal { get; set; } = string.Empty;
        public string FechaRegistro { get; set; } = string.Empty;
        public List<BEDetalleVenta> DetalleVenta { get; set; } = new List<BEDetalleVenta>();

    }
}
