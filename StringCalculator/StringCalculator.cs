namespace StringCalculator;

public class StringCalculator
{
    public int Add(string input)
    {
        const string NewLine = "\n";

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
        const string DefaultDelimiter = ",";
        const string CustomDelimiterMarker = "//";
        const char MultiCharDelimiterOpenSymbol = '[';
        const char MultiCharDelimiterCloseSymbol = ']';        

        if (input.StartsWith(CustomDelimiterMarker))
        {
            int headerStartIndex = CustomDelimiterMarker.Length;

            if (input[headerStartIndex] == MultiCharDelimiterOpenSymbol)
            {
                List<string> delimiters = [];
                int nextTokenIndex = headerStartIndex;

                do
                {
                    int endIndex = input.IndexOf(MultiCharDelimiterCloseSymbol, nextTokenIndex);

                    delimiters.Add(input[(nextTokenIndex + 1)..endIndex]);
                    nextTokenIndex = endIndex + 1;
                } while (input[nextTokenIndex] == MultiCharDelimiterOpenSymbol);

                length = nextTokenIndex;
                return delimiters;
            }
            else
            {
                length = headerStartIndex + 1;
                return [input[headerStartIndex].ToString()];
            }
        }

        length = 0;
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
