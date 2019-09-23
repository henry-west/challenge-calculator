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
                var formatter = new InputFormatter();
                var calc = new Calculator();

                var inputString = string.Empty;

                for (var i = 0; i < args.Length; i++)
                {
                    if ("+-/*".Contains(args[i]))
                    {
                        calc.Operation = args[i][0];
                    }
                    else
                    {
                        inputString = args[i];
                    }
                }

                while (!string.IsNullOrWhiteSpace(inputString))
                {
                    var nums = formatter.GetNumListFromString(inputString);
                    calc.ParseList(nums);

                    Console.WriteLine($"Formula: {calc.GetFormula()}");
                    Console.WriteLine($"Result: {calc.GetResult()}");

                    Console.WriteLine("Enter another list or Ctrl+C to exit:");
                    inputString = Console.ReadLine();
                }
            }
        }
    }
}
