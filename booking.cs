namespace App;
//Hotel room booking made by a user
class Booking
{
    public User Guest;          // Who is booking the room
    public Room Room;           // specific rom being booked
    public BookingStatus Status; // Cuurent Booking status (Pending, Confirmed, CheckedOut)
                                 //initial a new booking with the provider guest and room
    public Booking(User guest, Room room)
    {
        Guest = guest; //assign the guest who made the booking
        Room = room; //assign the room already booked
        Status = BookingStatus.Pending; //status of booking
    }
}
//Status of booking room
enum BookingStatus
{
    Pending, // create pending booking
    Confirmed, // booking approved
    CheckedOut // guset checkout,booking completed
}