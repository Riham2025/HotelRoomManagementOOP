﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
   

    // Room class to store room information
    class Room
    {
        public List<Reservation> Reservations { get; set; } = new List<Reservation>(); //// List to store reservations for the room


        public int RoomNumber { get; set; } // Property: Room number (unique identifier)
        public double DailyRate { get; set; } // Property: Daily rate for the room
        public bool IsReserved { get; set; } // Property: Reservation status (true if reserved)

        public string GuestName { get; set; }  // Stores the guest's name
        public int Nights { get; set; }      // Stores number of nights reserved

        public DateTime ReservationDate { get; set; } // Stores the date of reservation

         


        public void Reserve(string guestName, int nights, DateTime reservationDate)
        {
            GuestName = guestName;
            Nights = nights;
            ReservationDate = reservationDate;
            IsReserved = true;
        }


        // Constructor to initialize a new room
        public Room(int roomNumber, double dailyRate) //This is a constructor: it runs when a new room is created
        {
            RoomNumber = roomNumber;       // Assign the room number
            DailyRate = dailyRate;         // Assign the daily rate
            IsReserved = false;            // New room is not reserved by default
        }


        // Method to return a string representation of the room
        public override string ToString()
        {
            if (Reservations.Count == 0)
                return $"Room {RoomNumber} | Rate: {DailyRate:C} | Available";

            string result = $"Room {RoomNumber} | Rate: {DailyRate:C} | Reservations:\n";
            foreach (var res in Reservations)
            {
                result += $"   - {res}\n";
            }

            return result;
        }




        // Method to calculate total cost of reservation
        public double GetTotalCost()

        {
            return DailyRate * Nights;
        }


        // Method to cancel the reservation
        public void CancelReservation()
        {
            GuestName = null;
            Nights = 0;
            IsReserved = false;
            //Sets IsReserved to false
            //Clears guest info and nights
        }

        public bool AddReservation(string guestName, int nights, DateTime date) 
        {
            if (Reservations.Any(r => r.ReservationDate.Date == date.Date))
            {
                return false; // Already reserved for that date
            }

            Reservations.Add(new Reservation(guestName, nights, date));
            return true;
        }

        




    }
}

