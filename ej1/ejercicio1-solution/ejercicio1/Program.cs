using System;
/*
 1 - Solicite el nombre de una persona, su edad y el nombre de una ciudad. 
Después de solicitar estos datos deberámostrar por pantalla el siguiente mensaje: 
Te llamas y tienes <años> años. Bienvenido a
*/

namespace ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Solicitar el nombre
            Console.WriteLine("¿Cual es tu nombre?");
            string name = Console.ReadLine();
            //Solicitar la edad
            Console.WriteLine("¿Cual es tu edad?");
            string age = Console.ReadLine();
            //Convertir la edad
            age.Cast<int>();
            //Solicitar la ciudad
            Console.WriteLine("Introduce una ciudad: ");
            var city = Console.ReadLine();
            //Mostrar el mensaje
            Console.WriteLine($"Te llamas {name} y tienes {age} años. Bienvenido a {city}");
        }
    }
}


