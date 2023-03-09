using System;

/*
6 – Solicitar un número al usuario y un carácter. Crear una pirámide con N filas y el carácter solicitado. 
Por ejemplo, si el usuario introduce 5 y * el resultado por consola debería ser:
*/

namespace ejercicio6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce un numero: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce un caracter: ");
            char c = char.Parse(Console.ReadLine());
            Console.WriteLine("Esta es tu piramide");
            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    //evaluar columnas
                    if (j == 1 || j == i || i == num)
                    {
                        Console.Write(c);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}