namespace StringCalculator;

public class StringCalculator
{
    private static readonly char[] Delimiters = [',', '\n'];

    public int Add(string input)
    {
        if (input == string.Empty)
        {
            return 0;
        }

        int result = 0;
        foreach (string number in input.Split(Delimiters))
        {
            result += int.Parse(number);
        }

        return result;
    }
}
