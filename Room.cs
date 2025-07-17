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
        //basic properties
        
        public int RoomNumber { get; set; } 
        public double DailyRate { get; set; }
        public bool IsReserved { get; set; }
    }
}
