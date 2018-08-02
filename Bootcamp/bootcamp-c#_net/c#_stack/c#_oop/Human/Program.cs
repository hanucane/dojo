using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ally Party Creation
            Human Morty = new Human("Morty", 15, 17, 14, 275);
            object _morty = Morty;
            Human Rick = new Human("Rick");
            object _rick = Rick;
            Wizard Wizard = new Wizard("Wizard Rick");
            object _wizard = Wizard;
            Ninja Ninja = new Ninja("Ninja Rick");
            object _ninja = Ninja;
            Samurai Samurai = new Samurai("Samurai Rick");
            object _samurai = Samurai;
            Console.WriteLine("Welcome to Rick Before Morty");
            Console.WriteLine("Please enter your character name:");
            string _name = Console.ReadLine();
            Console.WriteLine("Hi "+_name+"! Please enter a character type (Wizard, Ninja or Samurai):");
            string _type = Console.ReadLine();
            if (_type == "Wizard"){
                Wizard player = new Wizard(_name);
                object _player = player;
                Console.WriteLine(player.name);
                Console.WriteLine("Strength: "+player.strength);
                Console.WriteLine("Intelligence: "+player.intelligence);
                Console.WriteLine("Dexterity: "+player.dexterity);
                Console.WriteLine("Health: "+player.health);
                object[] ally_party = {_rick,_wizard,_samurai,_ninja,_player};
            }
            else if (_type == "Ninja"){
                Ninja player = new Ninja(_name);
                object _player = player;
                Console.WriteLine(player.name);
                Console.WriteLine("Strength: "+player.strength);
                Console.WriteLine("Intelligence: "+player.intelligence);
                Console.WriteLine("Dexterity: "+player.dexterity);
                Console.WriteLine("Health: "+player.health);
                object[] ally_party = {_rick,_wizard,_samurai,_ninja,_player};
            }
            else if (_type == "Samurai"){
                Samurai player = new Samurai(_name);
                object _player = player;
                Console.WriteLine(player.name);
                Console.WriteLine("Strength: "+player.strength);
                Console.WriteLine("Intelligence: "+player.intelligence);
                Console.WriteLine("Dexterity: "+player.dexterity);
                Console.WriteLine("Health: "+player.health);
                object[] ally_party = {_rick,_wizard,_samurai,_ninja,_player};
            }
            else {
                Human player = new Human(_name);
                object _player = player;
                Console.WriteLine(player.name);
                Console.WriteLine("Strength: "+player.strength);
                Console.WriteLine("Intelligence: "+player.intelligence);
                Console.WriteLine("Dexterity: "+player.dexterity);
                Console.WriteLine("Health: "+player.health);
                object[] ally_party = {_rick,_wizard,_samurai,_ninja,_player};
            }
            // End of character creation
            
            Console.WriteLine("Welcome "+_type+" "+_name+", you are welcomed into a new party with: "+Rick.name+", "+Wizard.name+", "+Ninja.name+", and "+Samurai.name+".");
            Console.WriteLine("You join up the party and begin to walk through the park.");
            Console.WriteLine("You come across a giant spider and two zombies.");
            Spider spider = new Spider("Shelob");
            object _spider = spider;
            Zombie zomb1 = new Zombie("Zombie1");
            object _zomb1 = zomb1;
            Zombie zomb2 = new Zombie("Zombie2");
            object _zomb2 = zomb2;
            object[] enemy_party = {_spider,_zomb1,_zomb2};


            // Console.WriteLine(Rick.name);
            // Console.WriteLine("Strength: "+Rick.strength);
            // Console.WriteLine("Intelligence: "+Rick.intelligence);
            // Console.WriteLine("Dexterity: "+Rick.dexterity);
            // Console.WriteLine("Health: "+Rick.health);      
            // Rick.Attack(ref _morty);
            // Console.WriteLine("Rick attacked Morty! Morty's health: "+Morty.health);
            // Wizard.Fireball(ref _rick);
            // Console.WriteLine("Wizard Rick fireballed Rick! Rick's health: "+Rick.health);
            // Rick.Attack(ref _wizard);
            // Console.WriteLine("Rick attacked Wizard Rick! Wizard Rick's health: "+Wizard.health);
            // Wizard.Heal();
            // Console.WriteLine("Wizard Rick healed himself. Wizard Rick's health: "+Wizard.health);
            // Ninja.Steal(ref _wizard);
            // Console.WriteLine("Ninja Rick stole from Wizard Rick! Wizard Rick's health: "+Wizard.health+"\n"+"Ninja Rick's health: "+Ninja.health);
            // Ninja.Get_Away();
            // Console.WriteLine("Ninja Rick cleverly escapes from the enemy. Ninja Rick's health: "+Ninja.health);
            // Samurai.Death_Blow(ref _rick);
            // Wizard.Fireball(ref _rick);
            // Console.WriteLine("Wizard Rick fireballed Rick! Rick's health: "+Rick.health);
            // Samurai.Death_Blow(ref _rick);
            // Console.WriteLine("Samurai Rick dealt a death blow to Rick! Rick's health: "+Rick.health);
            // Wizard.Fireball(ref _samurai);
            // Console.WriteLine("Wizard Rick fireballed Samurai Rick! Samurai Rick's health: "+Samurai.health);
            // Samurai.Meditate();
            // Console.WriteLine("Samurai Rick meditates deeply. Samurai Rick's health: "+Samurai.health);
        }
    }
}
