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

        char[] delimiters = [NewLine, ReadDelimiterHeader(input, out int startIndex)];
        IEnumerable<int> numbers = input.Substring(startIndex).Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(number => number <= 1000)
            .ToList();
        
        Validate(numbers);
        return numbers.Sum();
    }

    private static char ReadDelimiterHeader(string input, out int length)
    {
        length = 0;

        if (input.StartsWith(CustomDelimiterMarker))
        {
            length = CustomDelimiterMarker.Length + 1;
            return input[CustomDelimiterMarker.Length];
        }

        return DefaultDelimiter;
    }

    private static void Validate(IEnumerable<int> numbers)
    {
        IEnumerable<int> negativeNumbers = numbers.Where(number => number < 0).ToList();

        if (negativeNumbers.Any()) {
            throw new InvalidNumberException($"negatives not allowed {string.Join(',', negativeNumbers)}");
        }
    }
}
