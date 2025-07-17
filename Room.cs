using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    // Room class to store room information
    class Room
    {
  
        public int RoomNumber { get; set; } // Property: Room number (unique identifier)
        public double DailyRate { get; set; } // Property: Daily rate for the room
        public bool IsReserved { get; set; } // Property: Reservation status (true if reserved)

        // Constructor to initialize a new room
        public Room(int roomNumber, double dailyRate)
        {
            RoomNumber = roomNumber;       // Assign the room number
            DailyRate = dailyRate;         // Assign the daily rate
            IsReserved = false;            // New room is not reserved by default
        }

        // Method to return a string representation of the room
        public override string ToString()
        {
            return $"Room {RoomNumber} | Rate: {DailyRate:C} | " +
                   (IsReserved ? "Reserved" : "Available"); // Show room info with status
        }
    }
}

