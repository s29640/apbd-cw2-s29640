using EquipmentRental.Models;

namespace EquipmentRental.Services
{
    public class UserService
    {
        private readonly List<User> _users = new();

        public void AddUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (_users.Any(u => u.Id == user.Id))
                throw new InvalidOperationException($"User with id {user.Id} already exists.");

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
                throw new InvalidOperationException($"User with id {id} was not found.");

            return user;
        }
    }
}