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

        int delimiterIndex = input.IndexOf(Delimiter);
        string firstNumber = input.Substring(0, delimiterIndex);
        string secondNumber = input.Substring(delimiterIndex + 1);
        return int.Parse(firstNumber) + int.Parse(secondNumber);
    }
}
