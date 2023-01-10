using System;
using System.Collections.Generic;

namespace DataStructures.Heap
{
    public class MinHeap<T> : BHeap<T>, IEnumerable<T>
        where T : IComparable
    {
        public MinHeap() : base()
        {

        }

        public MinHeap(int _size) : base(_size)
        {

        }

        public MinHeap(IEnumerable<T> collection) : base(collection)
        {

        }

        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index)) // sol cucugu var ise
            {
                var smallerIndex = GetLeftChildIndex(index); //kucuk index
                if (HasRightChild(index) && 
                    GetRightChild(index).CompareTo(GetLeftChild(index))<0)  //daha kucuk cocugu alabilmek ıcın karsılastırıyoruz.
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (Array[smallerIndex].CompareTo(Array[index])>=0) //0 dan büyük veya esitse kır.
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
        protected override void HeapifyUp()
        {
            var index = position - 1;
            while (!IsRoot(index) &&
                Array[index].CompareTo(GetParent(index))<0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }
}
