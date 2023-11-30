namespace RoomBookings
{
    public static class BookingFunctions
    {
        public static List<Booking> GenerateBookings(long start, long end)
        {
            var bookings = new List<Booking>();

            for (int i = 0; i < 1000; i++)
            {
                // Randomize Booking Length - Max 1 Hour
                var bookingLength = Random.Shared.NextInt64(1, (end - start) / 24);

                // Randomize Booking Start and End Time in Relation to Max Booking Length
                var startTime = Random.Shared.NextInt64(start, end);
                var endTime = Random.Shared.NextInt64(startTime, (startTime + bookingLength > end) ? end : startTime + bookingLength);

                // Add New Booking
                bookings.Add(new Booking(startTime, endTime));
            }

            // Return the List Ordered By Starte Time
            return [.. bookings.OrderBy(b => b.StartTime)];
        }

        public static void PrintResults(List<Room> rooms)
        {
            // Print Bookings in Each Room
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room: {rooms.IndexOf(room) + 1} - Bookings: {room.Bookings.Count}");

                foreach (var booking in room.Bookings)
                {
                    var bookingStart = DateTimeOffset.FromUnixTimeSeconds(booking.StartTime).DateTime;
                    var bookingEnd = DateTimeOffset.FromUnixTimeSeconds(booking.EndTime).DateTime;

                    Console.WriteLine($"Booking: {room.Bookings.IndexOf(booking) + 1} - Start: {bookingStart} - End: {bookingEnd}");
                }

                Console.WriteLine(string.Empty);
            }

            //Print Total Rooms Required and Confirm the Number of Bookings
            Console.WriteLine($"Total Rooms: {rooms.Count} - Total Bookings: {rooms.SelectMany(r => r.Bookings).Count()}");
            Console.WriteLine(string.Empty);
        }
    }
}