using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.SortingAlgorithms
{
    public class SelectionSort
    {
        public static void Sort<T>(T[] array)
            where T:IComparable // karşılaştırmak için
        {
            for (int i = 0; i < array.Length-1; i++)  // ilk elemandan dizinin son elemanına
            {
                int minIndex = i;   // ilk 0 olacak
                T minValue = array[i];  // min değeri tutacak
                for (int j = i+1; j < array.Length; j++)  // bir sonraki elemanı ifade edecek
                {
                    if (array[j].CompareTo(minValue)<0) // jnin ifadesiyla o anki değer karşılaştırması j< o ankinden -1 gelecek, büyükse +1 
                    {
                        minIndex = j;    // j yi min yap
                        minValue = array[minIndex];  // dizi üzerinden 
                    }
                }
                Sorting.Swap<T>(array, i, minIndex);  // takas yap
            }
        }
        public static void Sort<T>(T[] array, 
            Shared.SortDirection sortDirection = Shared.SortDirection.Asceding)
            where T:IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[j], array[i]) >= 0) // 0dan büyük ve eşitse kucukluk yoksa
                        continue;

                    Sorting.Swap<T>(array, i, j); // aksi durumda swap yap.
                }
            }
        }
    }
}
