using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestIsolationLevel
{
    public class TestLeftJoin
    {
        record class Person(string FirstName, string LastName);
        record class Pet(string Name, Person Owner);

        public static void Example()
        {
            Person magnus = new("Magnus", "Hedlund");
            Person terry = new("Terry", "Adams");
            Person charlotte = new("Charlotte", "Weiss");
            Person arlene = new("Arlene", "Huff");

            Pet barley = new("Barley", terry);
            Pet boots = new("Boots", terry);
            Pet whiskers = new("Whiskers", charlotte);
            Pet bluemoon = new("Blue Moon", terry);
            Pet daisy = new("Daisy", magnus);

            // Create two lists.
            List<Person> people = new() { magnus, terry, charlotte, arlene };
            List<Pet> pets = new() { barley, boots, whiskers, bluemoon, daisy };

            var query =
                from person in people
                join pet in pets on person equals pet.Owner into gj
                from subpet in gj.DefaultIfEmpty()
                select new
                {
                    person.FirstName,
                    PetName = subpet?.Name ?? string.Empty
                };

            foreach (var v in query)
            {
                Console.WriteLine($"{v.FirstName + ":",-15}{v.PetName}");
            }


            // This code produces the following output:
            //
            // Magnus:        Daisy
            // Terry:         Barley
            // Terry:         Boots
            // Terry:         Blue Moon
            // Charlotte:     Whiskers
            // Arlene:
        }
    }
}
