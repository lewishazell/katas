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
        sut.Add("example");

        AssertPrintedListIs("example");
    }

    [Fact]
    public void When_I_Insert_Two_Items_Into_A_List_I_Expect_Both_To_Be_Printed()
    {
        sut.Add("foo");
        sut.Add("bar");

        AssertPrintedListIs("foo,bar");
    }

    [Fact]
    public void When_I_Replace_The_First_Item_In_A_Two_Item_List_I_Expect_The_New_Item_To_Be_Displayed_Before_The_Original()
    {
        sut.Add("foo");
        sut.Add("bar");
        sut.Insert(0, "baz");

        AssertPrintedListIs("baz,foo,bar");
    }

    [Fact]
    public void When_I_Insert_An_Unknown_Number_Of_Items_Into_A_List_I_Expect_All_Items_To_Be_Printed()
    {
        sut.Add("foo");
        sut.Add("bar");
        sut.Add("baz");
        sut.Add("qux");
        sut.Add("quux");

        AssertPrintedListIs("foo,bar,baz,qux,quux");
    }

    [Fact]
    public void When_I_Insert_An_Item_Into_The_Middle_Of_A_List_I_Expect_The_New_Item_To_Print_Before_The_Original()
    {
        sut.Add("foo");
        sut.Add("bar");
        sut.Add("baz");
        sut.Insert(1, "qux");

        AssertPrintedListIs("foo,qux,bar,baz");
    }

    [Fact]
    public void When_I_Insert_An_Item_Into_The_Last_Index_Of_A_List_I_Expect_The_New_Item_To_Print_Before_The_Original()
    {
        sut.Add("foo");
        sut.Add("bar");
        sut.Add("baz");
        sut.Insert(2, "qux");

        AssertPrintedListIs("foo,bar,qux,baz");
    }

    [Fact]
    public void When_I_Delete_An_Item_I_Expect_It_To_Not_Be_Printed()
    {
        sut.Add("foo");
        sut.Add("bar");
        sut.Add("baz");
        
        sut.Delete(0);

        AssertPrintedListIs("bar,baz");
    }

    [Fact]
    public void When_I_Delete_An_Item_From_The_Middle_Of_The_List_I_Expect_It_To_Not_Be_Printed()
    {
        sut.Add("foo");
        sut.Add("bar");
        sut.Add("baz");

        sut.Delete(1);

        AssertPrintedListIs("foo,baz");
    }

    [Fact]
    public void When_I_Delete_An_Item_From_The_Tail_Of_The_List_I_Expect_It_To_Not_Be_Printed()
    {
        sut.Add("foo");
        sut.Add("bar");
        sut.Add("baz");

        sut.Delete(2);

        AssertPrintedListIs("foo,bar");
    }

    [Fact]
    public void When_I_Insert_The_First_Item_I_Expect_An_IndexOutOfRangeException_To_Be_Thrown()
    {
        Assert.Throws<IndexOutOfRangeException>(() => sut.Insert(0, "foo"));
    }

    [Fact]
    public void When_I_Insert_At_A_Negative_Index_I_Expect_An_IndexOutOfRangeException_To_Be_Thrown()
    {
        Assert.Throws<IndexOutOfRangeException>(() => sut.Insert(-1, "foo"));
    }

    [Fact]
    public void When_I_Insert_At_An_Unallocated_Index_I_Expect_An_IndexOutOfRangeException_To_Be_Thrown()
    {
        sut.Add("foo");

        Assert.Throws<IndexOutOfRangeException>(() => sut.Insert(1, "bar"));
    }

    [Fact]
    public void When_I_Delete_At_An_Unallocated_Index_I_Expect_An_IndexOutOfRangeException_To_Be_Thrown()
    {
        Assert.Throws<IndexOutOfRangeException>(() => sut.Delete(0));
    }

    [Fact]
    public void When_I_Delete_At_A_Negative_Index_I_Expect_An_IndexOutOfRangeException_To_Be_Thrown()
    {
        Assert.Throws<IndexOutOfRangeException>(() => sut.Delete(-1));
    }

    private void AssertPrintedListIs(string expectedOutput)
    {
        Assert.Equal(expectedOutput, sut.PrintList());
    }
}