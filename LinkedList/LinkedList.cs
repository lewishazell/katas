using System.Text;

namespace LinkedList;

public class LinkedList<T>
{
    private readonly StringBuilder stringBuilder = new();
    private Node? head;

    public void Insert(int index, T value)
    {
        Node newNode = new() { Value = value };

        if (index == 0)
        {
            newNode.Next = head?.Next;
            head = newNode;

            return;
        }

        Update(index - 1, node =>
        {
            newNode.Next = node.Next?.Next;
            node.Next = newNode;
        });
    }

    public void Delete(int index)
    {
        if (index == 0)
        {
            head = head?.Next;
            
            return;
        }

        Update(index - 1, node => node.Next = node.Next?.Next);
    }

    public string PrintList()
    {
        stringBuilder.Clear();

        for (Node? currentNode = head; currentNode is not null; currentNode = currentNode.Next)
        {
            if (currentNode != head)
            {
                stringBuilder.Append(',');
            }

            stringBuilder.Append(currentNode.ToString());
        }

        return stringBuilder.ToString();
    }

    private void Update(int index, Action<Node> action)
    {
        int currentIndex = 0;
        for (Node? currentNode = head; currentNode is not null; currentNode = currentNode.Next)
        {
            if (currentIndex == index)
            {
                action(currentNode);

                return;
            }

            currentIndex++;
        }

        throw new IndexOutOfRangeException();
    }

    private class Node
    {
        public required T Value { get; set; }

        public Node? Next { get; set; }

        public override string? ToString() => Value?.ToString();
    }
}
