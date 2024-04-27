using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your Grade percentage? ");
        string value = Console.ReadLine();
       
        int gradePercentage = int.Parse(value);
        string letter = "";

        if (gradePercentage >= 90 )
        {   
            string score = "";
            letter = "A";
            int ff = gradePercentage % 10;
            if (ff>7)
            {
                score = "+";
            }
            else if (ff<3)
            {
                score = "-";
            }
            Console.Write($"You got an {letter}{score} Congratulations you passed the class");
        }
        
        else if (gradePercentage >= 80)
        {   
            string score = "";
            letter = "B";
            int ff = gradePercentage % 10;
            if (ff>7)
            {
                score = "+";
            }
            else if (ff<3)
            {
                score = "-";
            }
            Console.Write($"You got a {letter}{score}  Congratulations you passed the class");
        }
        
        else if (gradePercentage >= 70)
        {   
            string score = "";
            letter = "C";
            int ff = gradePercentage % 10;
            if (ff>7)
            {
                score = "+";
            }
            else if (ff<3)
            {
                score = "-";
            }
            Console.Write($"You got a {letter}{score} Congratulations you passed the class");
        }
        

        else if (gradePercentage >= 60)
        {   
            letter = "D";
            Console.Write($"You got a {letter}. Better luck next semester.");
        }

        else if (gradePercentage < 60)
        {

            letter = "F";
            Console.Write($"You got an {letter}. Try again next semester.");
        }
    }

}