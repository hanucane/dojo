using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Console.WriteLine("All artists from Mount Vernon");
            IEnumerable<Artist> VernonArtist = Artists.Where(artist => artist.Hometown == "Mount Vernon");
            foreach(Artist artist in VernonArtist)
            {
                Console.WriteLine("Artists's Name: " + artist.RealName + " - Artist's Age: " + artist.Age + "\n");
            }

            //Who is the youngest artist in our collection of artists?
            Console.WriteLine("Youngest artist in collection");
            IEnumerable<Artist> Youngest = Artists.OrderBy(x => x.Age).Take(1);
            foreach(Artist artist in Youngest)
            {
                Console.WriteLine("Artists's Name: " + artist.RealName + " - Artist's Age: " + artist.Age + "\n");
            }
            //Display all artists with 'William' somewhere in their real name
            Console.WriteLine("All artists with 'William'");
            IEnumerable<Artist> Williams = Artists.Where(x => x.RealName.Contains("William"));
            foreach(Artist william in Williams)
            {
                Console.WriteLine("Artists's Name: " + william.RealName + " - Artist's Age: " + william.Age + "\n");
            }

            //Display the 3 oldest artist from Atlanta
            Console.WriteLine("Atlanta's oldest artist in collection");
            IEnumerable<Artist> Atlanta = Artists.OrderByDescending(x => x.Age).Take(3);
            foreach(Artist artist in Atlanta)
            {
                Console.WriteLine("Artists's Name: " + artist.RealName + " - Artist's Age: " + artist.Age + "\n");
            }

            // Groups with less than 8 characters
            Console.WriteLine("Groups with names of less than 8 Characters");
            IEnumerable<Group> ShortGroups = Groups.Where(p => p.GroupName.Length < 8);
            foreach(Group group in ShortGroups)
            {
                Console.WriteLine("Group's Name: " + group.GroupName + "\n");
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            // Console.WriteLine("Groups with members not from NYC");

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            // Console.WriteLine("Display the artists in Wu-Tang Clan");
            // IEnumerable<Group> WuTang = Groups.Where(x => x.GroupName.Contains("Wu-Tang Clan")).Join(Artist);
        }
    }
}
