using System;
using System.Collections.Generic;

namespace Basic_XIII
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] arr = {1,-3,4,-6,8,10};
            NumberToString(arr);
        }

        public static void Print1to255()
        {
            int i = 1;
            while (i<=255){
                Console.WriteLine(i);
                i += 1;
            }
        }
        public static void PrintOdd1to255()
        {
            int i = 1;
            while (i<=255){
                if (i%2!=0){
                    Console.WriteLine(i);
                }
                i += 1;
            }
        }
        public static void PrintSum0to255()
        {
            int i = 0;
            double sum = 0;
            while (i<=255){
                sum += i;
                Console.WriteLine("New Number: "+i+" Sum: "+sum);
                i += 1;
            }
        }
        public static void IterateArray(int[] arr)
        {
            foreach (object x in arr){
                Console.WriteLine(x);
            }
        }
        public static void Max(int[] arr)
        {
            int max = arr[0];
            foreach (int x in arr){
                if (x > max){
                    max = x;
                }
            }
            Console.WriteLine(max);
        }
        public static void Average(int[] arr)
        {
            float sum = 0;
            for (int i=0; i<arr.Length; i++){
                sum += arr[i];
            }
            float avg = sum/arr.Length;
            Console.WriteLine(avg);
        }
        public static void ArrayOdd()
        {
            List<int> odd = new List<int>();
            int i = 1;
            while (i<=255){
                if (i%2!=0){
                    odd.Add(i);
                }
                i += 1;
            }
            for (int x = 0; x < odd.Count; x++){
                Console.WriteLine(odd[x]);
            }
        }
        public static void GreaterThanY(int[] arr, int y)
        {
            int total = 0;
            for (int i = 0; i < arr.Length; i++){
                if (arr[i] > y){
                    total += 1;
                }
            }
            Console.WriteLine(total);
        }
        public static void SquareValues(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++){
                arr[i] *= arr[i];
            }
            foreach (int x in arr){
                Console.WriteLine(x);
            }
        }
        public static void EliminateNegatives(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++){
                if (arr[i] < 0){
                    arr[i] = 0;
                }
            }
            foreach (int x in arr){
                Console.WriteLine(x);
            }
        }
        public static void MaxMinAvg(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];
            float sum = 0;
            for (int x=1; x<arr.Length; x++){
                if (arr[x] > max){
                    max = arr[x];
                }
                else if (arr[x] < min){
                    min = arr[x];
                }
                sum += arr[x];
            }
            float avg = sum / arr.Length;
            Console.WriteLine("Max: "+max+" Min: "+min+" Average: "+avg);
        }
        public static void ShiftValues(int[] arr)
        {
            for (int i=0; i<arr.Length; i++){
                if (i == arr.Length-1){
                    arr[i] = 0;
                }
                else {
                    arr[i] = arr[i+1];
                }
            }
            foreach (int x in arr){
                Console.WriteLine(x);
            }
        }
        public static void NumberToString(object[] arr)
        {
            for (int i=0; i<arr.Length; i++){
                if ((int)arr[i] < 0){
                    arr[i] = "Dojo";
                }
                Console.WriteLine(arr[i]);
            }
        }
    }
}
