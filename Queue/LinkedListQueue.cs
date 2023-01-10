using DataStructures.LinkedList.DoublyLinkedList;
using System;

namespace DataStructures.Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        
        public int Count { get; private set; } // yazdırma sadece içeride olacak

        public T DeQueue()
        {
            if (Count == 0) // 0 ise hata döndür
                throw new Exception("Queue Bos");
            var temp = list.RemoveFirst();  // dizinin başında cıkart
            Count--;
            return temp;
        }

        public void EnQueue(T value)
        {
            if (value == null) // Null ise hata döndür
                throw new ArgumentNullException();
            list.AddLast(value); // listenin sonuna ekle
            Count++;
        }

        public T Peek() => Count == 0 
            ? throw new Exception("Queue Bos")
            : list.Head.Value; // Head elamanı döndür.
          
    }
}