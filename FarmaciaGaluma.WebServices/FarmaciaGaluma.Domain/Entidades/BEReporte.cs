namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BEReporte
    {
        public string NumeroDocumento { get; set; } = string.Empty;
        public string TipoPago { get; set; } = string.Empty;
        public string FechaRegistro { get; set; } = string.Empty;
        public string TotalVenta { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; } = 0;
        public string Precio { get; set; } = string.Empty;
        public string Total { get; set; } = string.Empty;

    }
}
