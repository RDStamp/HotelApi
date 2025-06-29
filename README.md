
## Preliminary Conclusions / Deductions / Assumptions 

**Entities**   
 - Should use GUIDS for external Id’s
 - Hotel => Id, Address, Postcode, Name, Telephone Number & Email
 - Guest => Id, Name, Surname, Telephone Number & Email
 - Room =>  Id, Capacity, Hotel Id, Room Number, Type Id
 - Types =>  Id, Type Name, Type Detail
 - Booking => Id, Booking Reference Id, Start Date, End Date   

**Relations** 
 - Rooms >=< Bookings => Room Id, Booking Id 
 - Hotels =< Rooms => Hotel Id 
 - Room Types =< Rooms => Room Type Id 
 - Rooms =< Bookings => Room Id 

**Endpoints**   
- Hotels
- GET Hotel By Name => Name
- GET Available Hotels => Start & End Dates

**Bookings** 
 - POST Booking => Start, End, Guests
 - DELETE Booking => Booking Id
 - GET Booking => Booking ID

**Seeding**
 - PUT Seeding => Seed the DB
 - DELETE Seeding => Reset the DB 

**Assumptions**  
 - 3 Room Types & 6 Rooms per Hotel => Each Hotel has 2 Rooms of each Type
 - Single => Single Occupancy => Single Bed
 - Double => Double Occupancy => Single Beds
 - Deluxe => Double Occupancy => Double Bed 
