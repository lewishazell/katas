namespace LinkedList.Tests;

using LinkedList;

public class LinkedListTests
{
    [Fact]
    public void When_I_Print_An_Empty_List_I_Expect_An_Empty_String()
    {
        LinkedList<string> sut = new();
        string output = sut.PrintList();

        Assert.Equal(string.Empty, output);
    }
}