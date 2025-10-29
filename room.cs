namespace App;

class Room
{
    public int Number;           // Room number (unique ID)
    public string GuestName;     // Who is staying
    public RoomStatus Status;    // Room status

    public Room(int number)
    {
        Number = number;
        Status = RoomStatus.Available; // Reference to enum
        GuestName = "";
    }
}