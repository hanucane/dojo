using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Randomness();
        }
        public static void NumLoop()
        {
            int i=1;
            while (i<=255){
                Console.WriteLine(i);
                i += 1;
            }
        }
        public static void Divisible()
        {
            int i=1;
            while (i<=100){
                if (i%3 == 0 || i%5 == 0){
                    if(i%3 == 0 && i%5 == 0){}
                    else {
                        Console.WriteLine(i);
                    }
                }
                i+=1;
            }
        }
        public static void DivisibleStr()
        {
            int i=1;
            while (i<=100){
                if (i%3 == 0 || i%5 == 0){
                    if(i%3 == 0 && i%5 == 0){
                        Console.WriteLine("FizzBuzz");
                    }
                    else if(i%3 == 0) {
                        Console.WriteLine("Fizz");
                    }
                    else if(i%5 == 0) {
                        Console.WriteLine("Buzz");
                    }
                }
                i+=1;
            }
        }
        public static void Randomness()
        {
            for(int val = 0; val < 10; val++)
            {
                Random rand  = new Random();
                int random = rand.Next(1,20);
                if (random%3 == 0 || random%5 == 0){
                    if(random%3 == 0 && random%5 == 0){
                        Console.WriteLine("FizzBuzz");
                    }
                    else if(random%3 == 0) {
                        Console.WriteLine("Fizz");
                    }
                    else if(random%5 == 0) {
                        Console.WriteLine("Buzz");
                    }
                }
            }
        }
    }
}
