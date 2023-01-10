using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.SortingAlgorithms
{
    public class Sorting  // sıralama
    {
        public static void Swap<T>(T[] array, int first, int second)  // yer değiştme yapıcaz
        {
            var temp = array[first];  // ilk ifadesi
            array[first] = array[second];  // ikinci ile değiştirme
            array[second] = temp;  // ikinciyide tempe at, tamamen yer değiştirdi.
        }
    }
}
