using System.Text;
using System.Text.RegularExpressions;

namespace Logic.Extensions;
public static class StringExtensions
{
    public static string ToBase64(this string input)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        string base64String = Convert.ToBase64String(inputBytes);
        return base64String;
    }

    public static List<string> SplitWithDelimiters(this string input, string delimiters)
    {
        var pattern = $"([{Regex.Escape(delimiters)}])";
        var substrings = Regex.Split(input, pattern);

        return substrings.Where(substring => !string.IsNullOrWhiteSpace(substring)).ToList();
    }
}