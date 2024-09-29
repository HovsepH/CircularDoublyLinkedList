public class CircularDoublyLinkedList<T>
{
    private Node<T> first;
    public int count { get; private set; } = 0;
    public int InsertAtBeginning(T value)
    {
        Node<T> node = new(value);
        count++;

        if (first == null)
        {
            first = node;
            first.nextNode = first;
            first.prevNode = first;
        }
        else
        {
            var last = first.prevNode;
            node.nextNode = first;
            first.prevNode = node;
            node.prevNode = last;
            last.nextNode = node;
            first = node;
        }

        //position
        return 0;
    }

    public int InsertAfterNodePosition(int nodePosition, T value)
    {
        if (nodePosition < 0 || nodePosition >= count)
        {
            return -1;
        }

        count++;
        var node = GetNodeByPosition(nodePosition);
        var next = node.nextNode;
        var newNode = new Node<T>(value);

        node.nextNode = newNode;
        newNode.prevNode = node;
        newNode.nextNode = next;
        next.prevNode = newNode;

        return nodePosition + 1;
    }

    public void PrintList()
    {
        if (first == null)
        {
            return;
        }

        var current = first;
        do
        {
            Console.Write(current.value + ", ");
            current = current.nextNode;
        } while (current != first);

        Console.WriteLine();
    }

    private class Node<T>
    {
        public Node<T> prevNode { get; set; }
        public Node<T> nextNode { get; set; }

        public T value { get; set; }

        public Node(T value)
        {
            this.value = value;
            prevNode = null;
            nextNode = null;
        }
    }

    private Node<T> GetNodeByPosition(int position)
    {
        if (position < 0 ||position >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
        }

        int currentPos = 0;
        var currentNode = first;

        while (currentPos != position)
        {
            currentNode = currentNode.nextNode;
            currentPos++;
        }

        return currentNode;
    }
}