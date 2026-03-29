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
            if (string.IsNullOrWhiteSpace(cpuModel))
                throw new ArgumentException("CPU model cannot be empty.", nameof(cpuModel));

            if (ramGb <= 0)
                throw new ArgumentOutOfRangeException(nameof(ramGb), "RAM must be greater than 0.");

            CpuModel = cpuModel;
            RamGb = ramGb;
        }
    }
}