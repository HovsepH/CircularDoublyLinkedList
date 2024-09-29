CircularDoublyLinkedList<int> list = new();
list.InsertAtBeginning(0);
list.InsertAtBeginning(1);
list.InsertAtBeginning(2);
list.PrintList();

Console.WriteLine(list.count);

list.InsertAfterNodePosition(1, 7);
list.PrintList();

