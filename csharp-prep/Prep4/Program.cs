using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int guess = -1;

        while (guess != 0)
        {
            Console.Write("Write a number? ");
            guess = int.Parse(Console.ReadLine());
            numbers.Add(guess);
        }
        Console.WriteLine("Finoto");
        foreach (int number in numbers)
        {
            if (number != 0)
            {
                Console.WriteLine(number);
            }
        }
        
        int total = 0;
        int count = 0;

        count = numbers.Count;
        foreach (int value in numbers)
        {
            total += value;
        }
        int average = total / count;

        int max = int.MinValue;
        foreach (int digit in numbers)
        {
            if (digit > max)
            {
                max = digit;
            }
        }
        Console.WriteLine($"The total sum is {total}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {max}");
        int smallestPositive = int.MaxValue; 

        foreach (int digit in numbers)
        {
            if (digit > 0 && digit < smallestPositive)
            {
                smallestPositive = digit;
            }
        }

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive  numbers were entered.");
        }

        
    }
}
