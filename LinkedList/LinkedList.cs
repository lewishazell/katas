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

            return;
        }

        int currentIndex = 0;
        for (Node? currentNode = head; currentNode is not null; currentNode = currentNode.Next)
        {
            if (currentIndex == index - 1)
            {
                node.Next = currentNode.Next?.Next;
                currentNode.Next = node;

                return;
            }

            currentIndex++;
        }
        
        throw new IndexOutOfRangeException();
    }

    public void Delete(int index)
    {
        if (index == 0)
        {
            head = head?.Next;
            
            return;
        }

        throw new IndexOutOfRangeException();
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

    private class Node
    {
        public required T Value { get; set; }

        public Node? Next { get; set; }

        public override string? ToString() => Value?.ToString();
    }
}
