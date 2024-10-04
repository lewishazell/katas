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

        char delimiter = DefaultDelimiter;
        if (input.StartsWith(CustomDelimiterMarker))
        {
            delimiter = input[CustomDelimiterMarker.Length];
        }

        char[] delimiters = [NewLine, delimiter];
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


}
