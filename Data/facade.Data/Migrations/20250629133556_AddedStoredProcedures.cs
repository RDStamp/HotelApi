using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace facade.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Detail", "Name" },
                values: new object[,]
                {
                    { 1, "Single Occupancy Single Bed", "Single" },
                    { 2, "Double Occupancy Single Beds", "Double" },
                    { 3, "Double Occupancy Double Bed", "Deluxe" }
                });

            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[DeleteDbTestData]
                AS
                BEGIN
                -- =============================================
                -- Author:		RDS
                -- Create date: 28 June 2025
                -- Description:	Populate test data to DB
                -- =============================================
	                SET NOCOUNT ON;

                    DELETE FROM [dbo].[BookingGuests];
                    DELETE FROM [dbo].[Guests];
                    DELETE FROM [dbo].[Bookings];
                    DELETE FROM [dbo].[Rooms];
                    DELETE FROM [dbo].[Hotels];

                    DBCC CHECKIDENT ('[dbo].[BookingGuests]');
                    DBCC CHECKIDENT ('[dbo].[Guests]');
                    DBCC CHECKIDENT ('[dbo].[Bookings]');
                    DBCC CHECKIDENT ('[dbo].[Rooms]');
                    DBCC CHECKIDENT ('[dbo].[Hotels]');     
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[PopulateDbTestData]
                AS
                BEGIN
                -- =============================================
                -- Author:		RDS
                -- Create date: 28 June 2025
                -- Description:	Populate test data to DB
                -- =============================================
	                SET NOCOUNT ON;
                    DECLARE @TranName VARCHAR(20);
                    SELECT @TranName = 'DBSeeding';

	                BEGIN TRY
                       BEGIN TRANSACTION @TranName WITH MARK;

                        SET IDENTITY_INSERT [dbo].[Hotels] ON;

                        INSERT INTO 
                            [dbo].[Hotels]
                            ([Id], [FullName], [Address], [Postcode], [Tel_No], [Email])
                        VALUES
                            (1, 'Test Hotel 1', 'Test Hotel 1 Address', 'UB10 5PF', '0000000001', 'testhotel1@hotels.com'),
                            (2, 'Test Hotel 2', 'Test Hotel 2 Address', 'UB10 6PF', '0000000002', 'testhotel2@hotels.com'),
                            (3, 'Test Hotel 3', 'Test Hotel 3 Address', 'UB10 7PF', '0000000003', 'testhotel3@hotels.com');

                        SET IDENTITY_INSERT [dbo].[Hotels] OFF;


                        SET IDENTITY_INSERT [dbo].[Rooms] ON;

                        INSERT INTO
	                        [dbo].[Rooms]
	                        ([Id], [Number], [Capacity], [HotelId], [RoomTypeId])
                        VALUES
	                        (1, 101, 1, 1, 1),
	                        (2,	102, 1, 1, 1),
	                        (3,	103, 2, 1, 2),
	                        (4,	104, 2, 1, 2),
	                        (5,	105, 2, 1, 3),
	                        (6,	106, 2, 1, 3),
	                        (7,	201, 1, 2, 1),
	                        (8,	202, 1, 2, 1),
	                        (9,	203, 2, 2, 2),
	                        (10, 204, 2, 2, 2),
	                        (11, 205, 2, 2, 3),
	                        (12, 206, 2, 2, 3),
	                        (13, 301, 1, 3, 1),
	                        (14, 302, 1, 3, 1),
	                        (15, 303, 2, 3, 2),
	                        (16, 304, 2, 3, 2),
	                        (17, 305, 2, 3, 3),
	                        (18, 306, 2, 3, 3);

                        SET IDENTITY_INSERT [dbo].[Rooms] OFF;

                        SET IDENTITY_INSERT [dbo].[Bookings] ON;
        
                        -- There are errors in this but time coinstraints
                        -- The test data does nopt currenlty cover all test cases
                        INSERT INTO
                            [dbo].[Bookings]
                            ([Id], [StartDate], [EndDate], [RoomId], [RefId])
                        VALUES
                            (1, '27 June 2025', '03 July 2025', 1, NEWID()),
                            (2, '03 July 2025', '08 July 2025', 1, NEWID()),
                            (3, '08 July 2025', '17 July 2025', 1, NEWID()),
                            (4, '29 June 2025', '13 July 2025', 2, NEWID()),
                            (5, '13 July 2025', '21 July 2025', 2, NEWID()),
                            (6, '21 July 2025', '23 July 2025', 2, NEWID()),
                            (7, '28 June 2025', '06 July 2025', 3, NEWID()),
                            (8, '06 July 2025', '17 July 2025', 3, NEWID()),
                            (9, '17 July 2025', '19 July 2025', 3, NEWID()),
                            (10, '28 June 2025', '12 July 2025', 4, NEWID()),
                            (11, '12 July 2025', '25 July 2025', 4, NEWID()),
                            (12, '25 July 2025', '29 July 2025', 4, NEWID()),
                            (13, '29 June 2025', '02 July 2025', 5, NEWID()),
                            (14, '02 July 2025', '07 July 2025', 5, NEWID()),
                            (15, '07 July 2025', '11 July 2025', 5, NEWID()),
                            (16, '01 July 2025', '05 July 2025', 6, NEWID()),
                            (17, '05 July 2025', '19 July 2025', 6, NEWID()),
                            (18, '19 July 2025', '29 July 2025', 6, NEWID()),
                            (19, '01 July 2025', '15 July 2025', 7, NEWID()),
                            (20, '15 July 2025', '23 July 2025', 7, NEWID()),
                            (21, '23 July 2025', '01 August 2025', 7, NEWID()),
                            (22, '01 July 2025', '11 July 2025', 8, NEWID()),
                            (23, '11 July 2025', '25 July 2025', 8, NEWID()),
                            (24, '25 July 2025', '30 July 2025', 8, NEWID()),
                            (25, '30 June 2025', '08 July 2025', 9, NEWID()),
                            (26, '08 July 2025', '13 July 2025', 9, NEWID()),
                            (27, '13 July 2025', '22 July 2025', 9, NEWID()),
                            (28, '02 July 2025', '15 July 2025', 10, NEWID()),
                            (29, '15 July 2025', '25 July 2025', 10, NEWID()),
                            (30, '25 July 2025', '01 August 2025', 10, NEWID()),
                            (31, '29 June 2025', '04 July 2025', 11, NEWID()),
                            (32, '04 July 2025', '18 July 2025', 11, NEWID()),
                            (33, '18 July 2025', '28 July 2025', 11, NEWID()),
                            (34, '30 June 2025', '08 July 2025', 12, NEWID()),
                            (35, '08 July 2025', '11 July 2025', 12, NEWID()),
                            (36, '11 July 2025', '13 July 2025', 12, NEWID()),
                            (37, '02 July 2025', '09 July 2025', 13, NEWID()),
                            (38, '09 July 2025', '12 July 2025', 13, NEWID()),
                            (39, '12 July 2025', '21 July 2025', 13, NEWID()),
                            (40, '27 June 2025', '04 July 2025', 14, NEWID()),
                            (41, '04 July 2025', '13 July 2025', 14, NEWID()),
                            (42, '13 July 2025', '20 July 2025', 14, NEWID()),
                            (43, '01 July 2025', '12 July 2025', 15, NEWID()),
                            (44, '12 July 2025', '15 July 2025', 15, NEWID()),
                            (45, '15 July 2025', '24 July 2025', 15, NEWID()),
                            (46, '30 June 2025', '08 July 2025', 16, NEWID()),
                            (47, '08 July 2025', '20 July 2025', 16, NEWID()),
                            (48, '20 July 2025', '26 July 2025', 16, NEWID()),
                            (49, '27 June 2025', '29 June 2025', 17, NEWID()),
                            (50, '29 June 2025', '09 July 2025', 17, NEWID()),
                            (51, '09 July 2025', '11 July 2025', 17, NEWID()),
                            (52, '02 July 2025', '08 July 2025', 18, NEWID()),
                            (53, '08 July 2025', '10 July 2025', 18, NEWID()),
                            (54, '10 July 2025', '17 July 2025', 18, NEWID());
    
                        SET IDENTITY_INSERT [dbo].[Bookings] OFF;

                        SET IDENTITY_INSERT [dbo].[Guests] ON;

                        INSERT INTO 
                            [dbo].[Guests]
                            ([Id], [FullName], [Surname], [Tel_No], [Email])
                        VALUES
                            (1, 'Guest Anon1', 'Anon1', '0000000001', 'Guest.Anon1@gmail.com'),
                            (2, 'Guest Anon2', 'Anon2', '0000000002', 'Guest.Anon2@gmail.com'),
                            (3, 'Guest Anon3', 'Anon3', '0000000003', 'Guest.Anon3@gmail.com'),
                            (4, 'Guest Anon4', 'Anon4', '0000000004', 'Guest.Anon4@gmail.com'),
                            (5, 'Guest Anon5', 'Anon5', '0000000005', 'Guest.Anon5@gmail.com'),
                            (6, 'Guest Anon6', 'Anon6', '0000000006', 'Guest.Anon6@gmail.com'),
                            (7, 'Guest Anon7', 'Anon7', '0000000007', 'Guest.Anon7@gmail.com'),
                            (8, 'Guest Anon8', 'Anon8', '0000000008', 'Guest.Anon8@gmail.com'),
                            (9, 'Guest Anon9', 'Anon9', '0000000009', 'Guest.Anon9@gmail.com'),
                            (10, 'Guest Anon10', 'Anon10', '0000000010', 'Guest.Anon10@gmail.com'),
                            (11, 'Guest Anon11', 'Anon11', '0000000011', 'Guest.Anon11@gmail.com'),
                            (12, 'Guest Anon12', 'Anon12', '0000000012', 'Guest.Anon12@gmail.com'),
                            (13, 'Guest Anon13', 'Anon13', '0000000013', 'Guest.Anon13@gmail.com'),
                            (14, 'Guest Anon14', 'Anon14', '0000000014', 'Guest.Anon14@gmail.com'),
                            (15, 'Guest Anon15', 'Anon15', '0000000015', 'Guest.Anon15@gmail.com'),
                            (16, 'Guest Anon16', 'Anon16', '0000000016', 'Guest.Anon16@gmail.com'),
                            (17, 'Guest Anon17', 'Anon17', '0000000017', 'Guest.Anon17@gmail.com'),
                            (18, 'Guest Anon18', 'Anon18', '0000000018', 'Guest.Anon18@gmail.com'),
                            (19, 'Guest Anon19', 'Anon19', '0000000019', 'Guest.Anon19@gmail.com'),
                            (20, 'Guest Anon20', 'Anon20', '0000000020', 'Guest.Anon20@gmail.com');

                        SET IDENTITY_INSERT [dbo].[Guests] OFF;

                        INSERT INTO 
                            [dbo].[BookingGuests]
                            ([BookingId], [GuestId], [CreatedAt], [UpdatedAt])
                        VALUES                        
                            (1, 12, GETDATE(), GETDATE()),
                            (2, 10, GETDATE(), GETDATE()),
                            (3, 5, GETDATE(), GETDATE()),
                            (4, 17, GETDATE(), GETDATE()),
                            (5, 11, GETDATE(), GETDATE()),
                            (6, 6, GETDATE(), GETDATE()),
                            (7, 7, GETDATE(), GETDATE()),
                            (8, 14, GETDATE(), GETDATE()),
                            (9, 14, GETDATE(), GETDATE()),
                            (10, 10, GETDATE(), GETDATE()),
                            (11, 5, GETDATE(), GETDATE()),
                            (12, 19, GETDATE(), GETDATE()),
                            (13, 18, GETDATE(), GETDATE()),
                            (14, 14, GETDATE(), GETDATE()),
                            (15, 12, GETDATE(), GETDATE()),
                            (16, 3, GETDATE(), GETDATE()),
                            (17, 13, GETDATE(), GETDATE()),
                            (18, 10, GETDATE(), GETDATE()),
                            (19, 11, GETDATE(), GETDATE()),
                            (20, 4, GETDATE(), GETDATE()),
                            (21, 7, GETDATE(), GETDATE()),
                            (22, 18, GETDATE(), GETDATE()),
                            (23, 5, GETDATE(), GETDATE()),
                            (24, 6, GETDATE(), GETDATE()),
                            (25, 5, GETDATE(), GETDATE()),
                            (26, 8, GETDATE(), GETDATE()),
                            (27, 13, GETDATE(), GETDATE()),
                            (28, 18, GETDATE(), GETDATE()),
                            (29, 8, GETDATE(), GETDATE()),
                            (30, 9, GETDATE(), GETDATE()),
                            (31, 5, GETDATE(), GETDATE()),
                            (32, 11, GETDATE(), GETDATE()),
                            (33, 8, GETDATE(), GETDATE()),
                            (34, 17, GETDATE(), GETDATE()),
                            (35, 10, GETDATE(), GETDATE()),
                            (36, 3, GETDATE(), GETDATE()),
                            (37, 15, GETDATE(), GETDATE()),
                            (38, 15, GETDATE(), GETDATE()),
                            (39, 12, GETDATE(), GETDATE()),
                            (40, 12, GETDATE(), GETDATE()),
                            (41, 17, GETDATE(), GETDATE()),
                            (42, 18, GETDATE(), GETDATE()),
                            (43, 19, GETDATE(), GETDATE()),
                            (44, 19, GETDATE(), GETDATE()),
                            (45, 18, GETDATE(), GETDATE()),
                            (46, 19, GETDATE(), GETDATE()),
                            (47, 6, GETDATE(), GETDATE()),
                            (48, 3, GETDATE(), GETDATE()),
                            (49, 5, GETDATE(), GETDATE()),
                            (50, 17, GETDATE(), GETDATE()),
                            (51, 16, GETDATE(), GETDATE()),
                            (52, 6, GETDATE(), GETDATE()),
                            (53, 8, GETDATE(), GETDATE()),
                            (54, 14, GETDATE(), GETDATE()),
                            (7, 7, GETDATE(), GETDATE()),
                            (8, 14, GETDATE(), GETDATE()),
                            (9, 14, GETDATE(), GETDATE()),
                            (10, 10, GETDATE(), GETDATE()),
                            (11, 5, GETDATE(), GETDATE()),
                            (12, 19, GETDATE(), GETDATE()),
                            (13, 18, GETDATE(), GETDATE()),
                            (14, 14, GETDATE(), GETDATE()),
                            (15, 12, GETDATE(), GETDATE()),
                            (16, 3, GETDATE(), GETDATE()),
                            (17, 13, GETDATE(), GETDATE()),
                            (18, 10, GETDATE(), GETDATE()),
                            (25, 5, GETDATE(), GETDATE()),
                            (26, 8, GETDATE(), GETDATE()),
                            (27, 13, GETDATE(), GETDATE()),
                            (28, 18, GETDATE(), GETDATE()),
                            (29, 8, GETDATE(), GETDATE()),
                            (30, 9, GETDATE(), GETDATE()),
                            (31, 5, GETDATE(), GETDATE()),
                            (32, 11, GETDATE(), GETDATE()),
                            (33, 8, GETDATE(), GETDATE()),
                            (34, 17, GETDATE(), GETDATE()),
                            (35, 10, GETDATE(), GETDATE()),
                            (36, 3, GETDATE(), GETDATE()),
                            (43, 19, GETDATE(), GETDATE()),
                            (44, 19, GETDATE(), GETDATE()),
                            (45, 18, GETDATE(), GETDATE()),
                            (46, 19, GETDATE(), GETDATE()),
                            (47, 6, GETDATE(), GETDATE()),
                            (48, 3, GETDATE(), GETDATE()),
                            (49, 5, GETDATE(), GETDATE()),
                            (50, 17, GETDATE(), GETDATE()),
                            (51, 16, GETDATE(), GETDATE()),
                            (52, 6, GETDATE(), GETDATE()),
                            (53, 8, GETDATE(), GETDATE()),
                            (54, 14, GETDATE(), GETDATE());

                       COMMIT TRANSACTION @TranName;
                    END TRY
    
                    BEGIN CATCH
                        ROLLBACK TRANSACTION @TranName;

                        DELETE FROM [dbo].[BookingGuests];
                        DELETE FROM [dbo].[Guests];
                        DELETE FROM [dbo].[Bookings];
                        DELETE FROM [dbo].[Rooms];
                        DELETE FROM [dbo].[Hotels];               
                    END CATCH
    
                END;
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.Sql(@"
                DROP PROCEDURE PopulateDbTestData;
            ");

            migrationBuilder.Sql(@"
                DROP PROCEDURE DeleteDbTestData;
            ");
        }
    }
}
