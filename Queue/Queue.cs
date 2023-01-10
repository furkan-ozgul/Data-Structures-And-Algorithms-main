using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Queue
{
    public class Queue<T>
    {
        private readonly IQueue<T> queue; // interface üzerinden islem yapacagız
        public int Count => queue.Count; // count sayısı
        public Queue(QueueType type = QueueType.Array)  // queue nesnesi olsutracaksa type nı vermek zorunda kalacak. Vermezse array olacak.
        {
            if (type==QueueType.Array)
            {
                queue = new ArrayQueue<T>();
            }
            else
            {
                queue = new LinkedListQueue<T>();
            }
        }
        public void EnQueue(T value) // ekleme
        {
            queue.EnQueue(value);
        }

        public T DeQueue()  // cıkartma
        {
            return queue.DeQueue();
        }

        public T Peek()  // peek
        {
            return queue.DeQueue();
        }
    }

    public interface IQueue<T> // dinamik bir yapı
    {
        int Count { get; } // okuma yapsın
        void EnQueue(T value);  // ekleme islemi
        T DeQueue();            // cıkartma islemi liste sonu
        T Peek();               // ek üstteki deger
    } 

    public enum QueueType
    {
        Array = 0,          // List<T>
        LinkedList = 1      // DoublyLinkedList<T>
    }
}
