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
            Console.WriteLine("All artists from Mount Vernon");
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
            Console.WriteLine("The Youngest Artist");
            IEnumerable<Artist> YoungArtist = Artists.OrderBy(p => p.Age).Take(1);
            foreach(Artist artist in YoungArtist)
            {
                Console.WriteLine("Artists's Name: " + artist.RealName + " - Artist's Age: " + artist.Age + "\n");
            }

            //Display all artists with 'William' somewhere in their real name
            ////QUERY
            // IEnumerable<Artist> WilliamArtists = from artist in Artists
                                        // where artist.RealName == "William"
                                        // select artist;
            // Console.WriteLine("Artists whose name contains William:");
            // foreach(Artist artist in WilliamArtists)
            // {
                // if(artist.RealName.Contains("William"))
                // {
                    // Console.WriteLine("Artists's Name: " + artist.RealName + "\n");
                // }
            // }

            ////METHOD
            Console.WriteLine("All artists named William");
            IEnumerable<Artist> WilliamArtists = Artists.Where(p => p.RealName.Contains("William"));
            foreach(Artist artist in WilliamArtists)
            {
                Console.WriteLine("Artists's Name: " + artist.RealName + "\n");
            }

            //Display the 3 oldest artist from Atlanta
            ////METHOD
            Console.WriteLine("Oldest 3x artists from Atl");
            IEnumerable<Artist> OldAtlArtists = Artists.Where(p => p.Hometown == "Atlanta").OrderByDescending(p => p.Age).Take(3);
            foreach(Artist artist in OldAtlArtists)
            {
                Console.WriteLine("Artists's Name: " + artist.RealName + " - Artist's Hometown: " + artist.Hometown + " - Artist's Age: " + artist.Age + "\n");
            }

            //Display all groups with names less than 8 characters in length
            Console.WriteLine("Groups with names of less than 8 Characters");
            IEnumerable<Group> ShortGroups = Groups.Where(p => p.GroupName.Length < 8);
            foreach(Group group in ShortGroups)
            {
                Console.WriteLine("Group's Name: " + group.GroupName + "\n");
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

	        // Console.WriteLine(Groups.Count);
            // Console.WriteLine(Artists.Count);
        }
    }
}
