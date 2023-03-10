using System;
using System.Reflection.Metadata.Ecma335;

namespace excp1
{
    internal class Program
    {
        public class esPositivoException : Exception
        {
            public esPositivoException(string message) : base(message)
            {
                Console.WriteLine(message);
            }

        }
        public class esMayorException : Exception
        {
            public esMayorException(string message) : base(message)
            {
                Console.WriteLine(message);
            }

        }
        public class esMenorException : Exception
        {
            public esMenorException(string message) : base(message)
            {
                Console.WriteLine(message);
            }

        }

        public static void ValidarNumero(int numero)
        {
            if(numero >= 0 & numero <= 100 )           
            {
                Console.WriteLine("El numero es un entero positivo. ");
                Console.WriteLine("************************");
            }
            else 
            {
                throw new esPositivoException($"El numero {numero} es menor que 0 o mayor que 100");
            }
        }

    
        static void Main(string[] args) {
            Random random = new Random();
            int randomNumber =  random.Next(1,100);
            Console.WriteLine($"Este es el numero random generado: {randomNumber}\n");
            int numIntentos = 1;
            while (numIntentos <= 10)
            {
                try
                {
                    Console.WriteLine("Introduce un numero del 1 al 100:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("************************");
                    Console.WriteLine("Primero veamos si es positivo y esta entre [0,100]");
                    Console.WriteLine($"Este es el numero que has introducido: {num}");
                    ValidarNumero(num);
                    if (num == randomNumber)
                    {
                        Console.WriteLine("Enhorabuena has acertado!");
                        break;
                    }
                    else
                    {
                        if (num < randomNumber)
                        {
                            Console.WriteLine($"Fallaste! Te quedan : {10 - numIntentos} intentos.");
                            numIntentos++;
                            throw new esMenorException($"El numero aleatorio es mayor que {num}");

                        }
                        else
                        {
                            Console.WriteLine($"Fallaste! Te quedan : {10 - numIntentos} intentos.");
                            numIntentos++;
                            throw new esMayorException($"El numero aleatorio es menor que {num}");
                        }

                    }
                }
                catch (esPositivoException e)
                {
                    Console.WriteLine("Porfavor introduce un numero mayor que 0 (positivo) y menor que 100 para poder comenzar a jugar!!!!!");
                    Console.WriteLine("-----------------------------------");
                }
                catch (esMenorException e)
                {
                    Console.WriteLine("Prueba de nuevo.");
                    Console.WriteLine("-----------------------------------");
                    continue;
                }
                catch (esMayorException e)
                {
                    Console.WriteLine("Prueba de nuevo.");
                    Console.WriteLine("-----------------------------------");
                    continue;
                }
            }
        }
    }
}