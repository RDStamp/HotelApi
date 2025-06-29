using Microsoft.EntityFrameworkCore;
using facade.Data.Entities.Public;

namespace facade.Data.Infrustructure;

public class BookingPopulateRoomTypes
{

    public static void RoomTypes(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<RoomType>(entity =>
        {
            _ = entity.HasData(
                new RoomType
                {
                    Id = 1,
                    Name = "Single",
                    Detail = "Single Occupancy Single Bed",
                },
                new RoomType
                {
                    Id = 2,
                    Name = "Double",
                    Detail = "Double Occupancy Single Beds",
                },
                new RoomType
                {
                    Id = 3,
                    Name = "Deluxe",
                    Detail = "Double Occupancy Double Bed",
                }
                );
        });
    }
}
