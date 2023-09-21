using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {  
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 20);
        int guess = 0;
        int counts = 0;

        while (guess != number)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > number)
            {
                Console.WriteLine("Lower");
            }

            counts++;
        }

        Console.WriteLine("You guessed it!");
        Console.WriteLine($"It took you {counts} attempts.");
    }
}
