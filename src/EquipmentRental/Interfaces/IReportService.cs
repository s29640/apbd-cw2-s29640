using EquipmentRental.Models;

namespace EquipmentRental.Interfaces
{
    public interface IReportService
    {
        string GetActiveRentalsForUserReport(User user);
        string GetActiveRentalsReport();
        string GetAllEquipmentReport();
        string GetAllRentalsReport();
        string GetAvailableEquipmentReport();
        string GetOverdueRentalsReport(DateTime currentDateTime);
        string GetSystemSummaryReport(DateTime currentDateTime);
    }
}