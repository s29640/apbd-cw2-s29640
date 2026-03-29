namespace EquipmentRental.Models
{

    public class Camera : Equipment
    {
        public string SensorType { get; }
        public string MaxVideoResolution { get; }

        public Camera(
            int id,
            string name,
            string inventoryNumber,
            string sensorType,
            string maxVideoResolution,
            EquipmentStatus status = EquipmentStatus.Available)
            : base(id, name, inventoryNumber, status)
        {
            SensorType = sensorType;
            MaxVideoResolution = maxVideoResolution;
        }
    }
}