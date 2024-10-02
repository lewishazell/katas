namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void When_I_Pass_An_Empty_String_I_Expect_A_Result_Of_0()
    {
        StringCalculator sut = new();

        int result = sut.Add(string.Empty);

        Assert.Equal(0, result);
    }
}