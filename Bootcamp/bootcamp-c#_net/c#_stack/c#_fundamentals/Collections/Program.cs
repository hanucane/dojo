using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary();
        }
        public static void Arrays(){
            int[] int_arr = {0,1,2,3,4,5,6,7,8,9};
            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] true_false = {true, false, true, false, true, false, true, false, true, false};
        }
        public static void List(){
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Half-Baked");
            flavors.Add("Chocolate Chip Cookie Dough");
            flavors.Add("Mint Chocolate Chip");
            flavors.Add("Caramel Swirl");

            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);
        }
        public static void Dictionary(){
            Dictionary<string,string> profile = new Dictionary<string,string>();
            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            foreach (string name in names){
                profile.Add(name, null);
            } 
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Half-Baked");
            flavors.Add("Chocolate Chip Cookie Dough");
            flavors.Add("Mint Chocolate Chip");
            flavors.Add("Caramel Swirl");
            
            // Iterates through array placing array's key value name and redefining its value.
            Random rand = new Random();
            foreach (string name in names){
                profile[name] = flavors[rand.Next(flavors.Count)];
            }
            
            // Iterates through dictionary and prints the key and value.
            foreach (KeyValuePair<string,string> entry in profile){
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
