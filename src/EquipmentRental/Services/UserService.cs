using EquipmentRental.Exceptions;
using EquipmentRental.Interfaces;
using EquipmentRental.Models;

namespace EquipmentRental.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();

        public void AddUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (_users.Any(u => u.Id == user.Id))
                throw new DuplicateUserIdException(user.Id);

            _users.Add(user);
        }

        public IReadOnlyList<User> GetAllUsers()
        {
            return _users.AsReadOnly();
        }

        public User GetById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user is null)
                throw new EntityNotFoundException(typeof(User).Name, id);

            return user;
        }
    }
}