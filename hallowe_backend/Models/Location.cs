using System.Text.Json.Serialization;
namespace hallowe_backend.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public required string StreetName { get; set; } = string.Empty;
        public required string StreetNumber { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;
        public required string PostalCode { get; set; } = string.Empty;
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }        
        public required string UserId { get; set; } = default!;
        [JsonIgnore]
        public User? User { get; set; } = default!;
        public string Name
        {
            get => User?.Name ?? string.Empty;
            private set {}
        }
    }
}