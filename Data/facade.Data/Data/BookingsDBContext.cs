using facade.Data.Entities.Public;
using facade.Data.Infrustructure;
using Microsoft.EntityFrameworkCore;

namespace facade.Data.Data;

public class BookingsDBContext : DbContext
{
    public BookingsDBContext(DbContextOptions<BookingsDBContext> options) : base(options) { }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<Guest> Guests { get; set; }

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<BookingGuests> BookingGuests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<RoomType>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Room>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Guest>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Booking>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<BookingGuests>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Hotel>()
            .HasMany(e => e.Rooms)
            .WithOne(e => e.Hotel)
            .HasForeignKey(e => e.HotelId)
            .IsRequired();

        modelBuilder.Entity<RoomType>()
            .HasMany(e => e.Rooms)
            .WithOne(e => e.RoomType)
            .HasForeignKey(e => e.RoomTypeId)
            .IsRequired();

        modelBuilder.Entity<Room>()
            .HasMany(e => e.Bookings)
            .WithOne(e => e.Room)
            .HasForeignKey(e => e.RoomId)
            .IsRequired();

        modelBuilder.Entity<Booking>()
            .HasMany(e => e.BookingGuests)
            .WithOne(e => e.Booking)
            .HasForeignKey(e => e.BookingId)
            .IsRequired();

        modelBuilder.Entity<Guest>()
             .HasMany(e => e.BookingGuests)
             .WithOne(e => e.Guest)
             .HasForeignKey(e => e.GuestId)
             .IsRequired();

        BookingPopulateRoomTypes.RoomTypes(modelBuilder);
    }
}