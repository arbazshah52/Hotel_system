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
        Console.WriteLine("[q] - quit");

	    switch(Console.ReadLine())
	    {
		    case "q": running = false; break;
	    }

    }
}


