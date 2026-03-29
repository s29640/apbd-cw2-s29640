namespace EquipmentRental.Models
{
    public abstract class Equipment
    {
        public int Id { get; }
        public string Name { get; }
        public string InventoryNumber { get; }
        public EquipmentStatus Status { get; private set; }

        public bool IsAvailable => Status == EquipmentStatus.Available;

        protected Equipment(
            int id,
            string name,
            string inventoryNumber,
            EquipmentStatus status = EquipmentStatus.Available)
        {
            Id = id;
            Name = name;
            InventoryNumber = inventoryNumber;
            Status = status;
        }

        public void MarkAsRented()
        {
            Status = EquipmentStatus.Rented;
        }

        public void MarkAsAvailable()
        {
            Status = EquipmentStatus.Available;
        }

        public void MarkAsUnavailable()
        {
            Status = EquipmentStatus.Unavailable;
        }

    }
}