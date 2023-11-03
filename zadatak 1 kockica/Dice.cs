using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Dice
    {
        private int NumOfSides;
        private int WantedValue;
        private Random random = new Random();

        public Dice()
        {
            NumOfSides = 6;
            WantedValue = 1;
        }

        public Dice(int NumOfSides, int WantedValue, Random random)
        {

            if (NumOfSides < 2)
                throw new ArgumentException("Minimal sides of dice must be 2.");
            this.NumOfSides = NumOfSides;
            this.WantedValue = WantedValue;
        }

        public void Roll()
        {
            WantedValue = random.Next(1, NumOfSides + 1);
        }

        public int GetCurrentNumber()
        {
            if (WantedValue > NumOfSides)
            {
                Console.WriteLine("Error!");
                return 1;
            }
            else
            {
                return WantedValue;
            }
        }

        public void SetCurrentNumber(int WantedValue)
        {
            this.WantedValue = WantedValue;
        }

        public int GetNumberOfSides()
        {
            return NumOfSides;
        }

        public static void RunDemo()
        {
            Dice first = new Dice();
            Dice second = new Dice(20, 6, new Random());

            Console.WriteLine($"First dice: {first.GetNumberOfSides()}, rolled: {first.GetCurrentNumber()}");
            Console.WriteLine($"Second dice: {second.GetNumberOfSides()}, rolled: {second.GetCurrentNumber()}.\n");
            first.SetCurrentNumber(6);
            second.SetCurrentNumber(99);
            Console.WriteLine($"First dice: {first.GetNumberOfSides()}, rolled: {first.GetCurrentNumber()}");
            Console.WriteLine($"Second dice: {second.GetNumberOfSides()}, rolled: {second.GetCurrentNumber()}.\n");
            first.Roll();
            second.Roll();
            Console.WriteLine($"First dice: {first.GetNumberOfSides()}, rolled: {first.GetCurrentNumber()}");
            Console.WriteLine($"Second dice: {second.GetNumberOfSides()}, rolled: {second.GetCurrentNumber()}.");

        }

        public double RunExperiment(int WantedValue, int NumOfExperiments, int NumOfSides)
        {
            if (WantedValue < 1 || WantedValue > NumOfSides)
                throw new ArgumentException($"Number must be between: 1 and {NumOfSides}.\n");

            if (NumOfExperiments < 1)
                throw new ArgumentException("Not enough number of experiments.\n");



            int[] NeededThrows = new int[NumOfExperiments];

            for (int i = 0; i < NumOfExperiments; i++)
            {
                int throws = 0;
                while (true)
                {
                    Roll();
                    throws++;
                    if (GetCurrentNumber() == WantedValue)
                        break;
                }
                NeededThrows[i] = throws;
            }
            double AverageValue = NeededThrows.Average();
            return AverageValue;
        }

    }
}