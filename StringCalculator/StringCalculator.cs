namespace StringCalculator;

public class StringCalculator
{
    private const string NewLine = "\n";
    private const string DefaultDelimiter = ",";
    private const string CustomDelimiterMarker = "//";
    private const char MultiCharDelimiterOpenToken = '[';
    private const char MultiCharDelimiterCloseToken = ']';

    public int Add(string input)
    {
        if (input == string.Empty)
        {
            return 0;
        }

        string[] delimiters = [NewLine, ReadDelimiterHeader(input, out int startIndex)];
        IEnumerable<int> numbers = input.Substring(startIndex).Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(number => number <= 1000)
            .ToList();
        
        Validate(numbers);
        return numbers.Sum();
    }

    private static string ReadDelimiterHeader(string input, out int length)
    {
        length = 0;

        if (input.StartsWith(CustomDelimiterMarker))
        {
            int startIndex = CustomDelimiterMarker.Length;
            if (input[startIndex] == MultiCharDelimiterOpenToken)
            {
                int endIndex = input.IndexOf(MultiCharDelimiterCloseToken);
                length = endIndex + 1;
                return input[(startIndex + 1)..endIndex];
            }
            else
            {
                length = startIndex + 1;
                return input[startIndex].ToString();
            }
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
