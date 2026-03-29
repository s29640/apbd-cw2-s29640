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
            if (string.IsNullOrWhiteSpace(sensorType))
                throw new ArgumentException("Sensor type cannot be empty.", nameof(sensorType));

            if (string.IsNullOrWhiteSpace(maxVideoResolution))
                throw new ArgumentException("Max video resolution cannot be empty.", nameof(maxVideoResolution));

            SensorType = sensorType;
            MaxVideoResolution = maxVideoResolution;
        }
    }
}