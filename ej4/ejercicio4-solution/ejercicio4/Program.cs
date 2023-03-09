using System;

/*
4 - Recorre los números del 1 al 100. Muestra los números pares. Usar el tipo de bucle que quieras.
 */

namespace ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
            {
                if(i%2==0)
                {
                    Console.WriteLine($"Numero: {i}");
                }
            }
        }
    }
}