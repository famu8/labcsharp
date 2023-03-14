using System;

public class SlotMachine
{
    public int Coins { get; private set; }

    public void Play()
    {
        Random rnd = new Random();
        bool bool1 = rnd.Next(2) == 0;
        bool bool2 = rnd.Next(2) == 0;
        bool bool3 = rnd.Next(2) == 0;

        Coins++;

        if (bool1 && bool2 && bool3)
        {
            Console.WriteLine($"Congratulations!!!. You won {Coins} coins!!");
            Coins = 0;
        }
        else
        {
            Console.WriteLine("Good luck next time!!");
        }
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Insert a coin to play or type 'exit' to quit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                break;
            }
            Play();
        }
    }


    public static void Main(string[] args)
    {
        SlotMachine machine = new SlotMachine();
        machine.Run();
    }
}
