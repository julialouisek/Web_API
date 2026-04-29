namespace Web_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        //public Interest Interest { get; set; } = null!;
        public ICollection<Link> Links { get; set; } = new List<Link>();
        public ICollection<Interest> Interests { get; set; } = new List<Interest>();
    }
}
