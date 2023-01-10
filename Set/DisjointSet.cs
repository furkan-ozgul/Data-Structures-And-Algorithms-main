using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Set
{
    public class DisjointSet<T> : IEnumerable<T>
    {
        private Dictionary<T, DisjointSetNode<T>> set // anahtar değere bağlı  düğüm set
            = new Dictionary<T, DisjointSetNode<T>>();

        public DisjointSet()
        {

        }

        public DisjointSet(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                MakeSet(item);  // 
        }

        public int Count { get; private set; } // kaç tane elamanımız var 

        public void MakeSet(T value)  //
        {
            if (set.ContainsKey(value))  // gelecek değer varsa
                throw new Exception("Değer zaten tanımlanmış.");

            var newSet = new DisjointSetNode<T>(value, 0);  //dugum tasarlıyoruz defaul 0
            newSet.Parent = newSet;  // parent kendisi olacak root old için
            set.Add(value, newSet);  // ekle
            Count++;  // count 1 arttır.
        }

        public T FindSet(T value)  // arama
        {
            if (!set.ContainsKey(value))
                throw new Exception("Değer bu sette değil");
            return findSet(set[value]).Value;
        }

        private DisjointSetNode<T> findSet(DisjointSetNode<T> node)
        {
            var parent = node.Parent;
            if (node!=parent)
            {
                node.Parent = findSet(node.Parent);
                return node.Parent;
            }
            return parent;
        }

        public void Union(T valueA, T valueB)  // 2 değer alıyor birleştirmek için.
        {
            if (valueA == null || valueB == null)
                throw new ArgumentNullException();
            
            var rootA = FindSet(valueA);
            var rootB = FindSet(valueB);

            if (rootA.Equals(rootB))  // a nın temsilcisi b ye esitse kapat
                return;

            var nodeA = set[rootA];  // a yı al
            var nodeB = set[rootB];  // b yi al

            if (nodeA.Rank == nodeB.Rank)  // eşit olma durumu
            {
                nodeB.Parent = nodeA;  // b yi al
                nodeA.Rank++;   // a yı arttır
            }
            else
            {
                if (nodeA.Rank < nodeB.Rank)  // a kucukse b ye // ayı al b ye ekle
                {
                    nodeA.Parent = nodeB;
                }
                else
                {
                    nodeB.Parent = nodeA;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.Values.Select(x => x.Value).GetEnumerator(); // set üzerindeki değerlere bakıcaz. örnek versin
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
