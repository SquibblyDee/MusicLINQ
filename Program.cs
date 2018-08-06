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
            Console.WriteLine("**********************BEGIN*********************");
            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            ////QUERY
            // IEnumerable<Artist> VernonArtist = from artist in Artists
                                        // where artist.Hometown == "Mount Vernon"
                                        // select artist;
            // foreach(Artist artist in VernonArtist)
            // {
                // Console.WriteLine("Artists's Name: " + artist.RealName + " - Artist's Age: " + artist.Age + "\n");
            // }
            
            ////METHOD
            IEnumerable<Artist> VernonArtist = Artists.Where(artist => artist.Hometown == "Mount Vernon");
            foreach(Artist artist in VernonArtist)
            {
                Console.WriteLine("Artists's Name: " + artist.RealName + " - Artist's Age: " + artist.Age + "\n");
            }

            //Who is the youngest artist in our collection of artists?
            ////QUERY
            // IEnumerable<Artist> YoungestArtist = from artist in Artists
                                            // orderby artist.Age
                                            // select artist;
            // Artist ourArtist = YoungestArtist.FirstOrDefault();
            // Console.WriteLine("Youngest artist's age: " + ourArtist.Age + "\n");

            ////METHOD
            IEnumerable<Artist> YoungArtist = Artists.OrderBy(p => p.Age).Take(1);
            foreach(Artist artist in YoungArtist)
            {
                Console.WriteLine("Artists's Name: " + artist.RealName + " - Artist's Age: " + artist.Age + "\n");
            }

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> WilliamArtists = from artist in Artists
                                        // where artist.RealName == "William"
                                        select artist;
            Console.WriteLine("Artists whose name contains William:");
            foreach(Artist artist in WilliamArtists)
            {
                if(artist.RealName.Contains("William"))
                {
                    Console.WriteLine("Artists's Name: " + artist.RealName + "\n");
                }
            }
            //Display the 3 oldest artist from Atlanta
            

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

	        // Console.WriteLine(Groups.Count);
            // Console.WriteLine(Artists.Count);
        }
    }
}
