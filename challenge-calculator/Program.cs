using System;
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
                if (nums.Length == 2)
                {
                    Console.WriteLine(nums.Sum(x => Int32.Parse(x)));
                }
            }
        }
    }
}
