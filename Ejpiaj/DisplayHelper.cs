using System;
using System.Text.RegularExpressions;

namespace Ejpiaj
{
    public static class DisplayHelper
    {
        public static string StripHTML(string input)
        {
            string ret = Regex.Replace(input, "<.*?>", String.Empty);
            return ret.Replace("&gt;", Environment.NewLine);
        }
    }
}
