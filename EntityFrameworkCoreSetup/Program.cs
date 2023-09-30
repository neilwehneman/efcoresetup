using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreSetup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using PlaytimeContext context = new PlaytimeContext();

            // We want to drop the data in the database each run because we will be repeatedly
            // adding the same data to it due to the teaching nature of the exercise.
            // We drop individual tables rather than the whole database to preserve the Migrations table.
            // The PlayerToy table is dropped automatically when the Players and Toys tables are dropped.
            context.Players.ExecuteDelete();
            context.Manufacturers.ExecuteDelete();
            context.Toys.ExecuteDelete();

            SeedTheDatabase();

            // Add in the toys Neil plays with.
            Player neil = context.Players.Where(player => player.FirstName == "Neil").Single();

            List<Toy> aresCatalog = context.Toys.Where(toy => toy.Manufacturer.Name == "Ares Games").ToList();
            neil.Toys.AddRange(aresCatalog);

            Toy middleearthQuest = context.Toys.Where(toy => toy.Name == "Middle-earth Quest").Single();
            neil.Toys.Add(middleearthQuest);

            Toy tug = context.Toys.Where(toy => toy.Name.Contains("Tug")).Single();
            neil.Toys.Add(tug);

            // Add in the toys Lauren plays with.
            Player lauren = context.Players.Where(player => player.FirstName == "Lauren").Single();

            List<Toy> duraDogToys = context.Toys.Where(toy => toy.Manufacturer.Name == "DuraDog").ToList();
            lauren.Toys.AddRange(duraDogToys);

            List<Toy> kongToys = context.Toys.Where(toy => toy.Manufacturer.Name == "Kong").ToList();
            lauren.Toys.AddRange(kongToys);

            Toy warOfTheRing = context.Toys.Where(toy => toy.Name == "War of the Ring").Single();
            lauren.Toys.Add(warOfTheRing);

            // Add in the toys Stella plays with.
            Player stella = context.Players.Where(player => player.FirstName == "Stella").Single();

            stella.Toys.AddRange(duraDogToys);
            stella.Toys.AddRange(kongToys);

            // Add in the toys Samwise plays with.
            // Samwise does not actually play with any toys :-(, but he's a named character in War of the Ring!
            Player samwise = context.Players.Where(player => player.FirstName == "Samwise").Single();

            samwise.Toys.Add(warOfTheRing);

            // We can remove this line to show the difference between in-memory and in-database data.
            context.SaveChanges();

            // Do a little bit of database analysis.
            int numberOfPlayersForMostPopularToy = context.Toys.Max(toy => toy.Players.Count);

            // We could have a tie for most popular toy, so create a list for most popular toy.
            List<Toy> mostPopularToys = context.Toys.Where(toy => toy.Players.Count == numberOfPlayersForMostPopularToy).ToList();

            foreach (Toy toy in mostPopularToys)
            {
                Console.WriteLine("A most popular toy is " + toy.Name + ", played with by " + numberOfPlayersForMostPopularToy + " players");
            }    

            Console.ReadKey();
        }

        static void SeedTheDatabase()
        {
            using PlaytimeContext context = new PlaytimeContext();

            Player player1 = new Player
            {
                FirstName = "Neil",
                LastName = "Wehneman",
                Age = 42
            };
            
            Player player2 = new Player
            {
                FirstName = "Lauren",
                LastName = "Dooley",
                Age = 39
            };
            
            Player player3 = new Player
            {
                FirstName = "Samwise",
                LastName = "Wehneman",
                Age = 12
            };

            Player player4 = new Player
            {
                FirstName = "Stella",
                LastName = "Dooley",
                Age = 2
            };

            context.Players.Add(player1);
            context.Players.Add(player2);
            context.Players.Add(player3);
            context.Players.Add(player4);

            Manufacturer manufacturer1 = new Manufacturer
            {
                Name = "Ares Games",
                Country = "Italy"
            };

            Manufacturer manufacturer2 = new Manufacturer
            {
                Name = "Fantasy Flight Games",
                Country = "United States"
            };

            Manufacturer manufacturer3 = new Manufacturer
            {
                Name = "Kong",
                Country = "United States"
            };

            Manufacturer manufacturer4 = new Manufacturer
            {
                Name = "DuraDog",
                Country = "Canada"
            };

            context.Manufacturers.Add(manufacturer1);
            context.Manufacturers.Add(manufacturer2);
            context.Manufacturers.Add(manufacturer3);
            context.Manufacturers.Add(manufacturer4);

            Toy toy1 = new Toy
            {
                Manufacturer = manufacturer1,
                Name = "War of the Ring",
                Description = "An epic retelling of The Lord of the Rings in board game form",
                PriceInWholeDollars = 90
            };

            Toy toy2 = new Toy
            {
                Manufacturer = manufacturer1,
                Name = "The Battle of Five Armies",
                Description = "A thrilling recreation of the final battle from The Hobbit",
                PriceInWholeDollars = 86
            };

            Toy toy3 = new Toy
            {
                Manufacturer = manufacturer2,
                Name = "Middle-earth Quest",
                Description = "An adventure game set between The Hobbit and the Lord of the Rings",
                PriceInWholeDollars = 449
            };

            Toy toy4 = new Toy
            {
                Manufacturer = manufacturer3,
                Name = "Kong Wubba",
                Description = "A squeaky toy for dogs",
                PriceInWholeDollars = 10
            };

            Toy toy5 = new Toy
            {
                Manufacturer = manufacturer4,
                Name = "DuraDog Ball",
                Description = "A durable ball for dogs",
                PriceInWholeDollars = 5
            };

            Toy toy6 = new Toy
            {
                Manufacturer = manufacturer4,
                Name = "DuraDog Tug",
                Description = "A rope toy for dogs",
                PriceInWholeDollars = 12
            };

            context.Toys.Add(toy1);
            context.Toys.Add(toy2);
            context.Toys.Add(toy3);
            context.Toys.Add(toy4);
            context.Toys.Add(toy5);        
            context.Toys.Add(toy6);

            context.SaveChanges();
        }
    }
}