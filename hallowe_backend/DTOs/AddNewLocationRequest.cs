using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using hallowe_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace hallowe_backend.DTOs;

public class AddNewLocationRequest
{
    [MaxLength(35)]
    public required string Name { get; set; }
    [MaxLength(25)]
    public required string StreetName { get; set; }
    [MaxLength(10)]
    public required string StreetNumber { get; set; }
    [MaxLength(20)]
    public required string City { get; set; }
    [MaxLength(6)]
    [RegularExpression(@"^\d{3} ?\d{2}$", ErrorMessage = "Postnummer måste ha 5 siffror. Separera dem med ett mellanslag (nnn nn")]
    public required string PostalCode { get; set; }
    [Precision(9, 6)]
    public required decimal Latitude { get; set; }
    [Precision(9, 6)]
    public required decimal Longitude { get; set; }
    public required bool TrickOrTreat { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }        
}