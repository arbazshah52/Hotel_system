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
        Console.Clear();
        Console.WriteLine("=== Hotel System ===");

	    Console.WriteLine("[q] - quit");

	    switch(Console.ReadLine())
	    {
		    case "q": running = false; break;
	    }

    }
}


