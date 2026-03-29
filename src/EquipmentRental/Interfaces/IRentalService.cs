using EquipmentRental.Models;

namespace EquipmentRental.Interfaces
{
    public interface IRentalService
    {
        IReadOnlyList<Rental> GetActiveRentals();
        IReadOnlyList<Rental> GetActiveRentalsForUser(User user);
        IReadOnlyList<Rental> GetAllRentals();
        Rental GetById(int rentalId);
        IReadOnlyList<Rental> GetOverdueRentals(DateTime currentDateTime);
        Rental RentEquipment(int rentalId, User user, Equipment equipment, DateTime rentedAt, int rentalDays);
        void ReturnEquipment(int rentalId, DateTime returnedAt);
    }
}