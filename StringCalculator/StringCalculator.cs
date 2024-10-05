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

        string[] delimiters = [NewLine, ..ReadDelimiterHeader(input, out int startIndex)];
        IEnumerable<int> numbers = input.Substring(startIndex).Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Where(number => number <= 1000)
            .ToList();
        
        Validate(numbers);
        return numbers.Sum();
    }

    private static IEnumerable<string> ReadDelimiterHeader(string input, out int length)
    {
        length = 0;

        if (input.StartsWith(CustomDelimiterMarker))
        {
            int headerStartIndex = CustomDelimiterMarker.Length;

            if (input[headerStartIndex] == MultiCharDelimiterOpenToken)
            {
                List<string> delimiters = [];
                int nextTokenIndex = headerStartIndex;

                do
                {
                    int endIndex = input.IndexOf(MultiCharDelimiterCloseToken, nextTokenIndex);

                    delimiters.Add(input[(nextTokenIndex + 1)..endIndex]);
                    nextTokenIndex = endIndex + 1;
                } while (input[nextTokenIndex] == MultiCharDelimiterOpenToken);

                length = nextTokenIndex;
                return delimiters;
            }
            else
            {
                length = headerStartIndex + 1;
                return [input[headerStartIndex].ToString()];
            }
        }

        return [DefaultDelimiter];
    }

    private static void Validate(IEnumerable<int> numbers)
    {
        IEnumerable<int> negativeNumbers = numbers.Where(number => number < 0).ToList();

        if (negativeNumbers.Any()) {
            throw new InvalidNumberException($"negatives not allowed {string.Join(',', negativeNumbers)}");
        }
    }
}
