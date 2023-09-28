using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Fresh Dew";
        job1._jobTitle = "Cashier";
        job1._startYear = 2017;
        job1._endYear = 2017;
        

        Job job2 = new Job();
        job2._company = "FCDA";
        job2._jobTitle = "Engineer";
        job2._startYear = 2018;
        job2._endYear = 2020;
        
        Resume myResume = new Resume();
        myResume._name = "Osondu Benjamin Ihentuge";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();


    }
}