﻿using System;
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
                var nums = formatter.GetFormattedString(args[0]);

                var calc = new Calculator(nums);

                Console.WriteLine(calc.GetSum());
            }
        }
    }
}