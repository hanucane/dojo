using System;
using System.Collections.Generic;

namespace Human 
{
    public class Samurai : Human
    {
        public Samurai(string _name) : base(_name)
        {
            this.health = 200;
        }
        public void Death_Blow(ref object _target)
        {
            Human enemy = _target as Human;
            if (enemy.health <= 50)
            {
                enemy.health = 0;
            }
            else
            {
                Console.WriteLine("Death Blow missed.");
            }
        }
        public void Meditate()
        {
            this.health = 200;
        }
        // public static int How_Many(List<Samurai> samurais, string _name)
        // {
        //     samurais.Add(new Samurai(_name));
        //     Console.WriteLine(samurais.Count);
        //     return samurais.Count;
        // }
    }
}
