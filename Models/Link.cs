using System.Globalization;
using System.Text.Json.Serialization;

namespace Web_API.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string URL { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int InterestId { get; set; }

        [JsonIgnore]
        public User User { get; set; } = null!;
        public Interest Interest { get; set; } = null!;
    }
}
