namespace EquipmentRental.Services
{
    public class PenaltyPolicy
    {
        private const decimal DailyPenalty = 10m;

        public decimal CalculatePenalty(DateTime dueDate, DateTime returnedAt)
        {
            if (returnedAt <= dueDate)
                return 0m;

            var lateDays = (returnedAt.Date - dueDate.Date).Days;

            if (lateDays <= 0)
                lateDays = 1;

            return lateDays * DailyPenalty;
        }
    }
}