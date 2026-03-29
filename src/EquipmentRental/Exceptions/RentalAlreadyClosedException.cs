namespace EquipmentRental.Exceptions
{
    public class RentalAlreadyClosedException : DomainException
    {
        public RentalAlreadyClosedException(int rentalId)
            : base($"Rental with id = {rentalId} is already closed.")
        {
        }
    }
}