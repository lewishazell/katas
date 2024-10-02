namespace StringCalculator;

public class StringCalculator
{
    public int Add(string input)
    {
        if (input == string.Empty)
        {
            return 0;
        }

        return int.Parse(input);
    }
}
