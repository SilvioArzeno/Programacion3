using System;
using System.Text.RegularExpressions;
namespace INTEC.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string SplitCammeCase(this string str)
        {
            return Regex.Replace(str, "(\\B[A-Z])", " $1");
        }
    }
}
