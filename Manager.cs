using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
  // Hotel Manager class to manage room operations

class Manager
   {
         // List to store all rooms
         private List<Room> rooms = new List<Room>(); //. It starts empty.Every time you add a room, it goes into this list.

        // Method to add a new room
        public void AddRoom(int roomNumber, double dailyRate)
    {
        // Create new Room object with user input
        Room newRoom = new Room(roomNumber, dailyRate);

        // Add the new room to the list
        rooms.Add(newRoom);

        Console.WriteLine("Room added successfully."); // Confirmation message

    }

         // Method to view all rooms (available + reserved)
        public void ViewRooms()
    {
        if (rooms.Count == 0) //Loops through the list of rooms.
            {
            Console.WriteLine("No rooms added yet."); // Handle empty list case
            return;
        }

        Console.WriteLine("\nList of all rooms:");
        foreach (Room room in rooms)
        {
            Console.WriteLine(room); // Uses Room.ToString()
        }
    }

        // Method to reserve a room for a guest
        public void ReserveRoom(int roomNumber, string guestName, int nights)
        {
            // Search for the room with the given room number
            Room room = rooms.Find(r => r.RoomNumber == roomNumber); //Finds a room in the list by its number

            if (room == null) //If the room doesn’t exist, print error
            {
                Console.WriteLine(" Room not found.");
            }
            else if (room.IsReserved)
            {
                Console.WriteLine(" Room is already reserved.");
            }
            else
            {
                room.Reserve(guestName, nights, reservationDate); // Calls the Reserve method in Room class to reserve the room

                Console.WriteLine($" Room {roomNumber} reserved successfully for {guestName}.");
            }
            // Updated ReserveRoom() in Manager class to handle reservation date.


        }

        // Added ViewReservations() method in Manager to display all reserved rooms with total cost.
        public void ViewReservations() // Method to view all reservations with total cost
        {
            bool anyReservation = false;

            Console.WriteLine("\n=== List of Reservations ===");

            foreach (Room room in rooms)
            {
                if (room.IsReserved)
                {
                    anyReservation = true;
                    double total = room.GetTotalCost();
                    Console.WriteLine($"Room {room.RoomNumber} | Guest: {room.GuestName} | Nights: {room.Nights} | Total: {total:C}");
                }
            }

            if (!anyReservation)
            {
                Console.WriteLine("No reservations found."); //If no reservations exist, shows a message
            }
        }

        // Method to cancel reservation by room number
        public void CancelRoomReservation(int roomNumber)
        {
            //Searches for the room
            //If reserved, cancels it using the method in Room class
            Room room = rooms.Find(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine(" Room not found.");
            }
            else if (!room.IsReserved)
            {
                Console.WriteLine(" Room is not currently reserved.");
            }
            else
            {
                room.CancelReservation();
                Console.WriteLine($" Reservation for Room {roomNumber} has been cancelled.");
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Room room in rooms) //Loops through each room
                {
                    // Save room info as a line in the file
                    string line = $"{room.RoomNumber},{room.DailyRate},{room.IsReserved},{room.GuestName},{room.Nights},{room.ReservationDate:yyyy-MM-dd}";

                    writer.WriteLine(line);
                }
            }

            Console.WriteLine(" Rooms saved to file.");
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine(" File not found. Starting with an empty list.");
                return;
            }

            rooms.Clear(); // Clear existing data

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines) //Reads each line from the file
            {
                string[] parts = line.Split(',');
                //Parses values (room number, rate, reserved, guest, nights)
                int roomNumber = int.Parse(parts[0]);
                double dailyRate = double.Parse(parts[1]);
                bool isReserved = bool.Parse(parts[2]);
                string guestName = parts[3] == "null" ? null : parts[3];
                int nights = int.Parse(parts[4]);
                DateTime reservationDate = DateTime.Parse(parts[5]); // Parses the reservation date

                Room room = new Room(roomNumber, dailyRate);
                if (isReserved)
                {
                    room.Reserve(guestName, nights, reservationDate);
                }

                rooms.Add(room); // Adds the room to the list
            }

            Console.WriteLine("Rooms loaded from file."); 
        }

        // Method to search for reservations by guest name
        public void SearchByGuestName(string guestName)
        //Added SearchByGuestName() method in Manager class to find reservations by guest name.

        {
            bool found = false;

            Console.WriteLine($"\nSearching for reservations by guest: {guestName}");

            foreach (Room room in rooms) //Loops through all rooms
            {
                if (room.IsReserved && room.GuestName != null && room.GuestName.Equals(guestName, StringComparison.OrdinalIgnoreCase))
                ////Checks if the room is reserved and guest name matches
                {
                    Console.WriteLine($" Found: Room {room.RoomNumber} | Nights: {room.Nights} | Total: {room.GetTotalCost():C}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine(" No reservation found for this guest.");
            }
        }




    }
}