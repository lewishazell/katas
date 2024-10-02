namespace StringCalculator;

public class StringCalculator
{
    private const char Delimiter = ',';

    public int Add(string input)
    {
        if (input == string.Empty)
        {
            return 0;
        }

        int result = 0;
        foreach (string number in input.Split(Delimiter))
        {
            result += int.Parse(number);
        }

        return result;
    }
}
