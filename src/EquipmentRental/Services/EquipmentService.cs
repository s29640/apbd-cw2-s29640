using EquipmentRental.Exceptions;
using EquipmentRental.Interfaces;
using EquipmentRental.Models;

namespace EquipmentRental.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly List<Equipment> _equipment = new();

        public void AddEquipment(Equipment equipment)
        {
            ArgumentNullException.ThrowIfNull(equipment);

            if (_equipment.Any(e => e.Id == equipment.Id))
                throw new DuplicateEquipmentIdException(equipment.Id);

            _equipment.Add(equipment);
        }

        public IReadOnlyList<Equipment> GetAllEquipment()
        {
            return _equipment.AsReadOnly();
        }

        public IReadOnlyList<Equipment> GetAvailableEquipment()
        {
            return _equipment.Where(e => e.IsAvailable).ToList();
        }

        public Equipment GetById(int id)
        {
            var equipment = _equipment.FirstOrDefault(e => e.Id == id);

            if (equipment is null)
                throw new EntityNotFoundException(typeof(Equipment).Name, id);

            return equipment;
        }

        public void MarkAsUnavailable(int equipmentId)
        {
            var equipment = GetById(equipmentId);
            equipment.MarkAsUnavailable();
        }
    }
}