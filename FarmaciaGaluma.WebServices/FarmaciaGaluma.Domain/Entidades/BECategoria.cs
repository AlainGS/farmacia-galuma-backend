using FarmaciaGaluma.Dominio.Entidades.Comunes;

namespace FarmaciaGaluma.Dominio.Entidades
{
    public class BECategoria : BEMaster
    {
        public int CategoriaID { get; set; } = 0;
        public int FiltroID { get; set; } = 0;
        public string CategoriaDescripcion { get; set; } = string.Empty;
        public bool CategoriaEstado { get; set; } = false;
    }
}
