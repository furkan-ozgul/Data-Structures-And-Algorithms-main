using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; } // yazma islemi sadece sınıf icinde
        
        private readonly List<T> list = new List<T>();

        public T Peek()
        {
            if (Count == 0) // 0 a esitse
                throw new Exception("Stack Bos");  // hata gonderme
            return list[list.Count - 1];
        }

        public T Pop()
        {
            if (Count == 0) // listede eleman yoksa 
                throw new Exception("Stack Bos"); // hata gönderiyoruz

            var temp = list[list.Count - 1]; // gecici degiskene atıyoruz
            list.RemoveAt(list.Count - 1); // listenin sonundaki bir elemanı cıkartacak
            Count--;
            return temp;
        }

        public void Push(T value)
        {
            if (value == null)
                throw new ArgumentNullException(); // hata gonderme
            list.Add(value);
            Count++;
        }
    }
}