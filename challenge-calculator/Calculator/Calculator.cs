using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace challenge_calculator
{
    public class Calculator
    {
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
                else
                {
                    return num;
                }
            }
            catch (Exception)
            {
                return 0;
            }
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
