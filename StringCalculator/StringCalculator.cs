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
        List<int> negativeNumbers = [];
        int result = input.Split(delimiters).Aggregate(0, (accumulated, potentialNumber) =>
        {
            if (int.TryParse(potentialNumber, out int number))
            {
                if (number < 0)
                {
                    negativeNumbers.Add(number);
                }

                return accumulated + number;
            }

            return accumulated;
        });

        if (negativeNumbers.Any())
        {
            throw new InvalidNumberException($"negatives not allowed {string.Join(',', negativeNumbers)}");
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
