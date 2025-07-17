namespace HotelRoomManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a HotelManager object to manage the hotel system
            HotelManager manager = new HotelManager();

            bool running = true;
            while (running)
            {
                // Display user menu
                Console.WriteLine("\n==== Hotel Room Management ====");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. View All Rooms");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();


            }
        }
    }