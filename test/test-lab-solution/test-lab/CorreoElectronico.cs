using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test_lab
{
    public class CorreoElectronico
    {
        private static List<string> correosValidados = new List<string>();

        public static bool ValidarCorreoElectronico(string correoElectronico)
        {
            if (correosValidados.Contains(correoElectronico))
            {
                Console.WriteLine("Ya se ha validado el correo electrónico.");
                return true; // Se devuelve true para evitar mostrar el mensaje de error.
            }

            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(patron);
            bool esValido = regex.IsMatch(correoElectronico);

            if (esValido)
            {
                correosValidados.Add(correoElectronico);
            }

            return esValido;
        }
    }

}
