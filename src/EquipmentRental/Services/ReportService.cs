using System.Text;
using EquipmentRental.Models;

namespace EquipmentRental.Services
{
    public class ReportService
    {
        private readonly EquipmentService _equipmentService;
        private readonly RentalService _rentalService;

        public ReportService(EquipmentService equipmentService, RentalService rentalService)
        {
            _equipmentService = equipmentService ?? throw new ArgumentNullException(nameof(equipmentService));
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
        }

        public string GetAllEquipmentReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("ALL EQUIPMENT:");

            foreach (var equipment in _equipmentService.GetAllEquipment())
            {
                sb.AppendLine(equipment.ToString());
            }

            return sb.ToString();
        }

        public string GetAvailableEquipmentReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("AVAILABLE EQUIPMENT:");

            foreach (var equipment in _equipmentService.GetAvailableEquipment())
            {
                sb.AppendLine(equipment.ToString());
            }

            return sb.ToString();
        }

        public string GetActiveRentalsForUserReport(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var sb = new StringBuilder();
            sb.AppendLine($"ACTIVE RENTALS FOR {user.FullName.ToUpper()}:");

            foreach (var rental in _rentalService.GetActiveRentalsForUser(user))
            {
                sb.AppendLine(rental.ToString());
            }

            return sb.ToString();
        }

        public string GetOverdueRentalsReport(DateTime currentDateTime)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"OVERDUE RENTALS AS OF {currentDateTime:yyyy-MM-dd HH:mm}:");

            foreach (var rental in _rentalService.GetOverdueRentals(currentDateTime))
            {
                sb.AppendLine(rental.ToString());
            }

            return sb.ToString();
        }

        public string GetSystemSummaryReport(DateTime currentDateTime)
        {
            var allEquipment = _equipmentService.GetAllEquipment();
            var availableEquipment = _equipmentService.GetAvailableEquipment();
            var allRentals = _rentalService.GetAllRentals();
            var activeRentals = _rentalService.GetActiveRentals();
            var overdueRentals = _rentalService.GetOverdueRentals(currentDateTime);

            var sb = new StringBuilder();
            sb.AppendLine("SYSTEM SUMMARY REPORT");
            sb.AppendLine($"Generated at: {currentDateTime:yyyy-MM-dd HH:mm}");
            sb.AppendLine();
            sb.AppendLine($"Total equipment items: {allEquipment.Count}");
            sb.AppendLine($"Available equipment items: {availableEquipment.Count}");
            sb.AppendLine($"Unavailable or rented equipment items: {allEquipment.Count - availableEquipment.Count}");
            sb.AppendLine($"Total rentals: {allRentals.Count}");
            sb.AppendLine($"Active rentals: {activeRentals.Count}");
            sb.AppendLine($"Overdue rentals: {overdueRentals.Count}");

            return sb.ToString();
        }
    }
}