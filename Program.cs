using HotelRoomManagement; // Make sure Validator is visible

namespace HotelRoomManagement
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Manager manager = new Manager();
            string filePath = "rooms.txt"; // File to store data
            manager.LoadFromFile(filePath);


            
            

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
                Console.WriteLine("6. Search Reservation by Guest Name");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                // Handle user input
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Room Number: ");
                        if (!int.TryParse(Console.ReadLine(), out int roomNumber) || !Validator.IsValidRoomNumber(roomNumber))
                        {
                            Console.WriteLine(" Invalid room number. Must be a positive integer.");
                            break;
                        }

                        Console.Write("Enter Daily Rate: ");
                        if (!double.TryParse(Console.ReadLine(), out double dailyRate) || !Validator.IsValidDailyRate(dailyRate))
                        {
                            Console.WriteLine(" Invalid daily rate. Must be a positive number.");
                            break;
                        }

                        manager.AddRoom(roomNumber, dailyRate);

                        break;

                    case "2":
                        manager.ViewRooms(); // Show all rooms
                        break;

                    case "3":
                        Console.Write("Enter Room Number to reserve: ");
                        if (!int.TryParse(Console.ReadLine(), out int reserveRoomNumber) || !Validator.IsValidRoomNumber(reserveRoomNumber))
                        {
                            Console.WriteLine(" Invalid room number.");
                            break;
                        }

                        Console.Write("Enter Guest Name: ");
                        string guestName = Console.ReadLine();
                        if (!Validator.IsValidGuestName(guestName))
                        {
                            Console.WriteLine(" Guest name cannot be empty.");
                            break;
                        }

                        Console.Write("Enter Number of Nights: ");
                        if (!int.TryParse(Console.ReadLine(), out int nights) || !Validator.IsValidNights(nights))
                        {
                            Console.WriteLine(" Invalid number of nights.");
                            break;
                        }

                        Console.Write("Enter Reservation Year: ");
                        if (!int.TryParse(Console.ReadLine(), out int year))
                        {
                            Console.WriteLine(" Invalid year.");
                            break;
                        }

                        Console.Write("Enter Reservation Month: ");
                        if (!int.TryParse(Console.ReadLine(), out int month))
                        {
                            Console.WriteLine(" Invalid month.");
                            break;
                        }

                        Console.Write("Enter Reservation Day: ");
                        if (!int.TryParse(Console.ReadLine(), out int day))
                        {
                            Console.WriteLine(" Invalid day.");
                            break;
                        }

                        DateTime reservationDate;
                        try
                        {
                            reservationDate = new DateTime(year, month, day);
                            if (!Validator.IsValidReservationDate(reservationDate))
                            {
                                Console.WriteLine(" Reservation date cannot be in the past.");
                                break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine(" Invalid date.");
                            break;
                        }

                        manager.ReserveRoom(reserveRoomNumber, guestName, nights, reservationDate);

                        break;

                    case "4":
                        manager.ViewReservations();
                        break;

                    case "5":
                        Console.Write("Enter Room Number to cancel: ");
                        int cancelRoomNumber = int.Parse(Console.ReadLine());
                        manager.CancelRoomReservation(cancelRoomNumber);
                        break;

                    case "6":
                        Console.Write("Enter Guest Name to search: ");
                        string searchName = Console.ReadLine();
                        manager.SearchByGuestName(searchName);
                        break;


                    case "0":
                        manager.SaveToFile(filePath);


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