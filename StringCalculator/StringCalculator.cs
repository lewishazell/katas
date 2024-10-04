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
        return input.Split(delimiters).Aggregate(0, (accumulated, potentialNumber) =>
        {
            if (int.TryParse(potentialNumber, out int number))
            {
                return accumulated + number;
            }

            return accumulated;
        });
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
