namespace FarmaciaGaluma.Dominio.Entidades.Comunes
{
    public class BEMaster
    {
        public int nro { get; set; } = 0;
        public string pc { get; set; } = Environment.MachineName;
        public string user { get; set; } = Environment.UserName;
    }
}
