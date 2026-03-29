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
            Resolution = resolution;
            BrightnessAnsiLumens = brightnessAnsiLumens;
        }
    }
}