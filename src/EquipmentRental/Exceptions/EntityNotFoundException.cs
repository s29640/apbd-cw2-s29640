namespace EquipmentRental.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string entity, int id)
            : base($"{entity} with id {id} not found.")
        {
        }
    }
}