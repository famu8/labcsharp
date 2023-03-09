using System;

/*
5 – Solicitar un número al usuario y generar un Array con N números aleatorios. 
Por ejemplo, si el usuario introduce 4, el resultado por consola debería ser: 23, 34, 234, 11 */

namespace ejercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce un numero: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] randNumbers = new int[num];
            var rand = new Random();
            for (int i = 0; i < num; i++)
            {
                randNumbers[i] = rand.Next(1,1000);
                
            }
            Console.WriteLine("Este es tu array de numero aleatorios: ");
            Console.WriteLine("["+string.Join(", ", randNumbers)+"]");
        }
    }
}