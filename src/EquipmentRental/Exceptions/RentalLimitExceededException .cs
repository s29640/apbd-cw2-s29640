namespace EquipmentRental.Exceptions
{
    public class RentalLimitExceededException : DomainException
    {
        public RentalLimitExceededException(string userFullName, int limit)
            : base($"User {userFullName} has reached the rental limit of {limit}.")
        {
        }
    }
}