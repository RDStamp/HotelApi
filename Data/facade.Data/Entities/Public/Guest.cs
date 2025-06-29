using facade.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace facade.Data.Entities.Public;

[Table("Guests")]
public class Guest : Entity
{
    public required string FullName { get; set; } = null!;
    public required string Surname { get; set; } = null!;
    public string Tel_No { get; set; } = null!;
    public required string Email { get; set; } = null!;

    public List<BookingGuests> BookingGuests { get; } = [];
}