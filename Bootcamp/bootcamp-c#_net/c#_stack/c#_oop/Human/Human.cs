using System;
using System.Collections.Generic;

namespace Human 
{
    public class Human 
    {
        public string name;
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public double health { get; set; }
        public List<Samurai> samurais { get; set; } = new List<Samurai>();
        public Human(string _name) 
        {
            name = _name;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string _name, int _strength, int _intelligence, int _dexterity, double _health)
        {
            name = _name;
            strength = _strength;
            intelligence = _intelligence;
            dexterity = _dexterity;
            health = _health;
        }
        public void Attack(ref object _obj)
        {
            Human enemy = _obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("Attack Failed");
            }
            else
            {
                enemy.health -= 5 * (this.strength);
            }
        }
    }
}