namespace StringCalculator;

public class StringCalculator
{
    private const char NewLine = '\n';
    private const char DefaultDelimiter = ',';
    private const string CustomDelimiterMarker = "//";

    public int Add(string input)
    {
        if (input == string.Empty)
        {
            return 0;
        }

        char[] delimiters = [NewLine, ReadDelimiter(input)];
        int result = 0;
        foreach (string number in input.Split(delimiters))
        {
            if (int.TryParse(number, out int parsed))
            {
                result += parsed;
            }
        }

        return result;
    }

    private static char ReadDelimiter(string input)
    {
        if (input.StartsWith(CustomDelimiterMarker))
        {
            return input[CustomDelimiterMarker.Length];
        }

        return DefaultDelimiter;
    }
}
