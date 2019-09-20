using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace challenge_calculator
{
    public class Calculator
    {
        public Calculator(string[] args)
        {
            nums = args.Select(x => TryParseInt(x));
        }

        private IEnumerable<int> nums { get; }

        public int TryParseInt(string value)
        {
            try
            {
                return Int32.Parse(value);
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
