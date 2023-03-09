using System;
using System.Diagnostics;
/*
3 - Pedir el nombre de la semana al usuario y decirle si es fin de semana o no. En caso de error, indicarlo.
*/

namespace ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Solicitar el nombre
            Console.WriteLine("Introduce un dia de la semana");
            string name = Console.ReadLine();
            switch (name)
            {

                case "Lunes":
                    Console.WriteLine("No es fin de semana");
                    break;

                case "Martes":
                    Console.WriteLine("No es fin de semana");
                    break;
                case "Miercoles":
                    Console.WriteLine("No es fin de semana");
                    break;
                case "Jueves":
                    Console.WriteLine("No es fin de semana");
                    break;
                case "Viernes":
                    Console.WriteLine("No es fin de semana");
                    break;
                case "Sabado":
                    Console.WriteLine("Es fin de semana");
                    break;
                case "Domingo":
                    Console.WriteLine("Es fin de semana");
                    break;
                default:
                    Console.WriteLine("Error...");
                    break;
            }

        }
    }
}


