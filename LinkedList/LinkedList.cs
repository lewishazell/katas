using System.Text;

namespace LinkedList;

public class LinkedList<T>
{
    private readonly StringBuilder stringBuilder = new();
    private Node? head;

    public void Insert(int index, T value)
    {
        Node node = new() { Value = value };

        if (index == 0)
        {
            node.Next = head?.Next;

            head = node;
        }
        else if (index == 1 && head is not null)
        {
            head.Next = node;
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
