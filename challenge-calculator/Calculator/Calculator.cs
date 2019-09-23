using System;
using System.Collections.Generic;
using System.Linq;

namespace challenge_calculator
{
    public class Calculator
    {
        public const int MAXIMUM_VALUE = 1000;

        private List<int> nums;
        private List<int> negativeValues;

        public Calculator()
        {
            negativeValues = new List<int>();
            nums = new List<int>();
        }

        public void ParseList(string[] numList)
        {
            nums = numList.Select(x => GetValidIntFromString(x)).ToList();

            if (negativeValues.Count > 0)
            {
                throw new Exception($"Negative numbers not allowed: {String.Join(", ", negativeValues)}");
            }
        }

        public int GetValidIntFromString(string value)
        {
            try
            {
                var num = Int32.Parse(value);

                if (num < 0)
                {
                    negativeValues.Add(num);
                    return 0;
                }
                else if (num > MAXIMUM_VALUE)
                {
                    return 0;
                }
                else
                {
                    return num;
                }
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public string GetFormula()
        {
            return string.Join("+", nums);
        }

        public int GetSum()
        {
            return nums.Sum();
        }

        public int GetNumCount()
        {
            return nums.Count();
        }
    }

}
