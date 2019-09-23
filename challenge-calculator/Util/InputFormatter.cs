using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace challenge_calculator
{
    public class InputFormatter
    {
        private const string RESERVED_CHARS = @"+*?^$\.[]{}()|/";
        private const string DEFAULT_PATTERN = @",|\n";

        private Regex regex;
        
        public InputFormatter()
        {
            regex = new Regex(DEFAULT_PATTERN);
        }

        public void SetCustomDelimIfExists(string customDelim)
        {
            customDelim = customDelim.Replace("//", "");
            regex = new Regex($"{DEFAULT_PATTERN}|{EscapeDelimIfReserved(customDelim)}");
        }

        private string EscapeDelimIfReserved(string customDelim)
        {
            if (RESERVED_CHARS.Contains(customDelim))
            {
                return customDelim.Insert(0, @"\");
            }

            return customDelim;
        }

        public string[] GetNumListFromString(string args)
        {
            if (args.StartsWith("//"))
            {
                var split = args.Split(@"\\n", 2);
                var customDelim = split[0];
                var nums = split[1];
                SetCustomDelimIfExists(customDelim);

                return regex.Split(nums);
            }
            else
            {
                return regex.Split(args);
            }
        }
    }
}
