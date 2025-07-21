using System;
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

        public Reservation(string guestName, int nights, DateTime date) 
        {
            GuestName = guestName; 
            Nights = nights;
            ReservationDate = date;
        }

    }
}
