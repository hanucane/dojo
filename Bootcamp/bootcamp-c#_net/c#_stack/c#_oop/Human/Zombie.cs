using System;
using System.Collections.Generic;

namespace Human
{
    public class Zombie : Enemy
    {
        public Zombie(string _name) : base(_name)
        {
            this.health = 25;
        }
        public void Feast_Brains(ref object _target)
        {
            Human enemy = _target as Human;
            Random rand = new Random();
            if (enemy == null)
            {
                Console.WriteLine("Attack Failed");
            }
            else
            {
                enemy.health -= rand.Next(10,21);
            }
        }
    }
}