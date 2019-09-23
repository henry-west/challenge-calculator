using System;
using System.Collections.Generic;
using System.Linq;

namespace challenge_calculator
{
    public class Calculator
    {
        private List<int> nums;
        private readonly List<int> negativeValues;

        public char Operation = '+';
        public int MaxValue = 1000;
        public bool AllowNegative = false;

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

                if (!AllowNegative && num < 0)
                {
                    negativeValues.Add(num);
                    return 0;
                }
                else if (num > MaxValue)
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
            return string.Join(Operation, nums);
        }

        public object GetResult()
        {
            switch (Operation)
            {
                case '+':
                    return GetSum();
                case '-':
                    return GetDifference();
                case '*':
                    return GetProduct();
                case '/':
                    return GetDividend();
                default:
                    return 0;
            }
        }

        public int GetSum()
        {
            return nums.Sum();
        }

        public int GetDifference()
        {
            int difference = nums.First();
            foreach (var num in nums.Skip(1))
            {
                difference -= num;
            }

            return difference;
        }

        public long GetProduct()
        {
            long product = 1;
            foreach (var num in nums)
            {
                product *= num;
            }

            return product;
        }

        public float GetDividend()
        {
            float dividend = nums.First();
            foreach (var num in nums.Skip(1))
            {
                if (num == 0)
                {
                    throw new Exception("Divide-by-zero machine broke");
                }
                else
                {
                    dividend /= num;
                }
            }

            return dividend;
        }

        public int GetNumCount()
        {
            return nums.Count();
        }
    }

}
