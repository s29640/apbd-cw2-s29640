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
        public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;

        public Rental(
            int id,
            User user,
            Equipment equipment,
            DateTime rentedAt,
            DateTime dueDate)
        {
            Id = id;
            User = user;
            Equipment = equipment;
            RentedAt = rentedAt;
            DueDate = dueDate;
            ReturnedAt = null;
            PenaltyAmount = 0m;
        }

        public void Close(DateTime returnedAt, decimal penaltyAmount)
        {
            ReturnedAt = returnedAt;
            PenaltyAmount = penaltyAmount;
        }
    }
}