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

    [Fact]
    public void When_I_Replace_The_First_Item_In_A_Two_Item_List_I_Expect_The_New_Item_To_Be_Displayed_In_Place_Of_The_Original()
    {
        LinkedList<string> sut = new();
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");
        sut.Insert(0, "baz");

        string output = sut.PrintList();

        Assert.Equal("baz,bar", output);
    }
}