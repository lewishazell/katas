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

        char[] delimiters = [NewLine, ReadDelimiter(input, out int startIndex)];
        List<int> negativeNumbers = [];
        int result = input.Substring(startIndex).Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Aggregate(0, (accumulated, potentialNumber) =>
        {
            int number = int.Parse(potentialNumber);
            
            if (number < 0)
            {
                negativeNumbers.Add(number);
            }

            return accumulated + number;
        });

        if (negativeNumbers.Any())
        {
            throw new InvalidNumberException($"negatives not allowed {string.Join(',', negativeNumbers)}");
        }

        return result;
    }

    private static char ReadDelimiter(string input, out int startIndex)
    {
        startIndex = 0;

        if (input.StartsWith(CustomDelimiterMarker))
        {
            startIndex = CustomDelimiterMarker.Length + 1;
            return input[CustomDelimiterMarker.Length];
        }

        return DefaultDelimiter;
    }
}
