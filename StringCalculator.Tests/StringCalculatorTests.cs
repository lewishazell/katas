namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator sut = new();
    
    [Fact]
    public void When_I_Pass_An_Empty_String_I_Expect_A_Result_Of_0()
    {
        int result = sut.Add(string.Empty);

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("10", 10)]
    [InlineData("100", 100)]
    public void When_I_Pass_A_Single_Number_I_Expect_A_Result_Of_Its_Sum(string input, int expectedResult)
    {
        int result = sut.Add(input);

        Assert.Equal(expectedResult, result);
    }
}