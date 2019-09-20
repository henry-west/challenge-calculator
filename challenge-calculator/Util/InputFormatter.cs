using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace challenge_calculator
{
    public class InputFormatter
    {
        private Regex regex;
        private string pattern;

        public InputFormatter()
        {
            pattern = @",|\\n";
            regex = new Regex(pattern);
        }

        public string[] GetFormattedString(string args)
        {
            return regex.Split(args);
        }
    }
}
