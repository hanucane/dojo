using System;

namespace Human 
{
    public class Ninja : Human
    {
        public Ninja(string _name) : base(_name)
        {
            this.dexterity = 175;
        }
        public void Steal(ref object _obj)
        {
            Human enemy = _obj as Human;
            if (enemy == null)
            {
                Console.WriteLine("Attack Failed");
            }
            else
            {
                enemy.health -= 5 * (this.strength);
                this.health += 10;
            }
        } 
        public void Get_Away()
        {
            this.health -= 15;
        }
    }
}