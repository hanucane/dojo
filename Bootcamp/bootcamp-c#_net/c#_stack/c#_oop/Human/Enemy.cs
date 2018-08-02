using System;
using System.Collections.Generic;

namespace Human 
{
    public class Enemy
    {
        public string name;
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public double health { get; set; }

        public Enemy(string _name)
        {
            name = _name;
            strength = 2;
            intelligence = 2;
            dexterity = 2;
            health = 30;
        }
    }
}