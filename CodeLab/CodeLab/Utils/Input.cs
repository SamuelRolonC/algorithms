using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLab.Utils
{
    public class Input
    {
        private int GetInteger(string message, int min, int max)
        {
            var value = 0;
            var isValid = false;

            while (!isValid)
            {
                Console.Write(message);
                var strHours = Console.ReadLine();
                Console.WriteLine("");

                if (!int.TryParse(strHours, out value))
                {
                    Console.WriteLine("El valor ingresado no es válido.");
                    Console.WriteLine("");
                }
                else if (value < min || value > max)
                {
                    Console.WriteLine($"El valor debe ser mayor o igual a {min} y " +
                        $"menor o igual a {max}.");
                    Console.WriteLine("");
                }
                else
                {
                    isValid = true;
                }
            }

            return value;
        }

        public static string? GetString(string message)
        {
            var value = string.Empty;
            var isValid = false;

            while (!isValid)
            {
                Console.Write(message);
                value = Console.ReadLine();
                Console.WriteLine("");

                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Debe ingresar almenos un caracter.");
                    Console.WriteLine("");
                }
                else
                {
                    isValid = true;
                }
            }

            return value;
        }
    }
}
