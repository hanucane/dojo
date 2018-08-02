using System;
using System.Collections.Generic;

namespace Human
{
    public class Spider : Enemy
    {
        public Spider(string _name) : base(_name)
        {
            this.health = 25;
        }
        public void Spin_Web(ref object _target)
        {
            Human enemy = _target as Human;
            Random rand = new Random();
            if (enemy == null)
            {
                Console.WriteLine("Spin Web Failed");
            }
            else
            {
                enemy.health -= rand.Next(3,7);
                enemy.dexterity -= rand.Next(0,1);
            }
        }
        public void Raise_Dead()
        {
            Zombie SpiderZombie = new Zombie("SpiderZombie");
        }
    }
}