using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Heap
{
    public abstract class BHeap<T> : IEnumerable<T>
        where T:IComparable
    {
        public T[] Array { get; private set; }
        protected int position; // pozisyon
        public int Count { get; private set; } // eleman sayısı
        public BHeap() 
        {
            Count = 0;
            Array = new T[128];   // 128 elemanlı statik dizi
            position = 0;
        }
        public BHeap(int _size) // dizinin boyutu dışarıdan gelecek.
        {
            Count = 0;
            Array = new T[_size];
            position = 0;
        }
        public BHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.ToArray().Length];
            position = 0;
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        protected int GetLeftChildIndex(int i) => 2 * i + 1; // son cocugun index değeri
        protected int GetRightChildIndex(int i) => 2 * i + 2; // son sağ cocugun 
        protected int GetParentIndex(int i) => (i-1)/2;   // ebeveyn
        protected bool HasLeftChild(int i) =>  // sol cocugu var mı true yada false 
            GetLeftChildIndex(i) < position;
        protected bool HasRightChild(int i) =>  // sağ cocugu var mı true yada false 
            GetRightChildIndex(i) < position;
        protected bool IsRoot(int i) => i == 0; // kök müdür
        protected T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        protected T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        protected T GetParent(int i) => Array[GetParentIndex(i)];
        public bool IsEmpty() => position == 0;  // boş mu

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Empty heap!");
            return Array[0];
        }
        
        public void Swap(int first, int second)   // takas islemi
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }
        public void Add(T value)   // ekleme islemi
        {
            if (position==Array.Length)
                throw new IndexOutOfRangeException("Overflow!");
            Array[position] = value;
            position++;
            Count++;
            HeapifyUp();
        }
        public T DeleteMinMax()   // silme islemi ( her zaman kökden siler )
        {
            if (position == 0)
                throw new IndexOutOfRangeException("Taima var");
            var temp = Array[0];
            Array[0] = Array[position - 1];
            position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        protected abstract void HeapifyUp(); // soyut 
        protected abstract void HeapifyDown();

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
