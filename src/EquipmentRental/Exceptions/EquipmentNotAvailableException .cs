namespace EquipmentRental.Exceptions
{
    public class EquipmentNotAvailableException : DomainException
    {
        public EquipmentNotAvailableException(int equipmentId)
            : base($"Equipment with id {equipmentId} is not available for rental.")
        {
        }
    }
}