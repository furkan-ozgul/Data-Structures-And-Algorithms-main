using System;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly List<T> list = new List<T>();

        public int Count { get; private set; } // yazdırma sadece içeride olacak

        public T DeQueue()
        {
            if (Count == 0) // 0 ise hata döndür
                throw new Exception("Queue Bos");
            var temp = list[0]; // dizinin başında cıkart
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public void EnQueue(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            list.Add(value); // listenin sonuna ekle
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)   
                throw new Exception("Queue Bos");
            return list[0];  // 0. elamanı döndür.
        }
    }
}