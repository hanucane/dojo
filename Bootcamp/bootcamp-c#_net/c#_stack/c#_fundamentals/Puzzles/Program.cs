using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Names();
        }
        public static List<int> RandomArray()
        {
            List<int> values = new List<int>();
            Random rand = new Random();
            int i = 1;
            while (i<=10){
                values.Add(rand.Next(5,25));
                i += 1;
            }
            int max = values[0];
            int min = values[0];
            float sum = 0;
            for (int x=1; x<values.Count; x++){
                if (values[x] > max){
                    max = values[x];
                }
                else if (values[x] < min){
                    min = values[x];
                }
                sum += values[x];
            }
            Console.WriteLine("Max: "+max+" Min: "+min+" Sum: "+sum);
            return values;
        } 
        public static string CoinFlip()
        {
            Random rand = new Random();
            string flip = "";
            int toss = rand.Next(2);
            if (toss == 1){
                flip = "Heads";
            }
            else {
                flip = "Tails";
            }
            Console.WriteLine(flip);
            return flip;
        }
        public static List<string> Names()
        {
            string[] arr = {"Todd","Tiffany","Charlie","Geneva","Sydney"};
            for (int i = 0; i < arr.Length/2; i++){
                string temp = arr[i];
                arr[i] = arr[arr.Length-(i+1)];
                arr[arr.Length-(i+1)] = temp;
            }
            List<string> arrnew = new List<string>();
            for (int i = 0; i < arr.Length; i++){
                if (arr[i].Length > 5){
                    arrnew.Add(arr[i]);
                }
            }
            foreach (string x in arrnew){
                Console.WriteLine(x);
            }
            return arrnew;
        }
    }
}
