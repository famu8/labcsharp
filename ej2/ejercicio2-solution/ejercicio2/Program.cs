using System;
namespace ejercicio2
{
    internal class Program{
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce un primer numero: ");
            string num1 = Console.ReadLine();
            int numberOne = Int32.Parse(num1);
            Console.WriteLine("Introduce un segundo numero: ");
            string num2 = Console.ReadLine();
            int numberTwo = Int32.Parse(num2);

            Console.WriteLine($"Tu primero numero es: {numberOne}");
            Console.WriteLine($"Tu segundo numero es: {numberTwo}");

            if (numberOne > numberTwo)
            {
                Console.WriteLine("------------------");
                Console.WriteLine($"| {numberOne} es mayor que {numberTwo}|");
                Console.WriteLine("------------------");

                Console.WriteLine("Adios!");
            }
            else
            {
                Console.WriteLine("------------------");
                Console.WriteLine($"| {numberTwo} es mayor que {numberOne}|");
                Console.WriteLine("------------------");

                Console.WriteLine("Adios!");
            }


        }

    }
}