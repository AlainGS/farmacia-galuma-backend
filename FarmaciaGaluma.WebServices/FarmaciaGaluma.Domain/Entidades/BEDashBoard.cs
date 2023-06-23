using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEDashBoard
    {
        public string TotalIngresos { get; set; } = string.Empty;
        public int TotalVentas { get; set; } = 0;
        public int TotalProductos { get; set; } = 0;
        public List<BEVentasSemana> VentasUltimaSemana { get; set; } = new List<BEVentasSemana>();

    }
}
