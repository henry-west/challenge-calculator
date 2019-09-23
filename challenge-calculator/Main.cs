using System;
using System.Text.RegularExpressions;

namespace challenge_calculator
{
    public class ChallengeCalculator
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var formatter = new InputFormatter();
                var calc = new Calculator();

                var inputString = string.Empty;
                var customDelim = string.Empty;

                for (var i = 0; i < args.Length; i++)
                {
                    if ("+-/*".Contains(args[i]))
                    {
                        calc.Operation = args[i][0];
                    }
                    else if (args[i].StartsWith("-"))
                    {
                        try
                        {
                            switch (args[i])
                            {
                                case "-d":
                                    customDelim = Regex.Escape(args[i + 1]);
                                    Console.WriteLine($"Custom delimiter: {args[i + 1]}");
                                    break;
                                case "-n":
                                    calc.AllowNegative = Boolean.Parse(args[i + 1]);
                                    Console.WriteLine($"Allow negative numbers: {args[i + 1]}");
                                    break;
                                case "-u":
                                    calc.MaxValue = Int32.Parse(args[i + 1]);
                                    Console.WriteLine($"Upper limit: {args[i + 1]}");
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            throw new InvalidOptionException();
                        }
                    }
                    else
                    {
                        inputString = GetOrCreateInputStringFromArgs(args[i], customDelim);
                    }
                }

                ProcessInput(inputString, formatter, calc);
            }
        }

        public static string GetOrCreateInputStringFromArgs(string arg, string customDelim)
        {
            if (arg.StartsWith("//") && !string.IsNullOrWhiteSpace(customDelim))
            {
                return arg.Replace("//", $"//[{customDelim}]");
            }
            else if (!string.IsNullOrWhiteSpace(customDelim))
            {
                return $@"//[{customDelim}]\n{arg}";
            }

            return arg;
        }

        public static void ProcessInput(string inputString, InputFormatter formatter, Calculator calc)
        {
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

    public class InvalidOptionException : Exception
    {
        public InvalidOptionException() 
            : base(
            "Invalid options. Try the following and resubmit:\n* For a custom delimiter use '-d' followed by your delimiter\n* To allow negatives use '-n' followed by 'true' or 'false'\n* For a custom upper limit use -u followed by an integer value")
        {

        }
    }
}
