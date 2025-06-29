namespace facade.Core.Models;

public class BookingDto
{
    public required DtoHotel Hotel { get; set; }

    public required DtoRoom Room { get; set; }

    public required DateTime Start { get; set; }
    
    public required DateTime End { get; set; }

    public required Guid RefId { get; set; }

    public List<DtoGuest> Guests { get; set; } = new List<DtoGuest>();
}

public class DtoHotel
{
    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Postcode { get; set; } = null!;

    public string Tel_No { get; set; } = null!;

    public string Email { get; set; } = null!;
}

public class DtoRoom
{
    public required int Number { get; set; }

    public required int Capacity { get; set; }

    public required string Name { get; set; } = null!;

    public string Detail { get; set; } = null!;

}

public class DtoGuest
{
    public required string FullName { get; set; } = null!;
    public required string Surname { get; set; } = null!;
    public string Tel_No { get; set; } = null!;
    public required string Email { get; set; } = null!;

}
