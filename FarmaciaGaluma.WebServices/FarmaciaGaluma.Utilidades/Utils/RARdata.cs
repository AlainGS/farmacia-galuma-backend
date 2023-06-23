namespace FarmaciaGaluma.Utilidades.Utils
{
    public class RARdata<T>
    {
        public int estadoData { get; set; } = 0;
        public string mensajeData { get; set; } = string.Empty;
        public T cuerpoData { get; set; }
    }
}
