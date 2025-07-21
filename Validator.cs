using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManagement
{
    class Validator
    {

        public static bool IsValidRoomNumber(int roomNumber)
        {
            return roomNumber > 0;
        }

        public static bool IsValidDailyRate(double dailyRate)
        {
            return dailyRate > 0;
        }

        public static bool IsValidGuestName(string guestName)
        {
            return !string.IsNullOrWhiteSpace(guestName);
        }

        public static bool IsValidNights(int nights)
        {
            return nights > 0;
        }

        public static bool IsValidReservationDate(DateTime reservationDate)
        {
            return reservationDate.Date >= DateTime.Today;
        }




    }
}
