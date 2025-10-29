using App;
using System.Diagnostics;
//Log in with information saved in a file.
//See a list of all rooms that currently have guests.
//See a list of all available rooms.
//Book a guest into a vacant room.
//Check out a guest from an occupied room.
//Mark a room as temporarily unavailable.

List<User> users = new();
User? active_user = null;

//  Load users from file if it exists
if (File.Exists("users.save"))
{
    string[] lines = File.ReadAllLines("users.save");
    foreach (string line in lines)
    {
        string[] data = line.Split(",");
        if (data.Length == 2)
        {
            users.Add(new User(data[0], data[1]));
        }
    }
}
else
{
    users.Add(new User("admin", "admin"));
    File.WriteAllLines("users.save", new string[] { "admin,admin" });
}
// --- ROOMS ---
List<Room> rooms = new List<Room>
{
    new Room(1),
    new Room(2),
    new Room(3)
};
// Assign some guests to rooms
rooms[0].GuestName = "arbaz";
rooms[0].Status = RoomStatus.Occupied;
rooms[2].GuestName = "shah";
rooms[2].Status = RoomStatus.Occupied;

bool running = true;
while (running)
{
    Console.Clear();
    if (active_user == null)
    {
        Console.WriteLine("=== Hotel System Login ===");
        Console.Write("Username: ");
        string? username = Console.ReadLine();

    	Console.Clear();
        Console.WriteLine("=== Hotel System Login ===");
        Console.Write("Password: ");
        string? password = Console.ReadLine();

	    Debug.Assert(username != null);
	    Debug.Assert(password != null);

        foreach (User user in users)
        {
            if(user.TryLogin(username, password))
            {
                active_user = user;
                break;
            }
        }

        if (active_user == null)
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
        Console.WriteLine($"Welcome, {active_user.Username}!");
        Console.WriteLine("[1] - See rooms with guests");
        Console.WriteLine("[L] - Logout");
        Console.WriteLine("[q] - quit");
        String? choice = Console.ReadLine();
        switch (choice)
        {
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

            case "L":
                active_user = null;
                break;

            case "Q":
                running = false;
                break;
        }
    }
}

