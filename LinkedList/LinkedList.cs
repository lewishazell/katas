namespace LinkedList;

public class LinkedList<T>
{
    private Node? head;

    public void Insert(int index, T value)
    {
        if (index != 0)
        {
            throw new IndexOutOfRangeException();
        }

        head = new() { Value = value };
    }

    public string PrintList()
    {
        return head?.ToString() ?? string.Empty;
    }

    private class Node
    {
        public required T Value { get; set; }

        public override string? ToString() => Value?.ToString();
    }
}
