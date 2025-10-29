namespace App;

class Booking
{
    public User Guest;          // Who is booking the room
    public Room Room;           // Which room is being booked
    public BookingStatus Status; // Booking status (Pending, Confirmed, CheckedOut)

    public Booking(User guest, Room room)
    {
        Guest = guest;
        Room = room;
        Status = BookingStatus.Pending;
    }
}
enum BookingStatus
{
    Pending,
    Confirmed,
    CheckedOut
}