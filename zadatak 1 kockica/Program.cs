using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    class Program
    {

        static void Main(string[] args)
        {
            Dice.RunDemo();


            Dice dice = new Dice();

            int WantedValue = 3;
            int NumOfExperiments = 20;
            int NumOfSides = dice.GetNumberOfSides();

            double AverageValue;
            AverageValue = dice.RunExperiment(WantedValue, NumOfExperiments, NumOfSides);

            Console.WriteLine($"\n\n\nAverage throws for {WantedValue} is {AverageValue}.");
            Console.ReadKey();
        }



    }
}