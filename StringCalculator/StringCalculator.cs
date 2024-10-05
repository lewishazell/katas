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
        IEnumerable<int> numbers = input.Substring(startIndex).Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        
        Validate(numbers);
        return numbers.Sum();
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

    private static void Validate(IEnumerable<int> numbers)
    {
        IEnumerable<int> negativeNumbers = numbers.Where(number => number < 0).ToList();

        if (negativeNumbers.Any()) {
            throw new InvalidNumberException($"negatives not allowed {string.Join(',', negativeNumbers)}");
        }
    }
}
