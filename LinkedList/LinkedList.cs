using System.Text;

namespace LinkedList;

public class LinkedList<T>
{
    private readonly StringBuilder stringBuilder = new();
    private Node? head;

    public void Insert(int index, T value)
    {
        if (index == 0)
        {
            head = new() { Value = value };
        }
        else if (index == 1 && head is not null)
        {
            head.Next = new() { Value = value };
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public string PrintList()
    {
        stringBuilder.Clear();

        if (head is not null)
        {
            stringBuilder.Append(head.ToString());

            if (head.Next is not null)
            {
                stringBuilder.Append(',');
                stringBuilder.Append(head.Next.ToString());
            }
        }

        return stringBuilder.ToString();
    }

    private class Node
    {
        public required T Value { get; set; }

        public Node? Next { get; set; }

        public override string? ToString() => Value?.ToString();
    }
}
