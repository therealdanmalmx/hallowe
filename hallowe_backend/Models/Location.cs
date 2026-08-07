using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace hallowe_backend.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        [MaxLength(35)]
        public required string Name { get; set; }
        [MaxLength(25)]
        public required string StreetName { get; set; }
        [MaxLength(10)]
        public required string StreetNumber { get; set; }
        [MaxLength(20)]
        public required string City { get; set; }
        [MaxLength(6)]
        public required string PostalCode { get; set; }
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public required bool TrickOrTreat { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public required string UserId { get; set; } = default!;
        [JsonIgnore]
        public User? User { get; set; } = default!;
    }
}