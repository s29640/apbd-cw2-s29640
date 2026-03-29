namespace EquipmentRental.Models
{
    public class Rental
    {
        public int Id { get; }
        public User User { get; }
        public Equipment Equipment { get; }
        public DateTime RentedAt { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnedAt { get; private set; }
        public decimal PenaltyAmount { get; private set; }

        public bool IsReturned => ReturnedAt.HasValue;
        public bool IsOverdue(DateTime currentDateTime)
        {
            return !IsReturned && currentDateTime > DueDate;
        }

        public Rental(
            int id,
            User user,
            Equipment equipment,
            DateTime rentedAt,
            DateTime dueDate)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            User = user ?? throw new ArgumentNullException(nameof(user));
            Equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));

            if (dueDate < rentedAt)
                throw new ArgumentException("Due date cannot be earlier than rented date.", nameof(dueDate));

            Id = id;
            RentedAt = rentedAt;
            DueDate = dueDate;
            ReturnedAt = null;
            PenaltyAmount = 0m;
        }

        public bool WasReturnedLate()
        {
            return IsReturned && ReturnedAt!.Value > DueDate;
        }

        public void Close(DateTime returnedAt, decimal penaltyAmount)
        {
            ReturnedAt = returnedAt;
            PenaltyAmount = penaltyAmount;
        }
    }
}