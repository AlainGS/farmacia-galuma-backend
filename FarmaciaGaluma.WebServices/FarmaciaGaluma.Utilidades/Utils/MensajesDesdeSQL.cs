namespace FarmaciaGaluma.Utilidades.Utils
{
    public class MensajesDesdeSQL
    {
        public static Boolean CodigoRetorno(String vExito, out String resultado)
        {
            // @vExito = "0=registro(s) eliminado(s) correctamente";
            // El '=' esta en la posicion 1
            int posicion = vExito.IndexOf("=");

            if (posicion > 0)
            {
                //SubString Obtiene el Mensaje despues del "="
                resultado = vExito.Substring(posicion + 1);

                //Obtenemos el codigo antes del "="
                int code = int.Parse(vExito.Substring(0, posicion));

                if (code == 0) //0 significa CORRECTO
                {
                    return true;
                }
                else
                {
                    resultado = "[Código: " + code + "] " + resultado;
                    return false;
                }
            }
            else
            {
                resultado = "NO se pudo determinar el CODIGO DE RETORNO desde el servidor.";
                return false;
            }
        }
    }
}
