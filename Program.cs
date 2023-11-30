using RoomBookings;

// Set Start and End Values of the Day
var start = new DateTimeOffset(DateTime.Today).ToUnixTimeSeconds();
var end = new DateTimeOffset(DateTime.Today.AddHours(24)).ToUnixTimeSeconds();

// Create List of Room Bookings
var bookings = BookingFunctions.GenerateBookings(start, end);

// Create List of Rooms to be Booked
var rooms = new List<Room>();

// Initiate First Room
var currentRoom = new Room();

// Initalize Available Bookings List
var availableBookings = bookings;

while (availableBookings.Count != 0 || bookings.Count != 0)
{
    // Set Current Booking to First in the List
    var currentBooking = availableBookings.First();

    // Remove Current Booking from List
    bookings.Remove(currentBooking);
    availableBookings.Remove(currentBooking);

    // Add Current Booking to a Room;
    currentRoom.Bookings.Add(currentBooking);

    // Retrieve Next Available Bookings
    availableBookings = availableBookings.Where(b => b.StartTime > currentBooking.EndTime).ToList();

    // Check if Room is Full for the Day
    if (currentBooking.EndTime == end || availableBookings.Count == 0)
    {
        // Add Current Room to Rooms Array
        rooms.Add(currentRoom);

        // Create New Room
        currentRoom = new Room();

        // Reset Available Bookings List
        availableBookings = bookings;
    }
}

BookingFunctions.PrintResults(rooms);
