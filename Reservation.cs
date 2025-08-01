﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    class Reservation
    {
        
        public string GuestName { get; set; } 
        public int Nights { get; set; } 
        public DateTime ReservationDate { get; set; }

        public Reservation(string guestName, int nights, DateTime date) // Constructor to initialize a new reservation
        {
            GuestName = guestName; 
            Nights = nights;
            ReservationDate = date;
        }

        public override string ToString() // This method returns a string representation of the reservation
        {
            return $"Guest: {GuestName}, Nights: {Nights}, Date: {ReservationDate:yyyy-MM-dd}";
        }

        public double GetTotalCost(double rate) // This method calculates the total cost of the reservation
        {
            return rate * Nights;
        }

    }
}
