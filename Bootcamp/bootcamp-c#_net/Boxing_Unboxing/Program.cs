using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Box();
        }
        public static void Box(){
            List<object> boxes = new List<object>();
            boxes.Add(7);
            boxes.Add(28);
            boxes.Add(-1);
            boxes.Add(true);
            boxes.Add("chair");
            int sum = 0;
            foreach (object box in boxes){
                if (box is int){
                    sum += (int)box;
                }
                if (box is string){
                    Console.WriteLine(box);
                }
                if (box is bool){
                    Console.WriteLine(box);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
