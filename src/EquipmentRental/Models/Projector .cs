namespace EquipmentRental.Models
{
    public class Projector : Equipment
    {
        public string Resolution { get; }
        public int BrightnessAnsiLumens { get; }

        public Projector(
            int id,
            string name,
            string inventoryNumber,
            string resolution,
            int brightnessAnsiLumens,
            EquipmentStatus status = EquipmentStatus.Available)
            : base(id, name, inventoryNumber, status)
        {
            if (string.IsNullOrWhiteSpace(resolution))
                throw new ArgumentException("Resolution cannot be empty.", nameof(resolution));

            if (brightnessAnsiLumens <= 0)
                throw new ArgumentOutOfRangeException(nameof(brightnessAnsiLumens), "Brightness must be greater than 0.");

            Resolution = resolution;
            BrightnessAnsiLumens = brightnessAnsiLumens;
        }
    }
}