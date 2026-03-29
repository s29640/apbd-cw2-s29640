using EquipmentRental.Models;
using EquipmentRental.Services;

namespace EquipmentRental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var equipmentService = new EquipmentService();
            var userService = new UserService();
            var penaltyPolicy = new PenaltyPolicy();
            var rentalService = new RentalService(penaltyPolicy);

            Console.WriteLine("=== EQUIPMENT RENTAL DEMO ===");
            Console.WriteLine();

            // 1. Dodanie użytkowników
            var student1 = new Student(1, "Jan", "Kowalski", "s12345");
            var student2 = new Student(2, "Anna", "Nowak", "s23456");
            var employee1 = new Employee(3, "Piotr", "Zielinski", "IT");

            userService.AddUser(student1);
            userService.AddUser(student2);
            userService.AddUser(employee1);

            Console.WriteLine("Users added:");
            foreach (var user in userService.GetAllUsers())
            {
                Console.WriteLine(user);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));


            // 2. Dodanie sprzętu
            var laptop1 = new Laptop(1, "Dell Latitude", "LAP-001", "Intel i5", 16);
            var laptop2 = new Laptop(2, "Lenovo ThinkPad", "LAP-002", "Intel i7", 32);
            var projector1 = new Projector(3, "Epson EB-X06", "PROJ-001", "1920x1080", 3600);
            var camera1 = new Camera(4, "Canon EOS M50", "CAM-001", "CMOS", "4K");

            equipmentService.AddEquipment(laptop1);
            equipmentService.AddEquipment(laptop2);
            equipmentService.AddEquipment(projector1);
            equipmentService.AddEquipment(camera1);

            Console.WriteLine("Equipment added:");
            foreach (var equipment in equipmentService.GetAllEquipment())
            {
                Console.WriteLine(equipment);
            }

            Console.WriteLine();
            Console.WriteLine("Available equipment:");
            foreach (var equipment in equipmentService.GetAvailableEquipment())
            {
                Console.WriteLine(equipment);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));

            // Bazaowa data do testów
            var baseDate = new DateTime(2026, 3, 1, 10, 0, 0);

            // 3. Poprawne wypożyczenie nr 1
            Console.WriteLine("Correct rental #1:");
            var rental1 = rentalService.RentEquipment(1, student1, laptop1, baseDate, 7);
            Console.WriteLine(rental1);

            // 4. Poprawne wypożyczenie nr 2
            Console.WriteLine();
            Console.WriteLine("Correct rental #2:");
            var rental2 = rentalService.RentEquipment(2, student1, projector1, baseDate.AddHours(1), 3);
            Console.WriteLine(rental2);

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));


            // 5. Błędna próba - sprzęt już wypożyczony
            Console.WriteLine("Invalid operation #1: renting unavailable equipment");
            try
            {
                rentalService.RentEquipment(3, student2, laptop1, baseDate.AddHours(2), 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected error: {ex.Message}");
            }

            // 6. Błędna próba - przekroczenie limitu studenta
            Console.WriteLine();
            Console.WriteLine("Invalid operation #2: exceeding student rental limit");
            try
            {
                rentalService.RentEquipment(4, student1, camera1, baseDate.AddHours(3), 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));


            // 7. Zwrot terminowy
            Console.WriteLine("On-time return:");
            rentalService.ReturnEquipment(2, baseDate.AddDays(2)); // przed terminem
            Console.WriteLine(rentalService.GetById(2));


            // 8. Nowe wypożyczenie po zwolnieniu limitu
            Console.WriteLine();
            Console.WriteLine("Rental after freeing student limit:");
            var rental3 = rentalService.RentEquipment(5, student1, camera1, baseDate.AddDays(2), 2);
            Console.WriteLine(rental3);


            // 9. Zwrot po terminie
            Console.WriteLine();
            Console.WriteLine("Late return with penalty:");
            rentalService.ReturnEquipment(5, baseDate.AddDays(6)); // po terminie
            Console.WriteLine(rentalService.GetById(5));

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));



            // 10. Przeterminowane aktywne wypożyczenie
            Console.WriteLine("Creating overdue active rental:");
            var rental4 = rentalService.RentEquipment(6, employee1, laptop2, new DateTime(2026, 3, 5, 9, 0, 0), 2);
            Console.WriteLine(rental4);

            var overdueCheckDate = new DateTime(2026, 3, 10, 12, 0, 0);

            Console.WriteLine();
            Console.WriteLine("Overdue rentals:");
            foreach (var rental in rentalService.GetOverdueRentals(overdueCheckDate))
            {
                Console.WriteLine(rental);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));



            // 11. Oznaczenie sprzętu jako niedostępnego
            Console.WriteLine("Marking equipment as unavailable:");
            equipmentService.MarkAsUnavailable(2); // laptop2
            Console.WriteLine(equipmentService.GetById(2));

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));


            // 12. Aktywne wypożyczenia użytkownika
            Console.WriteLine($"Active rentals for {student1.FullName}:");
            foreach (var rental in rentalService.GetActiveRentalsForUser(student1))
            {
                Console.WriteLine(rental);
            }

            Console.WriteLine();
            Console.WriteLine($"Active rentals for {employee1.FullName}:");
            foreach (var rental in rentalService.GetActiveRentalsForUser(employee1))
            {
                Console.WriteLine(rental);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 60));


            // 13. Raport końcowy
            Console.WriteLine("FINAL REPORT");
            Console.WriteLine();

            Console.WriteLine("All equipment:");
            foreach (var equipment in equipmentService.GetAllEquipment())
            {
                Console.WriteLine(equipment);
            }

            Console.WriteLine();
            Console.WriteLine("Available equipment:");
            foreach (var equipment in equipmentService.GetAvailableEquipment())
            {
                Console.WriteLine(equipment);
            }

            Console.WriteLine();
            Console.WriteLine("All rentals:");
            foreach (var rental in rentalService.GetAllRentals())
            {
                Console.WriteLine(rental);
            }

            Console.WriteLine();
            Console.WriteLine("Active rentals:");
            foreach (var rental in rentalService.GetActiveRentals())
            {
                Console.WriteLine(rental);
            }

            Console.WriteLine();
            Console.WriteLine("Overdue rentals:");
            foreach (var rental in rentalService.GetOverdueRentals(overdueCheckDate))
            {
                Console.WriteLine(rental);
            }

            Console.WriteLine();
            Console.WriteLine("=== END OF DEMO ===");
        }
    }
}