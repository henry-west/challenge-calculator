using System;
using System.Diagnostics;
using System.Linq;

namespace challenge_calculator
{
    class ChallengeCalculator
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var inputString = args[0];
                var formatter = new InputFormatter();
                var calc = new Calculator();

                while (!string.IsNullOrWhiteSpace(inputString))
                {
                    var nums = formatter.GetNumListFromString(inputString);
                    calc.ParseList(nums);

                    Console.WriteLine($"Formula: {calc.GetFormula()}");
                    Console.WriteLine($"Sum: {calc.GetSum()}");

                    Console.WriteLine("Enter another list or Ctrl+C to exit:");
                    inputString = Console.ReadLine();
                }
            }
        }
    }
}
