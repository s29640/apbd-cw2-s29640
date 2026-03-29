namespace EquipmentRental.Models
{
    public class Laptop : Equipment
    {
        public string CpuModel { get; }
        public int RamGb { get; }

        public Laptop(
            int id,
            string name,
            string inventoryNumber,
            string cpuModel,
            int ramGb,
            EquipmentStatus status = EquipmentStatus.Available)
            : base(id, name, inventoryNumber, status)
        {
            CpuModel = cpuModel;
            RamGb = ramGb;
        }
    }
}