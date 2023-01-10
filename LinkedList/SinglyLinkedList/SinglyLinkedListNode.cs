using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode<T> Next { get; set; }
        public T Value { get; set; } // dugun ıcınde hangi type varsa

        public SinglyLinkedListNode(T value) // yapılandırıcı method
        {
            Value = value;
        }

        public override string ToString() => $"{Value}";  // dugum ıcınde var olan deger dönecek
        
    }
}
