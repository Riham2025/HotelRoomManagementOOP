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

                // Handle user input
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Room Number: ");
                        int roomNumber = int.Parse(Console.ReadLine()); // Get room number

                        Console.Write("Enter Daily Rate: ");
                        double dailyRate = double.Parse(Console.ReadLine()); // Get rate

                        manager.AddRoom(roomNumber, dailyRate); // Call AddRoom
                        break;

                    case "2":
                        manager.ViewRooms(); // Show all rooms
                        break;

                    case "0":
                        running = false; // Exit the loop
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option."); // Handle unknown input
                        break;

                }

            }


        }
        
    }