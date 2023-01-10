using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Set
{
    public class DisjointSetNode<T>
    {
        public T Value { get; set; } // deger
        public int Rank { get; set; }  // rank
        public DisjointSetNode<T> Parent { get; set; }  // ebeveyn
        public DisjointSetNode()   
        {

        }
        public DisjointSetNode(T value) //
        {
            Value = value;
            Rank = 0;
        }
        public DisjointSetNode(T value, int rank)  // deger ve rank alan constructor 
        {
            Value = value;
            Rank = rank;
        }
        public override string ToString()  // ekrana yazdırmak için
        {
            return $"{Value}";
        }
    }
}
