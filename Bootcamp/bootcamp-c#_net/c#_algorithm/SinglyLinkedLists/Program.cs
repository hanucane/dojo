using System;

namespace SinglyLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(2);
            list.Add(3);
            list.PrintValues();
            Console.WriteLine("-----");
            list.Remove();
            list.PrintValues();
            Console.WriteLine("-----");
            // list.RemoveAt(2);
            // list.PrintValues();
        }
    }
}
