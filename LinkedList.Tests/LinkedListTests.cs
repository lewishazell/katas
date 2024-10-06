namespace LinkedList.Tests;

using LinkedList;

public class LinkedListTests
{
    private readonly LinkedList<string> sut = new();

    [Fact]
    public void When_I_Print_An_Empty_List_I_Expect_An_Empty_String()
    {
        AssertPrintedListIs(string.Empty);
    }

    [Fact]
    public void When_I_Insert_An_Item_Into_A_List_I_Expect_It_To_Be_Printed()
    {
        sut.Insert(0, "example");

        AssertPrintedListIs("example");
    }

    [Fact]
    public void When_I_Insert_Two_Items_Into_A_List_I_Expect_Both_To_Be_Printed()
    {
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");

        AssertPrintedListIs("foo,bar");
    }

    [Fact]
    public void When_I_Replace_The_First_Item_In_A_Two_Item_List_I_Expect_The_New_Item_To_Be_Displayed_In_Place_Of_The_Original()
    {
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");
        sut.Insert(0, "baz");

        AssertPrintedListIs("baz,bar");
    }

    [Fact]
    public void When_I_Insert_An_Unknown_Number_Of_Items_Into_A_List_I_Expect_All_Items_To_Be_Printed()
    {
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");
        sut.Insert(2, "baz");
        sut.Insert(3, "qux");
        sut.Insert(4, "quux");

        AssertPrintedListIs("foo,bar,baz,qux,quux");
    }

    [Fact]
    public void When_I_Insert_An_Item_Into_The_Middle_Of_A_List_I_Expect_The_New_Item_To_Print_In_Place_Of_The_Original()
    {
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");
        sut.Insert(2, "baz");
        sut.Insert(1, "qux");

        AssertPrintedListIs("foo,qux,baz");
    }

    [Fact]
    public void When_I_Insert_An_Item_Into_The_End_Of_A_List_I_Expect_The_New_Item_To_Print_In_Place_Of_The_Original()
    {
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");
        sut.Insert(2, "baz");
        sut.Insert(2, "qux");

        AssertPrintedListIs("foo,bar,qux");
    }

    [Fact]
    public void When_I_Delete_An_Item_I_Expect_It_To_Not_Be_Printed()
    {
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");
        sut.Insert(2, "baz");
        
        sut.Delete(0);

        AssertPrintedListIs("bar,baz");
    }

    [Fact]
    public void When_I_Delete_An_Item_From_The_Middle_Of_The_List_I_Expect_It_To_Not_Be_Printed()
    {
        sut.Insert(0, "foo");
        sut.Insert(1, "bar");
        sut.Insert(2, "baz");

        sut.Delete(1);

        AssertPrintedListIs("foo,baz");
    }

    private void AssertPrintedListIs(string expectedOutput)
    {
        Assert.Equal(expectedOutput, sut.PrintList());
    }
}