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
                var nums = args[0].Split(",");
                var calc = new Calculator(nums);

                if (nums.Length <= 2)
                {
                    Console.WriteLine(calc.GetSum());
                }
            }
        }
    }
}
