namespace App
{
    public enum RoomStatus //comparted to using plan string
    {
        Available, // room is ready booked
        Occupied, // room cuurentaly has a guest check in
        Unavailable // room is temporaily out of service like cleaning
    }
}
