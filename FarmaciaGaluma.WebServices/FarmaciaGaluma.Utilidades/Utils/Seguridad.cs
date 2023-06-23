using System.Security.Cryptography;
using System.Text;

namespace FarmaciaGaluma.Utilidades.Utils
{
    public class Seguridad
    {
        public static string encriptarPassword(String password)
        {
            //GetSHA256
            password = "@" + password + "_#";
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder stringBuilder = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) stringBuilder.AppendFormat("{0:x2}", stream[i]);
            return stringBuilder.ToString();
        }
    }
}
