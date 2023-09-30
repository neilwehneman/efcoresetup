namespace EntityFrameworkCoreSetup
{
    public class Toy
    {
        public int ToyId { get; set; }
        public Manufacturer Manufacturer { get; set; } = new Manufacturer();
        public string Name { get; set; } = "Toy with no name";
        public string Description { get; set; } = "Toy with no description";
        public int PriceInWholeDollars { get; set; }

        public List<Player> Players { get; set; }  = new List<Player>();
    }
}