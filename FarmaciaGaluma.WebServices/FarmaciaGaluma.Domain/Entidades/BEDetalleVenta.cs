using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEDetalleVenta
    {
        public int DetalleVentaID { get; set; } = 0;
        public int VentaID { get; set; } = 0;
        public int ProductoID { get; set; } = 0;
        public string ProductoDescripcion { get; set; } = string.Empty;
        public int ProductoCantidad { get; set; } = 0;
        public decimal ProductoPrecio { get; set; }       
        public decimal ProductoTotal { get; set; }       

    }
}
