using EquipmentRental.Models;

namespace EquipmentRental.Services
{
    public class RentalService
    {
        private readonly List<Rental> _rentals = new();
        private readonly PenaltyPolicy _penaltyPolicy;

        public RentalService(PenaltyPolicy penaltyPolicy)
        {
            _penaltyPolicy = penaltyPolicy ?? throw new ArgumentNullException(nameof(penaltyPolicy));
        }

        public Rental RentEquipment(int rentalId, User user, Equipment equipment, DateTime rentedAt, int rentalDays)
        {
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(equipment);

            if (rentalDays <= 0)
                throw new ArgumentOutOfRangeException(nameof(rentalDays), "Rental days must be greater than 0.");

            if (!equipment.IsAvailable)
                throw new InvalidOperationException("Equipment is not available for rental.");

            var activeRentalsCount = GetActiveRentalsForUser(user).Count;

            if (activeRentalsCount >= user.MaxActiveRentals)
                throw new InvalidOperationException(
                    $"User {user.FullName} has reached the rental limit of {user.MaxActiveRentals}.");

            var dueDate = rentedAt.AddDays(rentalDays);

            var rental = new Rental(rentalId, user, equipment, rentedAt, dueDate);

            equipment.MarkAsRented();
            _rentals.Add(rental);

            return rental;
        }

        public void ReturnEquipment(int rentalId, DateTime returnedAt)
        {
            var rental = GetById(rentalId);

            if (rental.IsReturned)
                throw new InvalidOperationException("Rental is already closed.");

            var penalty = _penaltyPolicy.CalculatePenalty(rental.DueDate, returnedAt);

            rental.Close(returnedAt, penalty);
            rental.Equipment.MarkAsAvailable();
        }

        public IReadOnlyList<Rental> GetAllRentals()
        {
            return _rentals.AsReadOnly();
        }

        public IReadOnlyList<Rental> GetActiveRentals()
        {
            return _rentals.Where(r => !r.IsReturned).ToList();
        }

        public IReadOnlyList<Rental> GetActiveRentalsForUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            return _rentals
                .Where(r => r.User.Id == user.Id && !r.IsReturned)
                .ToList();
        }

        public IReadOnlyList<Rental> GetOverdueRentals(DateTime currentDateTime)
        {
            return _rentals
                .Where(r => r.IsOverdue(currentDateTime))
                .ToList();
        }

        public Rental GetById(int rentalId)
        {
            var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);

            if (rental is null)
                throw new InvalidOperationException($"Rental with id {rentalId} was not found.");

            return rental;
        }
    }
}