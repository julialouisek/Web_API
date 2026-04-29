using System.Text.Json.Serialization;

namespace Web_API.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]

        public ICollection<Link> Links { get; set; } = new List<Link>();
        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
