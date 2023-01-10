using DataStructures.LinkedList.SinglyLinkedList;
using System;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> list = 
            new SinglyLinkedList<T>();

        public int Count { get; private set; } //  // yazma islemi sadece sınıf icinde

        public T Peek()
        {
            if (Count == 0)
                throw new Exception("Stack Bos");
            return list.Head.Value;
        }

        public T Pop()
        {
            if (Count == 0) // count 0 ise
                throw new Exception("Stack Bos"); // stact bos hatası
            var temp = list.RemoveFirst();  // geciciyi ata 
            Count--;
            return temp;
        }

        public void Push(T value)
        {
            if (value == null) // boş ise
                throw new ArgumentNullException(); // hata gönderme
            list.AddFirst(value); // ekle
            Count++; // count arttır
        }
    }
}