# Hotel State Manager

## Overview
This is a **Hotel State Manager** console application built in C#.  
It allows a receptionist to manage hotel rooms, track guest occupied, and update room status. It does not handle future reservations.

---
## Features
1. **User Login**
   - Users log in with credentials stored in `users.save`.
   - If no user file exists, a default admin user (`admin/admin`) is created.
   Username: admin
   Password: admin
    Multiple users can be added manually by editing `users.save` (format: `username,password`).
   
2. **View Rooms**
   - See rooms that currently have guests.
   - See available rooms.

3. **Room Management**
   - Book a guest into an available room.
   - Check out a guest from an occupied room.
   - Mark a room as temporarily unavailable.

4. **Persistence**
   - All room data is automatically saved to `rooms.save` whenever a change occurs.
   - User data is automatically saved to `users.save`.
5. **Menu and Navigation**
   - Intuitive console menu for performing all tasks.
   - Logout and quit options available.
=== Hotel System ===
     Welcome, admin!
     [1] - See rooms with guests
     [2] - See available rooms
     [3] - Book a guest into a available room
     [4] - Check out a guest from an occupied room
     [5] - Mark a Room as Temporarily Unavailable
     [L] - Logout
     [q] - quit
   - Logout and quit options are available.
## Classes
| Class Name      | File Name       | Description                                                                 |
|-----------------|----------------|-----------------------------------------------------------------------------|
| **User**        | `User.cs`       | Handles user data and login functionality. Stores username and password.    |
| **Room**        | `Room.cs`       | Represents a hotel room. Stores room number, guest name, and status.       |
| **RoomStatus**  | `RoomStatus.cs` | Enum defining possible room statuses: `Available`, `Occupied`, `Unavailable`.|
| **Booking**     | `Booking.cs`    | Optional class to manage booking logic, connecting users with rooms.        |
| **Program**     | `Program.cs`    | Main program file. Contains menu, user interface, file loading/saving, and room management logic. |

## How to Run
1. cd Hotel_system
2. open terminal in the project folder 
3. Run: dotnet run Follow the menu prompts to interact with the system
4. net 8.0
5. Visual studio code

## Author Name
Syed Arbaz Hussain shah
Student| NBI 

I attached my project picture!
![alt text](<Screenshot 2025-10-31 at 23.04.48-1.png>))
