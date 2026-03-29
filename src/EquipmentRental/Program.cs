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
            var reportService = new ReportService(equipmentService, rentalService);

            Console.WriteLine("=== EQUIPMENT RENTAL DEMO ===");

            // 1. Dodanie użytkowników
            var student1 = new Student(1, "Jan", "Kowalski", "s12345");
            var student2 = new Student(2, "Anna", "Nowak", "s23456");
            var employee1 = new Employee(3, "Piotr", "Zielinski", "IT");

            userService.AddUser(student1);
            userService.AddUser(student2);
            userService.AddUser(employee1);

            PrintSection("Users added:");
            foreach (var user in userService.GetAllUsers())
            {
                Console.WriteLine(user);
            }

            // 2. Dodanie sprzętu
            var laptop1 = new Laptop(1, "Dell Latitude", "LAP-001", "Intel i5", 16);
            var laptop2 = new Laptop(2, "Lenovo ThinkPad", "LAP-002", "Intel i7", 32);
            var projector1 = new Projector(3, "Epson EB-X06", "PROJ-001", "1920x1080", 3600);
            var camera1 = new Camera(4, "Canon EOS M50", "CAM-001", "CMOS", "4K");

            equipmentService.AddEquipment(laptop1);
            equipmentService.AddEquipment(laptop2);
            equipmentService.AddEquipment(projector1);
            equipmentService.AddEquipment(camera1);

            PrintSection("Equipment added:");
            Console.WriteLine(reportService.GetAllEquipmentReport());
            Console.WriteLine(reportService.GetAvailableEquipmentReport());

            // Bazowa data do testów
            var baseDate = new DateTime(2026, 3, 1, 10, 0, 0);

            // 3. Poprawne wypożyczenie nr 1
            PrintSection("Correct rental #1:");
            var rental1 = rentalService.RentEquipment(1, student1, laptop1, baseDate, 7);
            Console.WriteLine(rental1);

            // 4. Poprawne wypożyczenie nr 2
            PrintSection("Correct rental #2:");
            var rental2 = rentalService.RentEquipment(2, student1, projector1, baseDate.AddHours(1), 3);
            Console.WriteLine(rental2);

            // 5. Błędna próba - sprzęt już wypożyczony
            PrintSection("Invalid operation #1: renting unavailable equipment");
            PrintExpectedError(
                () => rentalService.RentEquipment(3, student2, laptop1, baseDate.AddHours(2), 5));

            // 6. Błędna próba - przekroczenie limitu studenta
            PrintSection("Invalid operation #2: exceeding student rental limit");
            PrintExpectedError(
                () => rentalService.RentEquipment(4, student1, camera1, baseDate.AddHours(3), 5));


            // 7. Zwrot terminowy
            PrintSection("On-time return:");
            rentalService.ReturnEquipment(2, baseDate.AddDays(2)); // przed terminem
            Console.WriteLine(rentalService.GetById(2));


            // 8. Nowe wypożyczenie po zwolnieniu limitu
            PrintSection("Rental after freeing student limit:");
            var rental3 = rentalService.RentEquipment(5, student1, camera1, baseDate.AddDays(2), 2);
            Console.WriteLine(rental3);


            // 9. Zwrot po terminie
            PrintSection("Late return with penalty:");
            rentalService.ReturnEquipment(5, baseDate.AddDays(6)); // po terminie
            Console.WriteLine(rentalService.GetById(5));


            // 10. Przeterminowane aktywne wypożyczenie
            PrintSection("Creating overdue active rental:");
            var rental4 = rentalService.RentEquipment(6, employee1, laptop2, new DateTime(2026, 3, 5, 9, 0, 0), 2);
            Console.WriteLine(rental4);

            var overdueCheckDate = new DateTime(2026, 3, 10, 12, 0, 0);

            Console.WriteLine();
            Console.WriteLine(reportService.GetOverdueRentalsReport(overdueCheckDate));


            // 11. Oznaczenie sprzętu jako niedostępnego
            PrintSection("Marking equipment as unavailable:");
            equipmentService.MarkAsUnavailable(camera1.Id);
            Console.WriteLine(equipmentService.GetById(camera1.Id));


            // 12. Aktywne wypożyczenia użytkownika
            PrintSection("Active rentals for users");
            Console.WriteLine(reportService.GetActiveRentalsForUserReport(student1));

            Console.WriteLine(reportService.GetActiveRentalsForUserReport(employee1));

            
            
            
            // 13. Raport końcowy

            PrintSection("FINAL REPORT");

            Console.WriteLine(reportService.GetAllEquipmentReport());

            Console.WriteLine(reportService.GetAvailableEquipmentReport());

            Console.WriteLine(reportService.GetAllRentalsReport());

            Console.WriteLine(reportService.GetActiveRentalsReport());

            Console.WriteLine(reportService.GetOverdueRentalsReport(overdueCheckDate));

            Console.WriteLine(reportService.GetSystemSummaryReport(overdueCheckDate));

            Console.WriteLine("=== END OF DEMO ===");
        }

        private static void PrintSection(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(title);
            Console.WriteLine();
        }

        private static void PrintExpectedError(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected error: {ex.Message}");
            }
        }

    }
}