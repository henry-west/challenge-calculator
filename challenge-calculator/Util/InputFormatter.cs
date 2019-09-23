using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace challenge_calculator
{
    public class InputFormatter
    {
        private const string DEFAULT_PATTERN = @",|\n";

        private Regex regex;
        
        public InputFormatter()
        {
            regex = new Regex(DEFAULT_PATTERN);
        }

        public void SetCustomDelimIfExists(string customDelim)
        {
            customDelim = customDelim.Replace("//", "");
            var delims = new List<string>() { Regex.Escape(customDelim) };

            if (customDelim.StartsWith("["))
            {
                delims = customDelim.Split('[', ']').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => Regex.Escape(x)).ToList();
            }

            regex = new Regex($"{DEFAULT_PATTERN}|{string.Join('|', delims)}");
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
