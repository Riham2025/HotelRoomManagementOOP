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
        private List<Room> rooms = new List<Room>();

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
            if (rooms.Count == 0)
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
    }
}