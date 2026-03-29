using EquipmentRental.Models;

namespace EquipmentRental.Interfaces
{
    public interface IEquipmentService
    {
        void AddEquipment(Equipment equipment);
        IReadOnlyList<Equipment> GetAllEquipment();
        IReadOnlyList<Equipment> GetAvailableEquipment();
        Equipment GetById(int id);
        void MarkAsUnavailable(int equipmentId);
    }
}