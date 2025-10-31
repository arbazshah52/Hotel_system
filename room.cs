namespace App;
//Represent a single hotel room in the system
class Room
{
    public int Number;           // Room number (unique ID)
    public string GuestName;     // Name of the guest staying
    public RoomStatus Status;    // Room status like avilable , occupied or unavilable
    // New room created
    public Room(int number)
    {
        Number = number; //assign the rooom
        Status = RoomStatus.Available; // every room starts as avilable
        GuestName = ""; //No guest 
    }
   public string ToSaveString()//room data into a string formate for saving file
    { 
        return $"{Number},{GuestName},{Status}";// room details like isa occupied
    }
}