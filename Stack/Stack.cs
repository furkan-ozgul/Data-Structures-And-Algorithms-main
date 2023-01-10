using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stack
{
    public class Stack<T>
    {
        private readonly IStack<T> stack;
        public int Count => stack.Count;
        public Stack(StackType type = StackType.Array) // varsayılan deger Array
        {
            if (type==StackType.Array) // esitse
            {
                stack = new ArrayStack<T>(); // generik sekilde 
            }
            else
            {
                stack = new LinkedListStack<T>();
            }
        }
        
        public T Pop() // cıkarma islemi
        {
            return stack.Pop();
        }

        public T Peek() // en son elemanı gösterir
        {
            return stack.Peek();
        }

        public void Push(T value) // ekleme islemi
        {
            stack.Push(value);
        }
    
    }

    public interface IStack<T>
    {
        int Count { get; }
        void Push(T value); // ekleme (add)
        T Peek();  // en son elemanı gösterir
        T Pop();  // yıgından cıkartma
    }

    public enum StackType
    {
        Array = 0,          // List<T>
        LinkedList = 1      // SinglyLinkedList<T>
    }
}
