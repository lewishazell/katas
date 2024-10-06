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

    [Fact]
    public void When_I_Insert_An_Item_Into_A_List_I_Expect_It_To_Be_Printed()
    {
        LinkedList<string> sut = new();
        sut.Insert(0, "example");
        
        string output = sut.PrintList();

        Assert.Equal("example", output);
    }

    [Fact]
    public void When_I_Insert_Two_Items_Into_A_List_I_Expect_Both_To_Be_Printed()
    {
        LinkedList<string> sut = new();
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");

        string output = sut.PrintList();

        Assert.Equal("foo,bar", output);
    }
}