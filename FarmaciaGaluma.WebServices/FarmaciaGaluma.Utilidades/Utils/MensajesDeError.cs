namespace FarmaciaGaluma.Utilidades.Utils
{
    public static class MensajesDeError
    {
        public static string ERROR_INESPERADO_GET = "Error inesperado al OBTENER EL REGISTRO de la BD: ";
        public static string ERROR_INESPERADO_LIST = "Error inesperado para LISTAR LOS REGISTROS de la BD: ";
        public static string ERROR_INESPERADO_SAVE_UPDATE = "Error inesperado al GUARDAR REGISTROS en la BD: ";
        public static string ERROR_INESPERADO_DEL = "Error inesperado al ELIMINAR REGISTROS en la BD: ";

        public static string ERROR_PERSONALIZADO_ARGS(string TITLE) { return TITLE + ": "; }
    }
}
