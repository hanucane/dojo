using System;

namespace Human 
{
    public class Wizard : Human
    {
        public Wizard(string _name) : base(_name)
        {
            this.health = 50;
            this.intelligence = 25;
        }
        public void Heal()
        {
            double heal = this.intelligence * 10;
            double max_health = this.health;
            this.health += heal;
        }
        public void Fireball(ref object _target)
        {
            Human enemy = _target as Human;
            Random rand = new Random();
            if (enemy == null)
            {
                Console.WriteLine("Attack Failed");
            }
            else
            {
                enemy.health -= rand.Next(20,51);
            }
        }
    }
}