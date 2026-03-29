using EquipmentRental.Models;

namespace EquipmentRental.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        IReadOnlyList<User> GetAllUsers();
        User GetById(int id);
    }
}