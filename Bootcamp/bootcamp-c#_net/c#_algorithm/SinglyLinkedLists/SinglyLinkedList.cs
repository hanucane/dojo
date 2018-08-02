using System;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SllNode Head;
        public SinglyLinkedList() 
        {
            Head = null;
        }
        // SLL methods go here. As a starter, we will show you how to add a node to the list.
        public void Add(int value) 
        {
            SllNode newNode = new SllNode(value);
            if(Head == null) 
            {
                Head = newNode;
            } 
            else
            {
                SllNode runner = Head;
                while(runner.Next != null) {
                    runner = runner.Next;
                }
                runner.Next = newNode;
            }
        }  
        public void Remove()
        {
            SllNode runner = this.Head;
            while (runner != null){
                if (runner.Next.Next == null){
                    runner.Next = null;
                }
                runner = runner.Next;
            }
        } 
        public void PrintValues()
        {
            SllNode runner = this.Head;
            while (runner != null){
                Console.WriteLine(runner.Value);
                runner = runner.Next;
            }
        } 
        public SllNode Find(int _int)
        {
            SllNode runner = this.Head;
            while (runner != null){
                if (runner.Value == _int){
                    return runner;
                }
                runner = runner.Next;
            }
            return null;
        }
        // public void RemoveAt(int _int)
        // {
        //     SllNode runner = this.Head;
        //     int count = 0;
        //     if (count == _int){
        //         this.Head = runner.Next;
        //     }
        //     else {
        //         count ++;
        //     }
        //     while (runner != null){
        //         if (count == _int){
        //             if (runner.Next != null){
        //                 runner.Next = runner.Next.Next;
        //             }
        //             else {
        //                 runner.Next = null;
        //             }
        //         }
        //         else {
        //             count ++;
        //             runner = runner.Next;
        //         }
        //     }
        // }
    }
}