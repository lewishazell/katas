using System.Text;

namespace LinkedList;

/// <summary>
/// Represents a singly linked list.
/// </summary>
/// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
public class LinkedList<T>
{
    private readonly StringBuilder stringBuilder = new();
    private Node? head;
    private Node? tail;

    /// <summary>
    /// Adds an object to the end of the <see cref="LinkedList{T}"/>.
    /// </summary>
    /// <param name="value">The object to be added to the end of the <see cref="LinkedList{T}"/>. The value can be <code>null</code> for reference types.</param>
    public void Add(T value)
    {
        Node newNode = new(value);

        if (head is null)
        {
            head = newNode;
        }

        if (tail is not null)
        {
            tail.Next = newNode;
        }

        tail = newNode;
    }

    /// <summary>
    /// Inserts an element into the <see cref="LinkedList{T}"/> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
    /// <param name="value">The object to insert. The value can be <code>null</code> for reference types.</param>
    /// <exception cref="IndexOutOfRangeException">
    ///     <paramref name="index"/> is less than 0.
    ///     -or-
    ///     <paramref name="index"/> is equal to or greater than the number of items.
    /// </exception>
    public void Insert(int index, T value)
    {
        if (index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        Node newNode = new(value);

        if (index == 0)
        {
            if (head is null)
            {
                throw new IndexOutOfRangeException();
            }

            newNode.Next = head;
            head = newNode;

            return;
        }

        Node node = NodeAt(index - 1);

        if (node.Next is null)
        {
            throw new IndexOutOfRangeException();
        }

        newNode.Next = node.Next;
        node.Next = newNode;
    }

    /// <summary>
    /// Deletes the element at the specified index of the <see cref="LinkedList{T}"/>.
    /// </summary>
    /// <param name="index">THe zero-based index of the element to remove.</param>
    /// <exception cref="IndexOutOfRangeException">
    ///     <paramref name="index"/> is less than 0.
    ///     -or-
    ///     <paramref name="index"/> is equal to or greater than the number of items.
    /// </exception>
    public void Delete(int index)
    {
        if (index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            if (head == null)
            {
                throw new IndexOutOfRangeException();
            }

            head = head?.Next;
            
            return;
        }

        Node node = NodeAt(index - 1);
        node.Next = node.Next?.Next;
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

    private Node NodeAt(int index)
    {
        int currentIndex = 0;
        for (Node? currentNode = head; currentNode is not null; currentNode = currentNode.Next)
        {
            if (currentIndex == index)
            {
                return currentNode;
            }

            currentIndex++;
        }

        throw new IndexOutOfRangeException();
    }

    private class Node
    {
        public T Value { get; }

        public Node? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public override string? ToString() => Value?.ToString();
    }
}
