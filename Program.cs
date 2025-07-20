namespace HotelRoomManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a HotelManager object to manage the hotel system
            Manager manager = new Manager();

            bool running = true;
            while (running)
            {
                // Display user menu
                Console.WriteLine("\n==== Hotel Room Management ====");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. View All Rooms");
                Console.WriteLine("3. Reserve a Room");
                Console.WriteLine("4. View All Reservations with Total Cost");
                Console.WriteLine("5. Cancel a Reservation");
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

                    case "3":
                        Console.Write("Enter Room Number to reserve: ");
                        int reserveRoomNumber = int.Parse(Console.ReadLine());

                        Console.Write("Enter Guest Name: ");
                        string guestName = Console.ReadLine();

                        Console.Write("Enter Number of Nights: ");
                        int nights = int.Parse(Console.ReadLine());

                        manager.ReserveRoom(reserveRoomNumber, guestName, nights); // call method in Manager
                        break;

                    case "4":
                        manager.ViewReservations();
                        break;

                    case "5":
                        Console.Write("Enter Room Number to cancel: ");
                        int cancelRoomNumber = int.Parse(Console.ReadLine());
                        manager.CancelRoomReservation(cancelRoomNumber);
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
}