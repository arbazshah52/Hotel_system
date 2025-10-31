using App;
using System.Diagnostics;
//Log in with information saved in a file.
//See a list of all rooms that currently have guests.
//See a list of all available rooms.
//Book a guest into a vacant room.
//Check out a guest from an occupied room.
//Mark a room as temporarily unavailable.


//USER LOGIN 
List<User> users = new(); //create a store all user
List<Room> rooms = new List<Room> { }; // list to strore all hotel rooms
User? activeUser = null; //track current login user
//  Load users data from file
if (File.Exists("users.save"))
{
    string[] lines = File.ReadAllLines("users.save");
    foreach (string line in lines)
    {
        string[] data = line.Split(",");
        if (data.Length == 2)
        {
            users.Add(new User(data[0], data[1]));//add user with username and password
        }
    }
}
else
    //Create admin account
    users.Add(new User("admin", "admin"));
    File.WriteAllLines("users.save", new string[] { "admin,admin" });
if (File.Exists("rooms.save"))//Load rooms from file if exits
{
    string[] lines = File.ReadAllLines("rooms.save");
    foreach (string line in lines)
    {
        string[] data = line.Split(',');
        if (data.Length == 3 && int.TryParse(data[0], out int number))
        {   //create room with number ,guest name and status
            Room room = new(number)
            {
                GuestName = data[1],
                Status = Enum.Parse<RoomStatus>(data[2])
            };
            rooms.Add(room);
        }
    }
}
    else
{       //if no room file exit the 5 rooms show avilable 
        for (int i = 1; i <= 5; i++)
            rooms.Add(new Room(i));
            SaveRooms(rooms); //save newly created rooms to file
} //saves current room states to room.save
void SaveRooms(List<Room> rooms)
{
    string[] saveRooms = new string[rooms.Count];
    for (int i = 0; i < rooms.Count; i++)
        saveRooms[i] = rooms[i].ToSaveString(); //convert room object to csv string
    File.WriteAllLines("rooms.save", saveRooms);
}

bool running = true; //used to keep the main loop
while (running)
{
    Console.Clear();
    //Login system
    if(activeUser ==null)
    {
        Console.WriteLine("=== Hotel System Login ===");
        Console.Write("Username: ");
        string? username = Console.ReadLine();

    	Console.Clear();
        Console.WriteLine("=== Hotel System Password===");
        Console.Write("Password: ");
        string? password = Console.ReadLine();

	    Debug.Assert(username != null);
        Debug.Assert(password != null);
         //Verify Username & password
        foreach (User user in users)
        {
            if(user.TryLogin(username, password))
            {
                activeUser = user; //Login success
                break;
            }
        }
         // Handle failed login system
        if (activeUser == null)
        {
            Console.WriteLine("Invalid username or password. Press any key to try again.");
            Console.ReadKey();
        }
    }
    else
    {
        ///Main Menu
        Console.Clear();
        Console.WriteLine("=== Hotel System ===");
        Console.WriteLine($"Welcome, {activeUser.Username}!");
        Console.WriteLine("[1] - See rooms with guests");
        Console.WriteLine("[2] - See avilable rooms");
        Console.WriteLine("[3] - Book a guest into a available room");
        Console.WriteLine("[4] - Check out a guest from an occupied room");
        Console.WriteLine("[5] - Mark a Room as Temporarily Unavailable"); 
        Console.WriteLine("[L] - Logout");
        Console.WriteLine("[q] - quit");
        String? choice = Console.ReadLine();
        switch (choice)
        {
            //see rooms with guest
        case "1":
           Console.Clear();
           Console.WriteLine("Rooms currently with guests:");
           foreach (Room room in rooms)
           {
               if (room.Status == RoomStatus.Occupied)
               {
                  Console.WriteLine($"Room {room.Number} - Guest: {room.GuestName}");
               }
            }
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
            break;
         case "2": //avilable rooms
            Console.Clear();
            Console.WriteLine("Available rooms:");
            foreach (Room room in rooms)
            {
                if (room.Status == RoomStatus.Available)
                  {
                  Console.WriteLine($"Room {room.Number}");
                }
             }
             Console.WriteLine("Press ENTER to continue...");
             Console.ReadLine();
                break;
            case "3"://Book guest
            Console.Clear();
            Console.WriteLine("Book a guest into a available room");
                foreach (Room room in rooms) //List avilable room before booking
                {
                    if (room.Status == RoomStatus.Available)
                    {
                        Console.WriteLine($"Room {room.Number}is Avilable");
                    }
                }
            Console.Write("Enter the room number to book: "); // input room and guest information
             string? roomInput = Console.ReadLine();
            Console.Write("Enter guest name: ");
            string? guestName = Console.ReadLine();
            // Validate room number
            if (int.TryParse(roomInput, out int roomNumber))
            {
            Room? selectedRoom = rooms.Find(r => r.Number == roomNumber);
            if (selectedRoom != null && selectedRoom.Status == RoomStatus.Available)
            {      //Book the room
            selectedRoom.GuestName = guestName ?? "Unknown";
            selectedRoom.Status = RoomStatus.Occupied;
            SaveRooms(rooms);
            Console.WriteLine($" Room {roomNumber} successfully booked for {guestName}!");
            }
            else
            {
            Console.WriteLine(" Room not available or does not exist.");
            }
        }
         else
        {
             Console.WriteLine("Invalid room number.");
        }
             Console.WriteLine("Press ENTER to return to menu...");
             Console.ReadLine();
                break; 
            case "4":// Checkout guest
            Console.Clear();
            Console.WriteLine("checkout guest");
                foreach (Room room in rooms) //Show occupied room only
                {
                    if (room.Status == RoomStatus.Occupied)
                        Console.WriteLine($"Room {room.Number} - Guest: {room.GuestName}");
                    
                }  //Input room to checkout
            Console.Write("Enter the room number to book checkout: ");
            string? checkoutInput = Console.ReadLine();
            if (int.TryParse(checkoutInput, out int checkoutRoom))
            {
                Room? selectedRoom = rooms.Find(r => r.Number == checkoutRoom);
                    if (selectedRoom != null && selectedRoom.Status == RoomStatus.Occupied)
                    {      //Perform checkout
                       Console.WriteLine($"Guest {selectedRoom.GuestName} checked out from Room {checkoutRoom}.");
                       selectedRoom.GuestName = "";
                        selectedRoom.Status = RoomStatus.Available;
                        SaveRooms(rooms); 
                    }
            else
            {
            Console.WriteLine(" Room is not occupied or does not exist.");
            }
        }
         else
        {
             Console.WriteLine("Invalid room number.");
        }

             Console.WriteLine("Press ENTER to return to menu...");
                Console.ReadLine();
                break;
                      case "5":// Mark Room Unavialble
            Console.Clear();
            Console.WriteLine("Mark a Room as a Temporarily Unavailable ");
                foreach (Room room in rooms) //Show room that can be marked
                {
                    if (room.Status == RoomStatus.Available)
                    {
                        Console.WriteLine($"Room {room.Number}is Avilable");
                    }
                }
            Console.Write("Enter the room number to mark as unavailable:");
                string? roomInputUnavailable = Console.ReadLine();
            //Validate and update room status
            if (int.TryParse(roomInputUnavailable, out int roomNumberUnavailable))
            {
                Room? selectedRoom = rooms.Find(r => r.Number == roomNumberUnavailable);
                    if (selectedRoom != null && selectedRoom.Status == RoomStatus.Available)
                    {
                       selectedRoom.Status = RoomStatus.Unavailable;
                        SaveRooms(rooms);
            Console.WriteLine($"Room {roomNumberUnavailable} is now marked as temporarily unavailable.");
                 }
            else
            {
            Console.WriteLine(" Room is not Available or does not exist.");
            }
        }
         else
        {
             Console.WriteLine("Invalid room number.");
        }

             Console.WriteLine("Press ENTER to return to menu...");
                Console.ReadLine();
                break;             
         // LOGOUT
          case "L":
            activeUser = null;
            break;
         //Finish 
         case "Q":
            running = false;
            break;
            default:
         // handles all other inputs that not match menu option
        Console.WriteLine("Invalid choice. Press ENTER...");
        Console.ReadLine();
                break;
            //end of switch 
        }
    }
}

