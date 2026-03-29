namespace EquipmentRental.Exceptions
{
    internal class DuplicateEquipmentIdException : DomainException
    {
        public DuplicateEquipmentIdException(int id) 
            : base($"Equipment with id {id} already exists.")
        {
        }
    }
}
