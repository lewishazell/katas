namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator sut = new();
    
    [Fact]
    public void When_I_Pass_An_Empty_String_I_Expect_A_Result_Of_0() => TestAdd(string.Empty, 0);

    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("10", 10)]
    [InlineData("100", 100)]
    public void When_I_Pass_A_Single_Number_I_Expect_A_Result_Of_Its_Sum(string input, int expectedResult) => TestAdd(input, expectedResult);

    [Theory]
    [InlineData("0,0", 0)]
    [InlineData("1,0", 1)]
    [InlineData("1,2", 3)]
    [InlineData("10,1", 11)]
    [InlineData("100,10", 110)]
    public void When_I_Pass_Two_Numbers_I_Expect_A_Result_Of_Their_Sum(string input, int expectedResult) => TestAdd(input, expectedResult);

    [Theory]
    [InlineData("0,0,0", 0)]
    [InlineData("1,1,0", 2)]
    [InlineData("1,2,3,4,5", 15)]
    [InlineData("1,20,300,1000", 1321)]
    [InlineData("256,64,128,32,64,16", 560)]
    public void When_I_Pass_An_Unknown_Amount_Of_Numbers_I_Expect_A_Result_Of_Their_Sum(string input, int expectedResult) => TestAdd(input, expectedResult);

    [Fact]
    public void When_I_Pass_Numbers_Delimited_By_NewLines_And_Commas_I_Expect_A_Result_Of_Their_Sum() => TestAdd("1\n2,3", 6);

    [Fact]
    public void When_I_Specify_A_Delimiter_On_The_First_Line_I_Expect_To_Be_Able_To_Delimit_Numbers_By_It() => TestAdd("//;\n1;2", 3);

    [Theory]
    [InlineData("1,-1", "-1")]
    [InlineData("1,-1,-2", "-1,-2")]
    public void When_I_Pass_A_Negative_Number_I_Expect_An_Exception_To_Be_Thrown(string input, string expectedNegatives)
    {
        var exception = Assert.Throws<InvalidNumberException>(() => sut.Add(input));

        Assert.Equal($"negatives not allowed {expectedNegatives}", exception.Message);
    }

    [Fact]
    public void When_I_Pass_A_Number_Greater_Than_1000_I_Expect_It_To_Be_Ignored_In_The_Resulting_Sum() => TestAdd("2,1001", 2);

    [Fact]
    public void When_I_Specify_A_Multi_Character_Delimiter_I_Expected_To_Be_Able_To_Delimit_Numbers_By_It() => TestAdd("//[***]\n1***2***3", 6);

    [Fact]
    public void When_I_Specify_Multiple_Delimiters_I_Expect_To_Be_Able_To_Delimit_Numbers_By_All_Of_Them() => TestAdd("//[*][%]\n1*2%3", 6);

    [Fact]
    public void When_I_Specify_Multiple_Multi_Character_Delimiters_I_Expect_To_Be_Able_To_Delimit_Numbers_By_All_Of_Them() => TestAdd("//[***][%%%]\n1***2%%%3", 6);

    private void TestAdd(string input, int expectedResult)
    {
        int result = sut.Add(input);

        Assert.Equal(expectedResult, result);
    }
}