namespace RoomBookings
{
    public class Room
    {
        public List<Booking> Bookings { get; set; }

        public Room()
        {
            this.Bookings = [];
        }
    }
}