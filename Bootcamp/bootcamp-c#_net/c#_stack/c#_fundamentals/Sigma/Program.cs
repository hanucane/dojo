using System;

namespace Sigma
{
    class Program
    {
        static void Main(string[] args)
        {   
            object[] arr = {-1,2,-3,4,5};
            Dojo(arr);
        }
        public static int Sigma(int num)
        {
            int sigma = 0;
            for (int i = 0; i <= num; i++)
            {
                sigma += i;
            }
            return sigma;
        }
        public static void Average(int[] array)
        {
            int ave = 0;
            for (int i = 0; i < array.Length; i++)
            {
                ave += array[i];
            }
            double average = ave / array.Length;
            Console.WriteLine(average);
        }
        public static object[] Dojo(object[] arr){
            for(int i=0; i<arr.Length; i++){
                if((int)arr[i]<0){
                    arr[i]="Dojo";
                }
                Console.WriteLine(arr[i]);
            }
            return arr;
        }
    }
}
