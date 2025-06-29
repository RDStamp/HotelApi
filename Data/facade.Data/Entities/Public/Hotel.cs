using facade.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace facade.Data.Entities.Public;

[Table("Hotels")]
public class Hotel : Entity
{
    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Postcode { get; set; } = null!;

    public string Tel_No { get; set; } = null!;

    public string Email { get; set; } = null!;

    public ICollection<Room> Rooms { get; set; } = [];

}