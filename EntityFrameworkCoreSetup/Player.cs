namespace EntityFrameworkCoreSetup
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; } = "Player with no first name";
        public string? LastName { get; set; }
        public int Age { get; set; }

        public List<Toy> Toys { get; set; } = new List<Toy>();
    }
}