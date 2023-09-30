namespace EntityFrameworkCoreSetup
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; } = "Manufacturer with no name";
        public string? Country { get; set; }

        public List<Toy> Toys { get; set; } = new List<Toy>();
    }
}